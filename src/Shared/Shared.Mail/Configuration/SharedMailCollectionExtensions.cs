using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mail.Configuration
{
   
    public static class SharedMailCollectionExtensions
    {
        public static IServiceCollection AddSharedMail(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IMailClient, GmailClient>();
            services.AddSingleton<ISendMail, SendMail>();

            return services;
        }
    }
}
