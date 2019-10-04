using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shared.Contract;

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

            return new StuffPackerDbContext(optionsBuilder.Options,new CurrentMigrationUser());
        }
    }
    public class CurrentMigrationUser : ICurrentUser
    {
        public bool IsAuthenticated => false;

        public Guid GetUserId()
        {
           return Guid.Empty;
        }

        public string GetUserName()
        {
            return "Migrator";
        }

        public UserType GetUserType()
        {
            return UserType.System;
        }
    }
}
