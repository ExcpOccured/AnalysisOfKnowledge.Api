using System;
using System.Linq;
using System.Threading.Tasks;
using AnalysisofKnowledge.Api.Models.ServicesContractTypes;
using AnalysisofKnowledge.Database.Entities.Enum;
using AnalysisofKnowledge.Database.NpgSqlApplicationDbContext;
using AnalysisofKnowledge.Database.NpgSqlApplicationDbContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnalysisofKnowledge.Api.Domain.DefaultDataGenerators
{
    public class ApplicationDbGenerator : IDefaultDataGenerator
    {
        public long OrderId => 0;
        
        public async Task GenerateInitialData(IServiceScope serviceScope)
        {
            var dbContext = serviceScope.ServiceProvider.GetService<IApplicationDbContext>();

            await dbContext.Database.MigrateAsync();

            await GenerateRoles(dbContext);
        }

        private async Task GenerateRoles(IIdentityApplicationDbContext applicationDbContext)
        {
            var identityRoles = await applicationDbContext.UserRoles.ToDictionaryAsync(role => role.Id, 
                role => role);

            foreach (var roleType in Enum.GetValues(typeof(RoleType)))
            {
                if (identityRoles.All(pair => pair.Value.Role != roleType))
                {
                    var nameLower = roleType;
                }
            }
        }
    }
}