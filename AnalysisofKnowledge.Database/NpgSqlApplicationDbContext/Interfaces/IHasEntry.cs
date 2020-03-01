using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AnalysisofKnowledge.Database.NpgSqlApplicationDbContext.Interfaces
{
    /// <summary>
    /// Allows to change Entity DbContext entry for intercept provider transactions 
    /// </summary>
    public interface IHasEntry
    {
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        EntityEntry Entry(object entity);
    }
}