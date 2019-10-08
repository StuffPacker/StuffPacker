using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Contract;
using StuffPacker.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker
{

    public class StuffPackingDbContextMigrator
    {
        public void Migrate(IServiceScope serviceScope, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                return;

            var optionsBuilder = new DbContextOptionsBuilder<StuffPackerDbContext>();
            optionsBuilder.UseSqlServer(connectionString);


            using (var stoConnectDbContext =
                new StuffPackerDbContext(optionsBuilder.Options, new CurrentMigratorUser()))
            {
                if (!stoConnectDbContext.AllMigrationsApplied())
                    stoConnectDbContext.Database.Migrate();
            }
        }
    }
    public class CurrentMigratorUser : ICurrentUser
    {
        public bool IsAuthenticated => throw new NotImplementedException();

        public Task<IEnumerable<FriendViewModel>> GetFriends()
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> GetProfile()
        {
            throw new NotImplementedException();
        }

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

        public void SetFriends(IEnumerable<FriendViewModel> friends)
        {
            throw new NotImplementedException();
        }

        public void SetProfile(UserProfile profile)
        {
            throw new NotImplementedException();
        }
    }
}
