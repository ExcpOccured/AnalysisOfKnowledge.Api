using AnalysisofKnowledge.Database.Entities.Identity;
using AnalysisofKnowledge.Database.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnalysisofKnowledge.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, 
        long, UserClaim, UserRole, UserLogin, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public AppDbContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyAllConfigurationsFromCurrentAssembly();
        }
    }
}