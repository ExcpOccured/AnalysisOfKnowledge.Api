using AnalysisofKnowledge.Api.Domain.Constants;
using AnalysisofKnowledge.Api.Models.ServicesContractTypes;
using AnalysisofKnowledge.Database;
using AnalysisofKnowledge.Database.NpgSqlApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnalysisofKnowledge.Api.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.RegisterAllScopedServices();
            services.RegisterAllSingletonServices();
        }

        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString(ConnectionString.SelectorName)));

            services.AddScoped<IApplicationDbContext, AppDbContext>();
        }

        // Register all scoped services via base IScopedService interface
        private static void RegisterAllScopedServices(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblyOf<IScopedService>()
                .AddClasses(classes => classes.AssignableTo<IScopedService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }

        // Register all singleton services via base ISingletonService interface
        private static void RegisterAllSingletonServices(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblyOf<ISingletonService>()
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}