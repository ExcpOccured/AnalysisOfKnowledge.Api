using System.ComponentModel.DataAnnotations.Schema;
using AnalysisofKnowledge.Database.Attributes;
using AnalysisofKnowledge.Database.Entities.Enum;
using AnalysisofKnowledge.Database.Entities.TestResults.Base;

namespace AnalysisofKnowledge.Database.Entities.TestResults
{
    [TestType(TestType.Reflexivity)]
    public class ReflexivityTestResult : BaseTestResult
    {
        public DirectivityType ReflexivityTestResults { get; set; }
        private int Coefficient { get; set; }

        [NotMapped]
        public override int Score
        {
            get => Coefficient;
            set => Coefficient = value;
        }
    }
}