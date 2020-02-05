using Shared.Contract.Dtos;
using StuffPacker.Persistence.Model;
using System;
using System.Threading.Tasks;

namespace StuffPacker.Api.ApiHost.Services
{
    public interface IProfileService
    {
        Task<UserProfileModel> GetByNickName(string nickname);
        Task UpdateNames(Guid userId, UpdateUserNamesDto dto);
    }
}
