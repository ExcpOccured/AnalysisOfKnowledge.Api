using System.ComponentModel.DataAnnotations.Schema;
using AnalysisofKnowledge.Database.Attributes;
using AnalysisofKnowledge.Database.Entities.Enum;
using AnalysisofKnowledge.Database.Entities.TestResults.Base;
using AnalysisofKnowledge.Database.Entities.TestResults.Points;

namespace AnalysisofKnowledge.Database.Entities.TestResults
{
    [TestType(TestType.Activity)]
    public class ActivityTestResult : BaseTestResult
    {
        public ActivityTestPoints Points { get; set; }
        public OctantType ActivityTestsResult { get; set; }
        private int Coefficient { get; set; }

        [NotMapped]
        public override int Score
        {
            get => Coefficient;
            set => Coefficient = value;
        }
    }
}