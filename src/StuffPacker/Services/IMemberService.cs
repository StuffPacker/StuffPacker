using Shared.Contract;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public interface IMemberService
    {
        bool ItsMe(Guid userId);

        Task<IEnumerable<FriendViewModel>> GetFriends();
    }
}
