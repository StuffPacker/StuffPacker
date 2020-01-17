using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stuffpacker.Api.Services;


namespace Stuffpacker.Api.Configuration
{
    public static class StuffPackingApiServicesExtentions
    {
        public static IServiceCollection AddStuffPackerApiServices(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
        {//services
            services.AddScoped<IPackListService, PackListService>();
            
            //projects
            //services.AddStuffPackerPersistence(configuration);
            return services;
        }
    }
}
