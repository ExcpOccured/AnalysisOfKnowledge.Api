using System.Threading.Tasks;
using AnalysisofKnowledge.Database.Entities.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AnalysisofKnowledge.Api.Models.ServicesContractTypes
{
    /// <summary>
    /// Interface for initializing data after the initial launch of the app
    /// </summary>
    public interface IDefaultDataGenerator : IHasOrder
    {
        Task GenerateInitialData(IServiceScope serviceScope);
    }
}