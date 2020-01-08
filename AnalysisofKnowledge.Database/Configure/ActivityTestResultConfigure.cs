using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Entities.TestResults;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure
{
    public class ActivityTestResultConfigure : BaseTestResultConfig<ActivityTestResult>
    {
        public override void Configure(EntityTypeBuilder<ActivityTestResult> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.ActivityTestsResult).IsRequired();
        }
    }
}