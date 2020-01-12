using System;
using System.Collections.Generic;
using System.Linq;
using AnalysisofKnowledge.Database.Configure.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnalysisofKnowledge.Database.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurationsFromCurrentAssembly(this ModelBuilder modelBuilder,
            Type baseConfigurationType)
        {
            // ModelBuilder contains multiple ApplyConfiguration methods
            var configurationType = typeof(IEntityTypeConfiguration<>);
            var applyGenericMethod = typeof(ModelBuilder).GetMethods()
                .Where(type => type.IsPublic)
                .Where(type => type.Name == "ApplyConfiguration")
                .First(type => type.GetParameters()
                    .Any(parameterInfo => parameterInfo.ParameterType.GetGenericTypeDefinition() == configurationType)
                );

            var applicableTypes = baseConfigurationType
                .Assembly
                .GetTypes()
                .Where(_ => _.IsGenericType == false
                            && _.BaseType != null
                            && _.BaseType.IsGenericType
                            && _.BaseType.GetGenericTypeDefinition() == baseConfigurationType);

            foreach (var type in applicableTypes)
            {
                foreach (var typeInterface in type.GetInterfaces())
                {
                    // if type implements interface IEntityTypeConfiguration<SomeEntity>
                    if (!typeInterface.IsConstructedGenericType ||
                        typeInterface.GetGenericTypeDefinition() != configurationType) continue;
                    // make concrete ApplyConfiguration<SomeEntity> method
                    var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(typeInterface.GenericTypeArguments[0]);
                    // and invoke that with fresh instance of your configuration type
                    applyConcreteMethod.Invoke(modelBuilder, new[] {Activator.CreateInstance(type)});
                    break;
                }
            }
        }

        public static IEnumerable<IEntityTypeConfiguration<TEntity>> GetAllConfigurableEntities<TEntity>()
            where TEntity : class
        {
            var interfaceType = typeof(IEntityConfig);

            foreach (var currentAssembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in currentAssembly.GetTypes())
                {
                    if (interfaceType.IsAssignableFrom(type)) yield return (IEntityTypeConfiguration<TEntity>) type;
                }
            }
        }
    }
}