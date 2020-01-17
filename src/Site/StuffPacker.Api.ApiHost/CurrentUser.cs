using Shared.Contract;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost
{
    public class CurrentUser : ICurrentUser
    {
        public bool IsAuthenticated => throw new NotImplementedException();

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
            throw new NotImplementedException();
        }

        public string GetUserName()
        {
            throw new NotImplementedException();
        }

        public UserType GetUserType()
        {
            throw new NotImplementedException();
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
