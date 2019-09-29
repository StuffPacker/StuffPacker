using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StuffPacker.Mapper;
using StuffPacker.Persistence.Configuration;
using StuffPacker.Repositories;
using StuffPacker.Services;

namespace StuffPacker.Configuration
{
    public static class StuffPackingServicesExtentions
    {
        public static IServiceCollection AddStuffPackerServices(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            services.AddScoped<IPackListService, PackListService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IProductMapper, ProductMapper>();
            
            services.AddStuffPackerPersistence(configuration);
            return services;
        }
    }
}
