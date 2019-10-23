using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shared.Contract;
using StuffPacker.ViewModel;

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

        public IEnumerable<FollowMemberViewModel> GetFollowers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FollowMemberViewModel> GetFollowing()
        {
            throw new NotImplementedException();
        }

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

        public void SetFollowers(List<FollowMemberViewModel> members)
        {
            throw new NotImplementedException();
        }

        public void SetFollowing(List<FollowMemberViewModel> members)
        {
            throw new NotImplementedException();
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
