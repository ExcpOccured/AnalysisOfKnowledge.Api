using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AnalysisofKnowledge.Database.NpgSqlApplicationDbContext.Interfaces
{
    public interface IHasEntry
    {
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        EntityEntry Entry(object entity);
    }
}