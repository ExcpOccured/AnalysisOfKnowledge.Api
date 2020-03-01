using AnalysisofKnowledge.Database.Entities.Base;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class Faculty : Entity
    {
        public long StudentId { get; set; }
        public long TeacherId { get; set; }

        public string Description { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}