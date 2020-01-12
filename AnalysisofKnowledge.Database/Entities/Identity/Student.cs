using AnalysisofKnowledge.Database.Entities.Interfaces;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class Student : ApplicationUser, IStudent
    {
        public int GroupId { get; set; }

        public long FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}