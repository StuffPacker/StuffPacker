using System.Security.Claims;
using System.Threading.Tasks;

namespace Stuffpacker.Api.Client.ApiClient
{
    public interface IApiAuthClientFactory
    {
        Task<ApiAuthClient> Create(ClaimsPrincipal user);
    }
}
