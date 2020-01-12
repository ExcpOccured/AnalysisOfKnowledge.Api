using System.ComponentModel.DataAnnotations.Schema;

namespace AnalysisofKnowledge.Database.Entities.TestResults.Points
{
    [ComplexType]
    public class ActivityTestPoints
    {
        public int PointsInPowerfulLeading { get; set; }

        public int PointsInIndependentDominant { get; set; }

        public int PointsInStraightforwardAggressive { get; set; }

        public int PointsInIncredulousSkeptical { get; set; }

        public int PointsInObedientlyShy { get; set; }

        public int PointsInDependentObedient { get; set; }

        public int PointsInCooperatingConventional { get; set; }

        public int PointsInResponsibleGenerous { get; set; }
    }
}