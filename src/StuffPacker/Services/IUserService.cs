using Shared.Contract;
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
    }
}
