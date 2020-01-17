using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Contract;
using Shared.Contract.Provider;
using Shared.Mail.Configuration;
using Shared.Mail.Options;
using Stuffpacker.Api.Client.Configuration;

using StuffPacker.Components.Personalize;
using StuffPacker.Mapper;
using StuffPacker.Persistence.Configuration;
using StuffPacker.Provider;
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
           
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFollowMapper, FollowMapper>();

            services.AddTransient<IMemberPersonalize, MemberPersonalize>();
            services.AddTransient<ICurrentUserProvider, CurrentUserProvider>();
            
            services.AddStuffPackerPersistence(configuration);

            services.AddScoped<IAccountService, AccountService>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<MailClientOptions>(configuration.GetSection("MailClientOptions"));
            services.AddSingleton<ITokenProvider, TokenProvider>();


            
            //Mappers
            services.AddScoped<IMemberMapper, MemberMapper>();
            services.AddScoped<IPackListMapper, PackListMapper>();
            



            services.AddSharedMail(configuration);
            services.AddStuffPackerApiClientServices(configuration,loggerFactory);
            return services;
        }
    }
}
