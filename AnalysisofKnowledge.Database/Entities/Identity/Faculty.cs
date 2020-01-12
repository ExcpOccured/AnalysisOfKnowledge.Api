using AnalysisofKnowledge.Database.Entities.Base;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class Faculty : Entity
    {
        public virtual Student Student { get; set; }

        public virtual Teacher Teacher { get; set; }

        public long StudentId { get; set; }

        public long TeacherId { get; set; }

        public string Description { get; set; }
    }
}