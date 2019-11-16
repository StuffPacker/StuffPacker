using Microsoft.AspNetCore.Http;
using Shared.Contract;
using StuffPacker.Services;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StuffPacker
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private string UserName;
        private Guid userId;
        private IEnumerable<FriendViewModel> FriendsList;
        private List<FollowMemberViewModel> Following;
        private List<FollowMemberViewModel> Followers;
        private UserProfile UserProfile;

        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public string GetUserName()
        {
            if (string.IsNullOrEmpty(UserName) && IsAuthenticated)
            {
                
                var n= _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                UserName = n;
                return n;
            }
            return "";
        }

        public UserType GetUserType()
        {
            return UserType.User;
        }

        public Guid GetUserId()
        {
            try
            {
                if ((userId==null || userId==Guid.Empty) && IsAuthenticated)
                {
                    var id= Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    userId = id;
                    return id;
                }
                return userId;
            }
            catch (Exception)
            {

                return Guid.Empty;
            }

           
        }

        public async Task<IEnumerable<FriendViewModel>> GetFriends()
        {
            return FriendsList;

          
        }

        public async Task<UserProfile> GetProfile()
        {
            return UserProfile;           
        }

        public void SetFriends(IEnumerable<FriendViewModel> friends)
        {
            FriendsList = friends;
        }

        public void SetProfile(UserProfile profile)
        {
            UserProfile = profile;
        }

        public IEnumerable<FollowMemberViewModel> GetFollowing()
        {
            return Following;
        }

        public void SetFollowing(List<FollowMemberViewModel> members)
        {
            Following = members;
        }

        public IEnumerable<FollowMemberViewModel> GetFollowers()
        {
            return Followers;
        }

        public void SetFollowers(List<FollowMemberViewModel> members)
        {
            Followers = members;
        }
    }
}
