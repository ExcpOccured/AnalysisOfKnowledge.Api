using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Configure.Base.Interfaces;
using AnalysisofKnowledge.Database.Entities.TestResults;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure
{
    public class ActivityTestResultConfigure : BaseTestResultConfig<ActivityTestResult>, IEntityConfig
    {
        public override void Configure(EntityTypeBuilder<ActivityTestResult> builder)
        {
            base.Configure(builder);

            builder.Property(testResult => testResult.ActivityTestsResult).IsRequired();

            builder.OwnsOne(testResult => testResult.Points);
        }
    }
}