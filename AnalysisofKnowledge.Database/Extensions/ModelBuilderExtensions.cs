using System;
using System.Collections.Generic;
using System.Linq;
using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Configure.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnalysisofKnowledge.Database.Extensions
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Bulk register(with lot of reflection) IEntityTypeConfiguration 
        /// </summary>
        /// <param name="modelBuilder">Fluent API model builder</param>
        /// <param name="baseConfigurationType">The base type of the entity configuration</param>
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
                .Where(type => type.IsGenericType == false
                               && type.BaseType != null
                               && type.BaseType.IsGenericType
                               && type.BaseType.GetGenericTypeDefinition() == baseConfigurationType);

            foreach (var type in applicableTypes)
            {
                foreach (var typeInterface in type.GetInterfaces())
                {
                    // if type implements interface IEntityTypeConfiguration<SomeEntity>
                    if (!typeInterface.IsConstructedGenericType ||
                        typeInterface.GetGenericTypeDefinition() != configurationType) continue;
                    // make concrete ApplyConfiguration<SomeEntity> method
                    var applyConcreteMethod =
                        applyGenericMethod.MakeGenericMethod(typeInterface.GenericTypeArguments[0]);
                    // and invoke that with fresh instance of your configuration type
                    applyConcreteMethod.Invoke(modelBuilder, new[] {Activator.CreateInstance(type)});
                    break;
                }
            }
        }

        /// <summary>
        /// Bulk register for base domain specified entity configs
        /// </summary>
        /// <param name="modelBuilder">Fluent API model builder</param>
        public static void ApplyAllConfigurationsFromCurrentAssembly(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(typeof(BaseEntityConfig<,>));

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(typeof(BaseIdentityEntityConfig<,>));

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(typeof(BaseTestResultConfig<>));
        }
    }
}