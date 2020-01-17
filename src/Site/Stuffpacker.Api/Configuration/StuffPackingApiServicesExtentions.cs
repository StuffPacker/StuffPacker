using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;



namespace Stuffpacker.Api.Configuration
{
    public static class StuffPackingApiServicesExtentions
    {
        public static IServiceCollection AddStuffPackerApiServices(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
        {//services
           
            
            //projects
            //services.AddStuffPackerPersistence(configuration);
            return services;
        }
    }
}
