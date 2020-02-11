using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shared.Contract;
using Shared.Contract.Dtos;
using Stuffpacker.Api.Client.ApiClient;
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
        private readonly IApiClient _apiClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IFriendRepository friendRepository, IUserProfileRepository userProfileRepository, IMemberMapper memberMapper, IFollowRepository followRepository, IFollowMapper followMapper, IApiClient apiClient, IHttpContextAccessor httpContextAccessor)
        {
            _friendRepository = friendRepository;
            _userProfileRepository = userProfileRepository;
            _memberMapper = memberMapper;
            _followRepository = followRepository;
            _followMapper = followMapper;
            _apiClient = apiClient;
            _httpContextAccessor = httpContextAccessor;
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
                await _userProfileRepository.Add(new Persistence.Model.UserProfileModel(new Persistence.Entity.UserProfileEntity { Id=userId,NickName="-",UserImgPath= "user.png" }));
            }
            userProfile = await this._userProfileRepository.Get(userId);
            return new UserProfile(userProfile.NickName,userProfile.FirstName,userProfile.LastName,userProfile.UserImgPath); 
        }

        public async Task<string> UpdateImg(Guid userId, string img)
        {
            await _apiClient.UpdateUserImg(userId, new UpdateUserImageDto { ImageName=img});
            return string.Empty;
        }

        public async Task<string> UpdateNames(Guid userId, UserViewModel model)
        {
            if(string.IsNullOrEmpty(model.NickName))
            {
                return "Nickname can not be empty!";
            }
           
            if(model.NickName!="-")
            {
                //check if nickname exist
                _apiClient.SetPrincipal(_httpContextAccessor.HttpContext.User);
                var user=await _apiClient.GetUserByNickName(model.NickName);
                if(user!=null && user.Id!=userId)
                {
                    return "NickName alrleady exist";
                }
            }
            var dto = new UpdateUserNamesDto
            {
                NickName=model.NickName,
                FirstName=model.FirstName,
                LastName=model.LastName
            };
            await _apiClient.UpdateUserNames(userId,dto);
            return string.Empty;
        }
    }
}
