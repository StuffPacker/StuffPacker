using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Contract;
using StuffPacker.Api.ApiHost.Controllers;
using StuffPacker.Persistence.Configuration;

namespace StuffPacker.Api.ApiHost.Configuration
{

    public static class StuffPackingApiHostServicesExtentions
    {
        public static IServiceCollection AddStuffPackerApiHostServices(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IPackListService, PackListService>();
             services.AddStuffPackerPersistence(configuration);
            return services;
        }
    }
}
