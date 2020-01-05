using System.ComponentModel.DataAnnotations.Schema;
using AnalysisofKnowledge.Database.Attributes;
using AnalysisofKnowledge.Database.Entities.Enum;
using AnalysisofKnowledge.Database.Entities.TestResults.Points;

namespace AnalysisofKnowledge.Database.Entities.TestResults
{
    [TestType(TestType.Activity)]
    public class ActivityTestResult : BaseTestResult
    {
        public int Coefficient { get; set; }

        public ActivityTestPoints Points { get; set; }
        
        public OctantType OctantType { get; set; }

        [NotMapped]
        public override int Score
        {
            get => Coefficient;
            set => Coefficient = value;
        }
    }
}