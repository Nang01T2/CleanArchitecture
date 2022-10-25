using CleanArchitecture.Application;
using CleanArchitecture.Identity;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

[assembly: FunctionsStartup(typeof(CleanArchitecture.AzureFunction.Startup))]

/// <summary>
///     Startup class used to initialize the dependency injection.
/// </summary>
/// <remarks>
///     See: https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection
/// </remarks>
namespace CleanArchitecture.AzureFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = BuildConfiguration(builder.GetContext().ApplicationRootPath);

            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices(configuration);
            builder.Services.ConfigurePersistenceServices(configuration);
            builder.Services.ConfigureIdentityServices(configuration);
        }

        private IConfiguration BuildConfiguration(string applicationRootPath)
        {
            var config =
                new ConfigurationBuilder()
                    .SetBasePath(applicationRootPath)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

            return config;
        }
    }
}
