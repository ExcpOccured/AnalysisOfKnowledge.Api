using System.Reflection;
using AnalysisofKnowledge.Api.Domain.Constants;
using AnalysisofKnowledge.Api.Domain.Models.ServicesContractTypes;
using AnalysisofKnowledge.Database;
using AnalysisofKnowledge.Database.NpgSqlApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnalysisofKnowledge.Api.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static Assembly CurrentExecutionAssembly => Assembly.GetExecutingAssembly();

        public static void RegisterServices(this IServiceCollection services)
        {
            services.RegisterAllScopedServices();
            services.RegisterAllSingletonServices();
            services.RegisterAllTransientServices();
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
            services.Scan(scan => scan.FromAssemblies(CurrentExecutionAssembly)
                .AddClasses(classes => classes.AssignableTo<IScopedService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }

        // Register all singleton services via base ISingletonService interface
        private static void RegisterAllSingletonServices(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblies(CurrentExecutionAssembly)
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());
        }
        
        // Register all singleton services via base ITransient interface
        private static void RegisterAllTransientServices(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblies(CurrentExecutionAssembly)
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                .AsImplementedInterfaces()
                .WithTransientLifetime());
        }
    }
}