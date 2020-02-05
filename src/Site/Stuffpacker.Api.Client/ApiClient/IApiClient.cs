using Shared.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Stuffpacker.Api.Client.ApiClient
{
    public interface IApiClient
    {
        Task<IEnumerable<PackListDto>> GetPackLists();
        void SetPrincipal(ClaimsPrincipal user);
        Task UpdatePackListMaximized(Guid listId, bool maximized);
        Task UpdatePackListVisibleList(Dictionary<Guid, bool> visibleList);
        Task<ProfileDto> GetUserByNickName(string nickName);
        Task UpdateUserNames(Guid userId, UpdateUserNamesDto dto);
    }
}
