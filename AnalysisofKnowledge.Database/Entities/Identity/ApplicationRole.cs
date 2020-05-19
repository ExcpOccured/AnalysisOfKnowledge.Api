using System.Collections.Generic;
using AnalysisofKnowledge.Database.Entities.Enum;
using AnalysisofKnowledge.Database.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public class ApplicationRole : IdentityRole<long>, IEntity
    {
        public RoleType RoleType { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}