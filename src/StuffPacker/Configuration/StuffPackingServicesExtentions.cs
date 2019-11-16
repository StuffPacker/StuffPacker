using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Contract;
using StuffPacker.Components.Personalize;
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
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IMemberMapper, MemberMapper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFollowMapper, FollowMapper>();

            services.AddTransient<IMemberPersonalize, MemberPersonalize>();
            services.AddTransient<ICurrentUserProvider, CurrentUserProvider>();
            
            services.AddStuffPackerPersistence(configuration);
            return services;
        }
    }
}
