using System;
using System.Collections.Generic;
using AnalysisofKnowledge.Database.Entities.Interfaces;

namespace AnalysisofKnowledge.Database.Entities.Identity
{
    public abstract class ApplicationUser : User, IIdentityEntity
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
        
        public DateTimeOffset LastUpdateTime { get; set; }
    }
}