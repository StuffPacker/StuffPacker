using Shared.Contract;
using StuffPacker.Components.Personalize;
using StuffPacker.Mapper;
using StuffPacker.Persistence.Entity;
using StuffPacker.Persistence.Model;
using StuffPacker.Persistence.Repository;
using StuffPacker.ViewModel.Members;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace StuffPacker.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberMapper _memberMapper;
        private readonly IUserService _userService;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMemberPersonalize _memberPersonalize;
        private readonly IFollowRepository _followRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

        public MemberService(IMemberMapper memberMapper, IUserService userService, IUserProfileRepository userProfileRepository, IMemberPersonalize memberPersonalize, IFollowRepository followRepository, ICurrentUserProvider currentUserProvider)
        {

            _memberMapper = memberMapper;
            _userService = userService;
            _userProfileRepository = userProfileRepository;
            _memberPersonalize = memberPersonalize;
            _followRepository = followRepository;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<IEnumerable<FriendViewModel>> GetFriends()
        {
            return await _currentUserProvider.GetFriends();

        }

        public async Task<IEnumerable<MemberListItemViewModel>> GetMembers()
        {
            if (!_currentUserProvider.IsAuthenticated)
            {
                throw new AuthenticationException("Not logged in");
            }
            //get members
            var users = await this._userProfileRepository.Get();
            //map it
            var vms = await this._memberMapper.Map(users);
            //personalize it
            vms = await _memberPersonalize.Personalize(vms);

            return vms;
        }

        public async Task<bool> ItsMe(Guid userId)
        {
            if (_currentUserProvider.GetUserId == userId)
            {
                return true;
            }
            return false;
        }

        public async Task UnFollow(Guid UserId)
        {
            var currentUser = _currentUserProvider.GetUserId;
            var model = await this._followRepository.Get(currentUser, UserId);
            if (model == null)
            {
                throw new Exception("Cant find follow user");
            }
            await _followRepository.Delete(model);

            await this._currentUserProvider.ReloadFollowing();

        }

        public async Task Follow(Guid UserId)
        {
            var currentUser = _currentUserProvider.GetUserId;
            var model = new FollowModel(new FollowEntity
            {
                UserId = _currentUserProvider.GetUserId,
                FollowUserId = UserId,
                Id = Guid.NewGuid()
            }
            );
           
             await _followRepository.Add(model);

            await this._currentUserProvider.ReloadFollowing();

        }

    }
}
