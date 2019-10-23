using Shared.Contract;
using StuffPacker.Mapper;
using StuffPacker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public class MemberService : IMemberService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IMemberMapper _memberMapper;
        private readonly IUserService _userService;
        public MemberService(ICurrentUser currentUser, IMemberMapper memberMapper, IUserService userService)
        {
            _currentUser = currentUser;
            _memberMapper = memberMapper;
            _userService = userService;
        }

        public async Task<IEnumerable<FriendViewModel>> GetFriends()
        {
            var friendsList= await _currentUser.GetFriends();
            if (friendsList != null)
            {
                return friendsList;
            }
            var friends = await _userService.GetFriends(_currentUser.GetUserId());
            _currentUser.SetFriends(friends);
            return friends;
        }

        public bool ItsMe(Guid userId)
        {
            if(_currentUser.GetUserId()==userId)
            {
                return true;
            }
            return false;
        }
    }
}
