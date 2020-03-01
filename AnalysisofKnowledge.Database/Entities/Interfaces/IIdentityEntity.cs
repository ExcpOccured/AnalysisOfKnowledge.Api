using System.Collections.Generic;
using AnalysisofKnowledge.Database.Entities.Identity;

namespace AnalysisofKnowledge.Database.Entities.Interfaces
{
    public interface IIdentityEntity : IEntity
    {
        virtual ICollection<UserRole> UserRoles { get; set; }

        string FullName { get; }
    }
}