using AnalysisofKnowledge.Database.Configure.Base;
using AnalysisofKnowledge.Database.Configure.Base.Interfaces;
using AnalysisofKnowledge.Database.Entities.TestResults;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalysisofKnowledge.Database.Configure
{
    public class LanguagesTestResultConfigure : BaseTestResultConfig<LanguagesTestResult>, IEntityConfig
    {
        public override void Configure(EntityTypeBuilder<LanguagesTestResult> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.LanguageTestResult).IsRequired();
        }
    }
}