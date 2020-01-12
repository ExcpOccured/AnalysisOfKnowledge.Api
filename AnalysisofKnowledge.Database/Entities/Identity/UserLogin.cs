using AnalysisofKnowledge.Database.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class UserLogin : IdentityUserLogin<long>, IEntity
    {
        public long Id { get; set; }
    }
}