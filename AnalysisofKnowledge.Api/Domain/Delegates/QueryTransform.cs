using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AnalysisofKnowledge.Database.Entities.Interfaces.Base;

namespace AnalysisofKnowledge.Api.Domain.Delegates
{
    /// <summary>
    /// Optional IQueryable functor
    /// </summary>
    /// <param name="query">
    /// IQueryable expression type
    /// </param>
    /// <typeparam name="TEntity">
    ///  Type of entity
    /// </typeparam>
    /// <typeparam name="TKey">
    ///  Type of entity PK
    /// </typeparam>
    public delegate IQueryable<TEntity> QueryTransform<TEntity, TKey>([NotNull] IQueryable<TEntity> query)
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>;
}