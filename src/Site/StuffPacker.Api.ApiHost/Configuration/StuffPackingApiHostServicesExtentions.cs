using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Contract;
using Stuffpacker.Api.Configuration;

namespace StuffPacker.Api.ApiHost.Configuration
{

    public static class StuffPackingApiHostServicesExtentions
    {
        public static IServiceCollection AddStuffPackerApiHostServices(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddStuffPackerApiServices(configuration, loggerFactory);
            return services;
        }
    }
}
