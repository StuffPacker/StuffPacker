using Microsoft.AspNetCore.Http;
using Shared.Contract;
using StuffPacker.Services;
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
        private IEnumerable<FriendViewModel> FriendsList;
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
                if (string.IsNullOrEmpty(UserName) && IsAuthenticated)
                {
                    return Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                return Guid.Empty;
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
    }
}
