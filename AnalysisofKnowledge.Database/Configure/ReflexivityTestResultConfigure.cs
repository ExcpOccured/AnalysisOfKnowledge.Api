using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Entities.TestResults;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure
{
    public class ReflexivityTestResultConfigure : BaseTestResultConfig<ReflexivityTestResult>
    {
        public override void Configure(EntityTypeBuilder<ReflexivityTestResult> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.ReflexivitiesTestResult).IsRequired();
        }
    }
}