using Shared.Contract.Dtos;
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
    }
}