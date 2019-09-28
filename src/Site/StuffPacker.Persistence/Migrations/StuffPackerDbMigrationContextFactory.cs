using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StuffPacker.Persistence.Migrations
{

    public class StuffPackerDbMigrationContextFactory : IDesignTimeDbContextFactory<StuffPackerDbContext>
    {
        public StuffPackerDbContext CreateDbContext(string[] args)
        {
            var migration_cs =
                "Server=tcp:hmeout=30;";

            var optionsBuilder = new DbContextOptionsBuilder<StuffPackerDbContext>();
            optionsBuilder.UseSqlServer(migration_cs);

            return new StuffPackerDbContext(optionsBuilder.Options);
        }
    }
}
