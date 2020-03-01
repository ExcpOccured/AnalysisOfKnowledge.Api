using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure.Identity
{
    public class ApplicationUserConfig : BaseIdentityEntityConfig<ApplicationUser, long>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            base.Configure(builder);

            builder.Property(user => user.Education).IsRequired(false);
            
            builder.HasOne(user => user.Faculty)
                .WithOne(faculty => faculty.ApplicationUser)
                .HasForeignKey<ApplicationUser>(user => user.FacultyId);
        }
    }
}