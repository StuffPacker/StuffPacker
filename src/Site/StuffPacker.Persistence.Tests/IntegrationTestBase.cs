using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StuffPacker.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace StuffPacker.Persistence.Tests
{
   
    public class IntegrationTestBase
    {
        private readonly Lazy<IServiceProvider> _buildServiceProvider;

        public IntegrationTestBase()
        {
            Services = new ServiceCollection();

            var databaseName = "StuffPAckerPersistenceSetup-" + Guid.NewGuid();
            var testConnection = $"Server=(localdb)\\mssqllocaldb;Database={databaseName};Trusted_Connection=True;";

            var builder = new ConfigurationBuilder().AddInMemoryCollection(new[]
            {
                    new KeyValuePair<string, string>("StuffPAckerConnectionStringName", "cs"),
                    new KeyValuePair<string, string>("ConnectionStrings:cs", testConnection)
                });



            Services.AddSingleton(ManagedContext.Initializer());
           
            Services.AddScoped<IServiceProviderFactory>(p => new TestServiceProviderFactory(p));
            //Services.AddScoped(typeof(ILogger<>), typeof(Logger<>));
            var configuration = builder.Build();
            Services.AddStuffPackerPersistence(configuration);



            new StuffPackerDbContextMigrator().Migrate(null,
                testConnection);


            _buildServiceProvider = new Lazy<IServiceProvider>(() =>
            {
                var defaultServiceProviderFactory = new DefaultServiceProviderFactory();
                var serviceCollection = defaultServiceProviderFactory.CreateBuilder(Services);
                return serviceCollection.BuildServiceProvider();
            });
        }

        public IServiceProvider BuildServiceProvider => _buildServiceProvider.Value;

        public ServiceCollection Services { get; }
    }

}
