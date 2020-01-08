using System.Linq;
using AnalysisofKnowledge.Database.Entities.Interfaces;
using AnalysisofKnowledge.Database.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure.Base
{
    /// <summary>
    /// Base entity Fluent-Api config
    /// </summary>
    /// <typeparam name="TEntity">
    /// Class of the Entity
    /// </typeparam>>
    public class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            if (typeof(TEntity).GetInterfaces().Contains(typeof(IEntity)))
            {
                builder.Property(_ => ((IEntity) _).Id).ValueGeneratedOnAdd();

                // Warranty for SQL data provider and Ef core
                builder.ToTable($"{typeof(TEntity).Name}s");
            }
            else
            {
                throw new InvalidEntityTypeConfigureException();
            }
        }
    }
}