using AnalysisofKnowledge.Database.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace AnalysisofKnowledge.Database.NpgSqlApplicationDbContext.Interfaces
{
    public interface IIdentityApplicationDbContext
    {
        DbSet<UserRole> UserRoles { get; }
    }
}