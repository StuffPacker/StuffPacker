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


            //services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient<IPackListsRepository, PackListsRepository>();
            //services.AddTransient<IPersonalizedProductRepository, PersonalizedProductRepository>();
            //services.AddTransient<IFriendRepository, FriendRepository>();
            //services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            //services.AddTransient<IFollowRepository, FollowRepository>();
            //services.AddTransient<IProductGroupRepository, ProductGroupRepository>();



            return services;
        }
    }
}
