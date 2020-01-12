namespace AnalysisofKnowledge.Database.Entities.Interfaces
{
    public interface IStudent : IApplicationUser
    {
        int GroupId { get; set; }
    }
}