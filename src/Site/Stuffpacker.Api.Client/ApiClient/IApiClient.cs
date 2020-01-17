using Shared.Contract.Dtos;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Stuffpacker.Api.Client.ApiClient
{
    public interface IApiClient
    {
        Task<IEnumerable<PackListDto>> GetPackLists();
        void SetPrincipal(ClaimsPrincipal user);
    }
}
