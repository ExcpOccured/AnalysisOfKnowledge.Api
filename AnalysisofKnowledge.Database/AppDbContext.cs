using AnalysisofKnowledge.Database.Entities.Identity;
using AnalysisofKnowledge.Database.Extensions;
using AnalysisofKnowledge.Database.NpgSqlApplicationDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.Logging;

namespace AnalysisofKnowledge.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,
        long, UserClaim, UserRole, UserLogin, IdentityRoleClaim<long>, IdentityUserToken<long>>, IApplicationDbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Apply all Fluent API configs for all entities in AppDbContext assembly
            builder.ApplyAllConfigurationsFromCurrentAssembly();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //Logging SQL queries in console 
#if DEBUG
            NpgsqlLogManager.Provider = new ConsoleLoggingProvider(NpgsqlLogLevel.Debug);
#endif
        }
    }
}