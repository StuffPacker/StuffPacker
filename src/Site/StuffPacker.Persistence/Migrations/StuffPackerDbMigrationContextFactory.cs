using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shared.Contract;

namespace StuffPacker.Persistence.Migrations
{

    public class StuffPackerDbMigrationContextFactory : IDesignTimeDbContextFactory<StuffPackerDbContext>
    {
        private readonly ICurrentUser _currentUser;
        public StuffPackerDbMigrationContextFactory(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public StuffPackerDbContext CreateDbContext(string[] args)
        {
            var migration_cs =
                "Server=tcp:hmeout=30;";

            var optionsBuilder = new DbContextOptionsBuilder<StuffPackerDbContext>();
            optionsBuilder.UseSqlServer(migration_cs);

            return new StuffPackerDbContext(optionsBuilder.Options,_currentUser);
        }
    }
}
