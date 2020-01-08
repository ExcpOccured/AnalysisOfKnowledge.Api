using AnalysisofKnowledge.Database.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class UserRole : IdentityUserRole<long>, IEntity
    {
        public long Id { get; set; }
        
        public virtual ApplicationRole Role { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}