using AnalysisofKnowledge.Database.Entities.Interfaces.Base;
using Microsoft.AspNetCore.Identity;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class UserClaim : IdentityUserClaim<long>, IEntity<int> { }
}