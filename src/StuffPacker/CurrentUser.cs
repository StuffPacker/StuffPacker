using Microsoft.AspNetCore.Http;
using Shared.Contract;
using System;
using System.Security.Claims;

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

        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public string GetUserName()
        {
            if (string.IsNullOrEmpty(UserName) && IsAuthenticated)
            {
                return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            }
            return "";
        }

        public UserType GetUserType()
        {
            throw new NotImplementedException();
        }
    }
}
