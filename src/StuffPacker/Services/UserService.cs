using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Contract;
using StuffPacker.Mapper;
using StuffPacker.Persistence.Model;
using StuffPacker.Persistence.Repository;
using StuffPacker.ViewModel;

namespace StuffPacker.Services
{
    public class UserService : IUserService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMemberMapper _memberMapper;
        private readonly IFollowRepository _followRepository;
        private readonly IFollowMapper _followMapper;
        
        public UserService(IFriendRepository friendRepository, IUserProfileRepository userProfileRepository, IMemberMapper memberMapper, IFollowRepository followRepository, IFollowMapper followMapper)
        {
            _friendRepository = friendRepository;
            _userProfileRepository = userProfileRepository;
            _memberMapper = memberMapper;
            _followRepository = followRepository;
            _followMapper = followMapper;
        }

        public async Task<IEnumerable<FollowMemberViewModel>> GetFollowers(Guid userId)
        {
            var members = await this._followRepository.GetFollowers(userId);
            if (members == null)
            {
                members = new List<FollowModel>();
            }
            var following = await this._followRepository.GetFollowing(userId);
            if (following == null)
            {
                following = new List<FollowModel>();
            }
            return await _followMapper.Map(members,false,following.Select(x=>x.FollowUserId));

        }

        public async Task<IEnumerable<FollowMemberViewModel>> GetFollowing(Guid userId)
        {
            var members = await this._followRepository.GetFollowing(userId);
            if(members==null)
            {
                members = new List<FollowModel>();
            }
            return await _followMapper.Map(members,true,members.Select(x=>x.FollowUserId));
        }

        public async Task<IEnumerable<FriendViewModel>> GetFriends(Guid userId)
        {
            var friends = await _friendRepository.GetFriends(userId);
                return _memberMapper.Map(friends);
        }

        public async Task<UserProfile> GetUserProfile(Guid userId)
        {
            var userProfile = await this._userProfileRepository.Get(userId);
            if(userProfile == null)
            {
                await _userProfileRepository.Add(new Persistence.Model.UserProfileModel(new Persistence.Entity.UserProfileEntity { Id=userId,NickName="-"}));
            }
            userProfile = await this._userProfileRepository.Get(userId);
            return new UserProfile(userProfile.NickName,userProfile.FirstName,userProfile.LastName); 
        }
    }
}
