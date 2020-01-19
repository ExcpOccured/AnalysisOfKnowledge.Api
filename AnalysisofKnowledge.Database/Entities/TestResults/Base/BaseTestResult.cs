using AnalysisofKnowledge.Database.Entities.Base;
using AnalysisofKnowledge.Database.Entities.Interfaces;

namespace AnalysisofKnowledge.Database.Entities.TestResults.Base
{
    public abstract class BaseTestResult : Entity, IBaseTestResult
    {
        public abstract int Score { get; set; }
    }
}