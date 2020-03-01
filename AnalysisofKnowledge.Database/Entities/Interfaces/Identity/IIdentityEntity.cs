using System.Collections.Generic;
using AnalysisofKnowledge.Database.Entities.Identity;

namespace AnalysisofKnowledge.Database.Entities.Interfaces.Identity
{
    public interface IIdentityEntity : IEntity
    {
        ICollection<UserRole> UserRoles { get; }

        string FullName { get; }
    }
}