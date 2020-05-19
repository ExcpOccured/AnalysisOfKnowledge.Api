using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace AnalysisofKnowledge.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}", optional: true,
                            reloadOnChange: true)
                        .AddEnvironmentVariables();
                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    if (!context.HostingEnvironment.IsDevelopment() && !context.HostingEnvironment.IsStaging()) return;
                    logging.AddFilter("System", LogLevel.Debug)
                        .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>());
    }
}