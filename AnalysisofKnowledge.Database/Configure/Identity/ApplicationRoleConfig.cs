using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Configure.Base.Interfaces;
using AnalysisofKnowledge.Database.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure.Identity
{
    public class ApplicationRoleConfig : BaseEntityConfig<ApplicationRole, long>, IEntityConfig
    {
        public override void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            base.Configure(builder);

            builder.HasMany(applicationRole => applicationRole.UserRoles)
                .WithOne(userRole => userRole.Role)
                .HasForeignKey(userRole => userRole.RoleId);
        }
    }
}