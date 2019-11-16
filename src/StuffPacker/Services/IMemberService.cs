using Shared.Contract;
using StuffPacker.ViewModel.Members;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public interface IMemberService
    {
       Task <bool> ItsMe(Guid userId);

        Task<IEnumerable<FriendViewModel>> GetFriends();

        Task<IEnumerable<MemberListItemViewModel>> GetMembers();

        Task UnFollow(Guid UserId);
        Task Follow(Guid UserId);
    }
}
