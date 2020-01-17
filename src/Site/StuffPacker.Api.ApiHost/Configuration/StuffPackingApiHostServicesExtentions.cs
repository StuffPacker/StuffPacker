using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Contract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Configuration
{
    
    public static class StuffPackingApiHostServicesExtentions
    {
        public static IServiceCollection AddStuffPackerApiHostServices(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            services.AddScoped<ICurrentUser, CurrentUser>();
           // services.AddStuffPackerApiServices(configuration, loggerFactory);
            return services;
        }
    }
}
