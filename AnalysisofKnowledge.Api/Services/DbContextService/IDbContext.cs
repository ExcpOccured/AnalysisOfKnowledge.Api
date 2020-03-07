using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AnalysisofKnowledge.Api.Domain.Delegates;
using AnalysisofKnowledge.Api.Domain.Exceptions;
using AnalysisofKnowledge.Api.Domain.Models.ServicesContractTypes;
using AnalysisofKnowledge.Database.Entities.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AnalysisofKnowledge.Api.Services.DbContextService
{
    /// <summary>
    ///  Provides access to the Database.
    /// </summary>
    public interface IDbContext : IScopedService
    {
        // Intercepting Application DbContext 
        IDbContextTransaction BeginTransaction();

        /// <summary>
        ///  Gets or sets the <see cref="DbSet{TEntity}"/>
        /// </summary>
        DbSet<TEntity> DbSet<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey>;

        /// <summary>
        ///  Gets or sets the IQueryable<TEntity />
        /// </summary>
        IQueryable<TEntity> Set<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey>;

        /// <summary>
        ///     Asynchronously finds an entity with the given primary key values. If an entity with the given primary key values
        ///     exists in the context, then it is returned immediately without making a request to the store. Otherwise, a request
        ///     is made to the store for an entity with the given primary key values and this entity is attached to the
        ///     context and returned.
        /// </summary>
        /// <returns>
        ///     The entity found.
        /// </returns>
        /// <exception cref="EntityNotFoundException">
        ///     The entity was not found.
        /// </exception>
        Task<TEntity> GetEntityById<TEntity, TKey>(TKey id, QueryTransform<TEntity, TKey> queryTransform = default)
            where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey>;

        /// <summary>
        ///     Adds the given <paramref name="entity"/> to the entity set
        ///     and asynchronously saves the changes.
        /// </summary>
        /// <param name="entity">
        ///     The entity to add.
        /// </param>
        /// <typeparam name="TEntity">
        ///     Type of the entity.
        /// </typeparam>
        /// <typeparam name="TKey">
        ///    Type of the entity PK
        /// </typeparam>
        Task Create<TEntity, TKey>([NotNull] TEntity entity)
            where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey>;

        /// <summary>
        ///     Adds each of the given <paramref name="entities"/> to the entity set
        ///     and asynchronously saves the changes.
        /// </summary>
        /// <param name="entities">
        ///     The entities to add.
        /// </param>
        /// <typeparam name="TEntity">
        ///     Type of the entity.
        /// </typeparam>
        /// <typeparam name="TKey">
        ///  Type of the entity PK
        /// </typeparam>
        Task CreateRange<TEntity, TKey>([NotNull] IEnumerable<TEntity> entities)
            where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey>;

        /// <summary>
        ///     Removes the given <paramref name="entity"/> from the entity set
        ///     and asynchronously saves the changes.
        /// </summary>
        /// <param name="entity">
        ///     The entity to remove.
        /// </param>
        /// <typeparam name="TEntity">
        ///     Type of the entity.
        /// </typeparam>
        ///  
        /// <typeparam name="TKey"></typeparam>
        Task Remove<TEntity, TKey>([NotNull] TEntity entity)
            where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey>;

        /// <summary>
        ///     Removes each of the given <paramref name="entities"/> from the entity set
        ///     and asynchronously saves the changes.
        /// </summary>
        /// <param name="entities">
        ///     The entities to remove.
        /// </param>
        /// <typeparam name="TEntity">
        ///     Type of the entity.
        /// </typeparam>
        /// <typeparam name="TKey">
        ///     
        /// </typeparam>
        Task RemoveRange<TEntity, TKey>([NotNull] IEnumerable<TEntity> entities)
            where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey>;
    }
}