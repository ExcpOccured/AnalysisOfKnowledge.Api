using System;
using System.Linq;
using AnalysisofKnowledge.Database.Entities.Interfaces.Base;
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
    /// </typeparam>
    /// <typeparam name="TKey">
    /// Type of PK
    /// </typeparam>
    /// >
    public class BaseEntityConfig<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
        where TKey : struct, IEquatable<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            if (typeof(TEntity).GetInterfaces().Contains(typeof(IEntity<TKey>)))
            {
                builder.Property(_ => ((IEntity<TKey>) _).Id).ValueGeneratedOnAdd();

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