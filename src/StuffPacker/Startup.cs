using Blazor.Fluxor;
using EmbeddedBlazorContent;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StuffPacker.Configuration;
using StuffPacker.Persistence;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Mail.Options;
using Shared.Contract.Options;
using StuffPacker.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Polly;
using Polly.Extensions.Http;

namespace StuffPacker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //Force Migration
            var migrationConnection =
                Configuration.GetConnectionString("DefaultConnection");
            new StuffPackingDbContextMigrator().Migrate(null, migrationConnection);
        }
        public virtual void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureSingletonIOption<SiteOptions>(Configuration,StuffPackerConfigurationOptionNames.SiteOptions);
            services.ConfigureSingletonIOption<StorageOptions>(Configuration, StuffPackerConfigurationOptionNames.StorageOptions);
            
        }
        public IConfiguration Configuration { get; }
        private ILoggerFactory LoggerFactory { get; }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.Conflict)
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromMilliseconds(Math.Pow(200, retryAttempt)));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureOptions(services, Configuration);
            services.AddScoped<HttpClient>();
            
          

            services.AddDbContext<StuffPackerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options=> 
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;                
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                
                

            }).AddEntityFrameworkStores<StuffPackerDbContext>();

            services.AddHttpClient("ApiClient").SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(GetRetryPolicy());


            services.AddRazorPages();
            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
            services.AddStuffPackerServices(Configuration, LoggerFactory);
            services.AddHttpClient();
            services.AddFluxor(options =>
            {
                options.UseDependencyInjection(typeof(Startup).Assembly);
            });
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEmbeddedBlazorContent(typeof(MatBlazor.BaseMatComponent).Assembly);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapAreaControllerRoute(
           "api",
           "api",
           "api/{controller=test}/{action=Index}/{id?}");
            });

        }
    }
}
