using System;
using AnalysisofKnowledge.Database.NpgSqlApplicationDbContext.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AnalysisofKnowledge.Database.NpgSqlApplicationDbContext
{
    /// <summary>
    /// Required for moq the ApplicationDbContext 
    /// </summary>
    public interface IApplicationDbContext : IApplicationDbContextBase, IHasEntry,
        IInfrastructure<IServiceProvider>
    {
        ChangeTracker ChangeTracker { get; }

        DatabaseFacade Database { get; }
    }
}