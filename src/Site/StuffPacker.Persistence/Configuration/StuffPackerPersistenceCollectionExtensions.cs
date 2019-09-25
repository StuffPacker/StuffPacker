using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace StuffPacker.Persistence.Configuration
{
    public static class StuffPackerPersistenceCollectionExtensions
    {
        public static IServiceCollection AddStuffPackerPersistence(this IServiceCollection services,
           IConfiguration configuration)
        {
            var servicesToRet = services;           
            return servicesToRet;
        }
    }
}
