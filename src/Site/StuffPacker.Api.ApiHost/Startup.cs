using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Shared.Contract.Options;
using StuffPacker.Api.ApiHost.Configuration;
using StuffPacker.Api.ApiHost.Extensions;
using StuffPacker.Persistence;

namespace StuffPacker.Api.ApiHost
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private ILoggerFactory LoggerFactory { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public SiteOptions SiteOptions { get; set; }
        public virtual void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
        {
            SiteOptions=services.ConfigureSingletonIOption<SiteOptions>(Configuration,
             StuffPackerConfigurationOptionNames.SiteOptions);
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureOptions(services, Configuration);
            services.AddDbContext<StuffPackerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddStuffPackerApiHostServices(Configuration, LoggerFactory);
            var key = Encoding.ASCII.GetBytes(SiteOptions.ApiSecret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer("ApiBearer", x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
           
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
