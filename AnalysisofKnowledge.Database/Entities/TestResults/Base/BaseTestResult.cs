using AnalysisofKnowledge.Database.Entities.Base;
using AnalysisofKnowledge.Database.Entities.Interfaces;
using AnalysisofKnowledge.Database.Entities.Interfaces.TestResults;

namespace AnalysisofKnowledge.Database.Entities.TestResults.Base
{
    public abstract class BaseTestResult : Entity, IBaseTestResult
    {
        // Allow to implement test base Score validator 
        public abstract int Score { get; set; }
    }
}