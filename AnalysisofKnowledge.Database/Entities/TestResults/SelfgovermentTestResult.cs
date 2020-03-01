using System.ComponentModel.DataAnnotations.Schema;
using AnalysisofKnowledge.Database.Attributes;
using AnalysisofKnowledge.Database.Entities.Enum;
using AnalysisofKnowledge.Database.Entities.TestResults.Base;

namespace AnalysisofKnowledge.Database.Entities.TestResults
{
    [TestType(TestType.Selfgovernment)]
    public class SelfgovermentTestResult : BaseTestResult
    {
        public int Coefficient { get; set; }

        [NotMapped]
        public override int Score
        {
            get => Coefficient;
        }
    }
}