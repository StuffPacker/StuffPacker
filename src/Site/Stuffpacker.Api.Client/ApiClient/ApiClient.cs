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
       
        private readonly IApiAuthClientFactory _clientFactory;

        public ApiClient(IApiAuthClientFactory clientFactory) : base(clientFactory)
        { 

            
        }
       
        public async Task<IEnumerable<PackListDto>> GetPackLists()
        {
            return await Get<List<PackListDto>>($"{PacklistUrlPrefix}");

        }

        public async Task UpdatePackListMaximized(Guid listId, bool maximized)
        {
            var dto = new UpdatePackListMaximizedDto
            {
                Maximized = maximized
            };
            await Patch($"{PacklistUrlPrefix}/{listId}/maximized", dto);

        }
        public async Task UpdatePackListVisibleList(Dictionary<Guid, bool> visibleList)
        {
            var list = new List<PackListVisibleDto>();
            foreach (var item in visibleList)
            {
                list.Add(new PackListVisibleDto { Id = item.Key, Visible = item.Value });
            }
            var dto = new UpdatePackListVisibleListDto
            {
                VisibleList = list
            };
            await Patch($"{PacklistUrlPrefix}/visiblelist", dto);

        }

        public async Task<ProfileDto> GetUserByNickName(string nickName)
        {
            return await Get<ProfileDto>($"{ProfileUrlPrefix}/nickname/{nickName}");

        }

        public async Task UpdateUserNames(Guid userId, UpdateUserNamesDto dto)
        {

            await Patch($"{ProfileUrlPrefix}/{userId}/names", dto);

        }

        public async Task UpdatePackListKit(Guid listId, bool kit)
        {
            var dto = new UpdatePackListKitDto
            {
                Kit = kit
            };
            await Patch($"{PacklistUrlPrefix}/{listId}/kit", dto);

        }

        public async Task UpdateUserImg(Guid userId, UpdateUserImageDto dto)
        {
            await Patch($"{ProfileUrlPrefix}/{userId}/img",dto);

        }
    }
}