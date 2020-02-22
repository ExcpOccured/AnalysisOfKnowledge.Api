namespace AnalysisofKnowledge.Database.Entities.Interfaces
{
    public interface IStudent : IIdentityEntity
    {
        int GroupId { get; set; }
    }
}