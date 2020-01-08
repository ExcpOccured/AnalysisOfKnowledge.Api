using System.ComponentModel.DataAnnotations.Schema;
using AnalysisofKnowledge.Database.Attributes;
using AnalysisofKnowledge.Database.Entities.Enum;
using AnalysisofKnowledge.Database.Entities.TestResults.Base;

namespace AnalysisofKnowledge.Database.Entities.TestResults
{
    [TestType(TestType.Reflexivity)]
    public class ReflexivityTestResult : BaseTestResult
    {
        public int Coefficient { get; set; }

        public DirectivityType ReflexivitiesTestResult { get; set; }

        [NotMapped]
        public override int Score
        {
            get => Coefficient;
            set => Coefficient = value;
        }
    }
}