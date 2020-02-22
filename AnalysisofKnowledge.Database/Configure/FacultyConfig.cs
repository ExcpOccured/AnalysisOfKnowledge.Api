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

            builder.HasOne(_ => _.Student)
                .WithOne(_ => _.Faculty)
                .HasForeignKey<Faculty>(_ => _.StudentId);
            
            builder.HasOne(_ => _.Teacher)
                .WithOne(_ => _.Faculty)
                .HasForeignKey<Faculty>(_ => _.TeacherId);
        }
    }
}