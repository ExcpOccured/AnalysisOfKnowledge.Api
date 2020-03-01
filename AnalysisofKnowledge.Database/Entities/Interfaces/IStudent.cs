namespace AnalysisofKnowledge.Database.Entities.Interfaces
{
    public interface IStudent : IIdentityEntity
    {
        long GroupId { get; set; }
    }
}