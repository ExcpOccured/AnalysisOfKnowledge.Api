using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AnalysisofKnowledge.Api.Domain.Delegates;
using AnalysisofKnowledge.Database.Entities.Interfaces.Base;

namespace AnalysisofKnowledge.Api.Domain.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Optional IQueryable entity functor that allows to composite lambda expressions  
        /// </summary>
        public static IQueryable<TEntity> MaybeTransform<TEntity, TKey>(
            [NotNull] this IQueryable<TEntity> query, QueryTransform<TEntity, TKey> queryTransform)
            where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey> =>
            queryTransform?.Invoke(query) ?? query;
    }
}