using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure
{
    public class FacultyConfig : BaseEntityConfig<Faculty, long>
    {
        public override void Configure(EntityTypeBuilder<Faculty> builder)
        {
            base.Configure(builder);

            builder.HasOne(applicationUser => applicationUser.ApplicationUser)
                .WithOne(applicationUser => applicationUser.Faculty)
                .HasForeignKey<Faculty>(faculty => faculty.StudentId);
        }
    }
}