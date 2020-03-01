using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Configure.Base.Interfaces;
using AnalysisofKnowledge.Database.Entities.TestResults;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure
{
    public class ReflexivityTestResultConfigure : BaseTestResultConfig<ReflexivityTestResult>, IEntityConfig
    {
        public override void Configure(EntityTypeBuilder<ReflexivityTestResult> builder)
        {
            base.Configure(builder);

            builder.Property(testResult => testResult.ReflexivitiesTestResult).IsRequired();
        }
    }
}