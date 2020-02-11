using Shared.Contract.Dtos;
using StuffPacker.Persistence.Model;
using StuffPacker.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public ProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
        public async Task<UserProfileModel> GetByNickName(string nickname)
        {
            var result = await _userProfileRepository.GetByNickName(nickname);
            
            return result;
        }

        public async Task UpdateImg(Guid userId, string img)
        {
            var model = await _userProfileRepository.Get(userId);
            model.UpdateImg(img);
            await _userProfileRepository.Update(model);
        }

        public async Task UpdateNames(Guid userId, UpdateUserNamesDto dto)
        {
            var model = await _userProfileRepository.Get(userId);
            model.UpdateNames(dto.NickName,dto.FirstName,dto.LastName);
            await _userProfileRepository.Update(model);
        }
    }
}
