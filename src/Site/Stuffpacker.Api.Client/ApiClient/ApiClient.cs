using Shared.Contract;
using Shared.Contract.Dtos;
using Shared.Contract.Dtos.PackList;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Stuffpacker.Api.Client.ApiClient
{
    public class ApiClient : BaseApiClient, IApiClient
    {
        private const string PacklistUrlPrefix = "api/v1/packlist";
        private const string ProfileUrlPrefix = "api/v1/profile";
        private ClaimsPrincipal _user;
        private readonly IApiAuthClientFactory _clientFactory;

        public ApiClient(IApiAuthClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public void SetPrincipal(ClaimsPrincipal user)
        {
            _user = user;
        }
        public async Task<IEnumerable<PackListDto>> GetPackLists()
        {
              
            using (var client = await _clientFactory.Create(_user))
            {
                var response = await client.GetAsync($"{PacklistUrlPrefix}");
                if (!response.IsSuccessStatusCode)
                {
                    await HandleBadRequestOrGenericError(response);
                }
             
                return await ToResult<List<PackListDto>>(response); ;
            }
        }

        public async Task UpdatePackListMaximized(Guid listId, bool maximized)
        {
            using (var client = await _clientFactory.Create(_user))
            {
                var dto = new UpdatePackListMaximizedDto
                {
                    Maximized = maximized
                };
                using (var requestBody= new JsonContent(dto))
                {

               
                    var response = await client.PatchAsync($"{PacklistUrlPrefix}/{listId}/maximized", requestBody);
                if (!response.IsSuccessStatusCode)
                {
                    await HandleBadRequestOrGenericError(response);
                }

                    return;
                }
            }
        }
        public async Task UpdatePackListVisibleList(Dictionary<Guid, bool> visibleList)
        {
            using (var client = await _clientFactory.Create(_user))
            {
                var list = new List<PackListVisibleDto>();
                foreach (var item in visibleList)
                {
                    list.Add(new PackListVisibleDto { Id=item.Key,Visible=item.Value});
                }
                var dto = new UpdatePackListVisibleListDto
                {
                    VisibleList = list
                };
                using (var requestBody = new JsonContent(dto))
                {
                    var response = await client.PatchAsync($"{PacklistUrlPrefix}/visiblelist", requestBody);
                    if (!response.IsSuccessStatusCode)
                    {
                        await HandleBadRequestOrGenericError(response);
                    }
                    return;
                }
            }
        }

        public async Task<ProfileDto> GetUserByNickName(string nickName)
        {
            using (var client = await _clientFactory.Create(_user))
            {
                var response = await client.GetAsync($"{ProfileUrlPrefix}/nickname/{nickName}");
                if (!response.IsSuccessStatusCode)
                {
                    await HandleBadRequestOrGenericError(response);
                }

                return await ToResult<ProfileDto>(response); ;
            }
        }

        public async Task UpdateUserNames(Guid userId, UpdateUserNamesDto dto)
        {
            using (var client = await _clientFactory.Create(_user))
            {                
                using (var requestBody = new JsonContent(dto))
                {
                    var response = await client.PatchAsync($"{ProfileUrlPrefix}/{userId}/names", requestBody);
                    if (!response.IsSuccessStatusCode)
                    {
                        await HandleBadRequestOrGenericError(response);
                    }
                    return;
                }
            }
        }
    }
}