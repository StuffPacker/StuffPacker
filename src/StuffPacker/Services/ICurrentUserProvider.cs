using Shared.Contract;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public interface ICurrentUserProvider
    {
        Guid GetUserId { get; }
        bool IsAuthenticated { get; }

        Task<UserProfile> GetProfile();
        Task<IEnumerable<FollowMemberViewModel>> GetFollowing();

        Task<IEnumerable<FollowMemberViewModel>> GetFollowers();
        Task<IEnumerable<FriendViewModel>> GetFriends();
        Task ReloadFollowing();
        Task ReloadFollowers();
    }
}
