using AnalysisofKnowledge.Database.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class UserClaim : IdentityUserClaim<long>, IEntity 
    {
        public new long Id { get; set; }
    }
}