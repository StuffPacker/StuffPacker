using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Contract;
using StuffPacker.Mapper;
using StuffPacker.Persistence.Repository;

namespace StuffPacker.Services
{
    public class UserService : IUserService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMemberMapper _memberMapper;
        
        public UserService(IFriendRepository friendRepository, IUserProfileRepository userProfileRepository, IMemberMapper memberMapper)
        {
            _friendRepository = friendRepository;
            _userProfileRepository = userProfileRepository;
            _memberMapper = memberMapper;
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
            return new UserProfile(userProfile.NickName); 
        }
    }
}
