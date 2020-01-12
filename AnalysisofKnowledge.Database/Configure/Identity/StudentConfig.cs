using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Configure.Base.Interfaces;
using AnalysisofKnowledge.Database.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure.Identity
{
    public class StudentConfig : BaseIdentityEntityConfig<Student>, IEntityConfig
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);

            builder.HasOne(_ => _.Faculty)
                .WithOne(_ => _.Student)
                .HasForeignKey<Student>(_ => _.FacultyId);
        }
    }
}