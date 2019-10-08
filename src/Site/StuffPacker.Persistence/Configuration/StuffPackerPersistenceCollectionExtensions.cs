using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StuffPacker.Persistence.Repository;
using StuffPacker.Repositories;
namespace StuffPacker.Persistence.Configuration
{
    public static class StuffPackerPersistenceCollectionExtensions
    {
        public static IServiceCollection AddStuffPackerPersistence(this IServiceCollection services,
           IConfiguration configuration)
        {


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPackListsRepository, PackListsRepository>();
            services.AddScoped<IPersonalizedProductRepository, PersonalizedProductRepository>();
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();


       
            
            return services;
        }
    }
}
