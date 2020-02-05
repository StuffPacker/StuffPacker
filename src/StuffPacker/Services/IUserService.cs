using Shared.Contract;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public interface IUserService
    {
        Task<IEnumerable<FriendViewModel>> GetFriends(Guid guid);
        Task<UserProfile> GetUserProfile(Guid guid);

        Task<IEnumerable<FollowMemberViewModel>> GetFollowing(Guid userId);
        Task<IEnumerable<FollowMemberViewModel>> GetFollowers(Guid userId);

        Task<string> UpdateNames(Guid userId,UserViewModel model);
    }
}
