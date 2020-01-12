namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class Teacher : ApplicationUser
    {
        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }

        private string Education { get; set; }
    }
}