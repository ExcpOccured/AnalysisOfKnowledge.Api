using Microsoft.EntityFrameworkCore;

namespace AnalysisofKnowledge.Database.Entities.TestResults.Points
{
    [Owned]
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