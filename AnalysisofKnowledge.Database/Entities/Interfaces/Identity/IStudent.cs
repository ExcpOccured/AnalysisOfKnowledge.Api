namespace AnalysisofKnowledge.Database.Entities.Interfaces.Identity
{
    public interface IStudent : IIdentityEntity
    {
        long GroupId { get; set; }
    }
}