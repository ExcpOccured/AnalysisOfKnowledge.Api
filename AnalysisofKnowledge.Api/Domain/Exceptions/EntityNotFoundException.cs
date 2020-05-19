using System;
using System.Reflection;

namespace AnalysisofKnowledge.Api.Domain.Exceptions
{
    /// <summary>
    /// Thrown when an entity wasn't found in the DB.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        protected EntityNotFoundException(
            object searchFieldValue, MemberInfo entityType, string searchFieldName = "Id", string message = null)
            : base(
                $"Failed to find entity {entityType.Name} with {searchFieldName} {searchFieldValue} in Database! {message}") { }
    }

    /// <inheritdoc/>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="System.Exception"/>
    public class EntityNotFoundException<TEntity> : EntityNotFoundException
    {
        public EntityNotFoundException(object searchFieldValue, string searchFieldName = "Id", string message = null)
            : base(searchFieldValue, typeof(TEntity), searchFieldName, message) { }
    }
}