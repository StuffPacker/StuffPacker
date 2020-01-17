using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stuffpacker.Api.Client.ApiClient;

namespace Stuffpacker.Api.Client.Configuration
{
    public static class StuffPackingApiClientServicesExtentions
    {
        public static IServiceCollection AddStuffPackerApiClientServices(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            services.AddTransient<IApiClient, ApiClient.ApiClient>();
            services.AddTransient<IApiAuthClientFactory, ApiClient.ApiAuthClientFactory>();

            return services;
        }
    }
}
