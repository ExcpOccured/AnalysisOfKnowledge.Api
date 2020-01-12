using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure.Identity
{
    public class TeacherConfig : BaseIdentityEntityConfig<Teacher>
    {
        public override void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);
            
            builder.HasOne(_ => _.Faculty)
                .WithOne(_ => _.Teacher)
                .HasForeignKey<Teacher>(_ => _.FacultyId);
        }
    }
}