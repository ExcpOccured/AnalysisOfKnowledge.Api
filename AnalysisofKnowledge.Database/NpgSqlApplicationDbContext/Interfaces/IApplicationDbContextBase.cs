using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AnalysisofKnowledge.Database.NpgSqlApplicationDbContext.Interfaces
{
    public interface IApplicationDbContextBase : IAsyncDisposable, IDisposable, IDbContextDependencies,
        IDbSetCache,
        IDbContextPoolable
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}