using System.Collections.Generic;
using AnalysisofKnowledge.Database.Entities.Identity;

namespace AnalysisofKnowledge.Database.Entities.Interfaces.Identity
{
    public interface IApplicationUser : IUser, IEntity
    {
        ICollection<UserRole> UserRoles { get; }
    }
}