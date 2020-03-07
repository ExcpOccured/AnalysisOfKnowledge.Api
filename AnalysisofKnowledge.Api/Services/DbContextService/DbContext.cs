using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalysisofKnowledge.Api.Domain.Delegates;
using AnalysisofKnowledge.Api.Domain.Exceptions;
using AnalysisofKnowledge.Api.Domain.Extensions;
using AnalysisofKnowledge.Database.Entities.Interfaces.Base;
using AnalysisofKnowledge.Database.NpgSqlApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AnalysisofKnowledge.Api.Services.DbContextService
{
    public class DbContext : IDbContext
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DbContext(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IDbContextTransaction BeginTransaction() =>
            _applicationDbContext.Database.BeginTransaction();

        public DbSet<TEntity> DbSet<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey> =>
            _applicationDbContext.Set<TEntity>();

        public IQueryable<TEntity> Set<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey> =>
            DbSet<TEntity, TKey>().AsQueryable();

        public async Task<TEntity> GetEntityById<TEntity, TKey>(TKey id,
            QueryTransform<TEntity, TKey> queryTransform = default) where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey> =>
            await Set<TEntity, TKey>()
                .MaybeTransform(queryTransform)
                .FirstAsync(entity => entity.Id.Equals(id)) ?? throw new EntityNotFoundException<TEntity>(id);

        public async Task Create<TEntity, TKey>(TEntity entity) where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey> =>
            await ExecuteWithSaveChanges(async () => await DbSet<TEntity, TKey>().AddAsync(entity));

        public async Task CreateRange<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey> =>
            await ExecuteWithSaveChanges(async () => await DbSet<TEntity, TKey>().AddRangeAsync(entities));

        public async Task Remove<TEntity, TKey>(TEntity entity) where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey> =>
            await ExecuteWithSaveChanges(() => DbSet<TEntity, TKey>().Remove(entity));

        public async Task RemoveRange<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntity<TKey>
            where TKey : struct, IEquatable<TKey>
        {
            foreach (var entity in entities)
            {
                await Remove<TEntity, TKey>(entity);
            }
        }

        private async Task ExecuteWithSaveChanges<TResult>(Func<TResult> changeEntityStateOperation)
        {
            changeEntityStateOperation();
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}