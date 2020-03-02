using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Contract;
using StuffPacker.Api.ApiHost.Controllers;
using StuffPacker.Api.ApiHost.Mapper;
using StuffPacker.Api.ApiHost.Services;
using StuffPacker.Persistence.Configuration;

namespace StuffPacker.Api.ApiHost.Configuration
{

    public static class StuffPackingApiHostServicesExtentions
    {
        public static IServiceCollection AddStuffPackerApiHostServices(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            //Services
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IPackListService, PackListService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IProductService, ProductService>();

            //Mappers
            services.AddScoped<IProductMapper,ProductMapper>();


            services.AddStuffPackerPersistence(configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}
