using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static T ConfigureSingleton<T>(this IServiceCollection services, IConfiguration configuration,
            string section)
        {
            var typeInstantiated = Activator.CreateInstance<T>();
            configuration.GetSection(section).Bind(typeInstantiated);
            services.AddSingleton(typeof(T), typeInstantiated);

            return typeInstantiated;
        }

        public static T ConfigureSingletonIOption<T>(this IServiceCollection services, IConfiguration configuration,
            string section) where T : class, new()
        {
            Console.WriteLine("Load config for:" + section);
            var typeInstantiated = Activator.CreateInstance<T>();
            configuration.GetSection(section).Bind(typeInstantiated);
            services.AddSingleton(Microsoft.Extensions.Options.Options.Create(typeInstantiated));

            return typeInstantiated;
        }
    }
}
