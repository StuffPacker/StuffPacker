using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contract
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }

        string GetUserName();

        Guid GetUserId();

        UserType GetUserType();

        Task<IEnumerable<FriendViewModel>> GetFriends();

        Task<UserProfile> GetProfile();
        void SetFriends(IEnumerable<FriendViewModel> friends);
        void SetProfile(UserProfile profile);

       IEnumerable<FollowMemberViewModel> GetFollowing();
        void SetFollowing(List<FollowMemberViewModel> members);
        IEnumerable<FollowMemberViewModel> GetFollowers();
        void SetFollowers(List<FollowMemberViewModel> members);
    }
}
