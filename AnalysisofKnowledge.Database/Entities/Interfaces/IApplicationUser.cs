using System.Collections.Generic;
using AnalysisofKnowledge.Database.Entities.Identity;

namespace AnalysisofKnowledge.Database.Entities.Interfaces
{
    public interface IApplicationUser : IUser, IEntity
    {
        virtual ICollection<UserRole> UserRoles { get; }
    }
}