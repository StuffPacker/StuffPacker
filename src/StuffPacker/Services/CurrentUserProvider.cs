using Shared.Contract;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public class CurrentUserProvider : ICurrentUserProvider
    {

        private readonly IUserService _userService;
        private readonly ICurrentUser _currentUser;
        public CurrentUserProvider(IUserService userService, ICurrentUser currentUser)
        {
            _userService = userService;
            _currentUser = currentUser;
        }

        public Guid GetUserId => _currentUser.GetUserId();

        public bool IsAuthenticated => _currentUser.IsAuthenticated;

        public async Task<IEnumerable<FollowMemberViewModel>> GetFollowing()
        {
            if (_currentUser.GetFollowing() == null)
            {
                var members = await this._userService.GetFollowing(_currentUser.GetUserId());
                _currentUser.SetFollowing(members.ToList());
            }
            return _currentUser.GetFollowing().ToList();

        }

        public async Task<IEnumerable<FollowMemberViewModel>> GetFollowers()
        {

            if (_currentUser.GetFollowers() == null)
            {
                var members = await this._userService.GetFollowers(_currentUser.GetUserId());
                _currentUser.SetFollowers(members.ToList());
            }
            return  _currentUser.GetFollowers().ToList();
           
        }

        public async Task<UserProfile> GetProfile()
        {
            var userProfile = await _currentUser.GetProfile();

            if (userProfile == null)
            {
                var profile = await _userService.GetUserProfile(_currentUser.GetUserId());
                userProfile = profile;
                _currentUser.SetProfile(userProfile);
            }

            return userProfile;
        }

        public async Task<IEnumerable<FriendViewModel>> GetFriends()
        {

            var friendsList = await this._currentUser.GetFriends();

            if (friendsList != null)
            {
                return friendsList;
            }
            var friends = await _userService.GetFriends(_currentUser.GetUserId());
            _currentUser.SetFriends(friends);
            return friends;
        }

        public async Task ReloadFollowing()
        {
            var members = await this._userService.GetFollowing(_currentUser.GetUserId());
            _currentUser.SetFollowing(members.ToList());
        }

        public async Task ReloadFollowers()
        {
            var members = await this._userService.GetFollowers(_currentUser.GetUserId());
            _currentUser.SetFollowers(members.ToList());
        }
    }
}
