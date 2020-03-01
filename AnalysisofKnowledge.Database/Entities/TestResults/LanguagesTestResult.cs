using System.ComponentModel.DataAnnotations.Schema;
using AnalysisofKnowledge.Database.Attributes;
using AnalysisofKnowledge.Database.Entities.Enum;
using AnalysisofKnowledge.Database.Entities.TestResults.Base;

namespace AnalysisofKnowledge.Database.Entities.TestResults
{
    [TestType(TestType.Languages)]
    public class LanguagesTestResult : BaseTestResult
    {
        public int Coefficient { get; set; }
        public LanguageLevel LanguageTestResult { get; set; }

        [NotMapped]
        public override int Score
        {
            get => Coefficient;
        }
    }
}