using Shared.Common;
using Shared.Contract;
using Shared.Contract.Error;
using Shared.Contract.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Stuffpacker.Api.Client.ApiClient
{
    public class BaseApiClient
    {
        private readonly IApiAuthClientFactory _clientFactory;
        private ClaimsPrincipal _user;
        public BaseApiClient(IApiAuthClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
           

          
        }
        public void SetPrincipal(ClaimsPrincipal user)
        {
            _user = user;
        }
        protected static async Task HandleBadRequestOrGenericError(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ApplicationHttpException(HttpStatusCode.BadRequest,
                    await ToResult<ErrorViewModel>(response));
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ApplicationHttpException(HttpStatusCode.Unauthorized,
                    new ErrorViewModel
                    {
                        Message = "Not Authorized to Make Request",
                        Description = "Not Authorized to Make Request"
                    });
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new ApplicationHttpException(HttpStatusCode.Forbidden,
                    new ErrorViewModel
                    {
                        Message = "No permissions to Make Request",
                        Description = "No permissions to Make Request"
                    });
            }

            throw new ApplicationHttpException(HttpStatusCode.InternalServerError,
                $"HttpClient Error ({response.StatusCode})");
        }
        protected static async Task<T> ToResult<T>(HttpResponseMessage response) where T : class, new()
        {
            var body = await response.Content.ReadAsStringAsync();
            return Serializer.Default.DeSerialize<T>(body);
        }
        protected Guid GetId(string url)
        {
            return Guid.Parse(url.Split('/').LastOrDefault());
        }
        protected async Task<Guid?> ToId(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(body))
            {
                return null;
            }
            body = body.Replace("\"", string.Empty);
            return Guid.Parse(body);

        }
        protected async Task Patch(string url, object dto)
        {
            using (var client = await _clientFactory.Create(_user))
            {
                using (var requestBody = new JsonContent(dto))
                {
                    var response = await client.PatchAsync(url, requestBody);

                    if (!response.IsSuccessStatusCode)
                    {
                        await HandleBadRequestOrGenericError(response);
                    }
                    return;
                }
            }
        }
        protected async Task<T> Get<T>(string url) where T : class, new()
        {
            using (var client = await _clientFactory.Create(_user))
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    await HandleBadRequestOrGenericError(response);
                }
                return await ToResult<T>(response);
            }
        }
        protected async Task<T> Post<T>(string url, object dto) where T : class, new()
        {

            using (var client = await _clientFactory.Create(_user))
            {

                using (var requestBody = new JsonContent(dto))
                {
                    var response = await client.PostAsync(url, requestBody);

                    if (!response.IsSuccessStatusCode)
                    {
                        await HandleBadRequestOrGenericError(response);
                    }

                    return await ToResult<T>(response);
                }
            }
        }
        protected async Task Delete(string url, object dto)
        {
            using (var client = await _clientFactory.Create(_user))
            {
                using (var requestBody = new JsonContent(dto))
                {
                    var response = await client.DeleteAsync(url, requestBody);
                    if (!response.IsSuccessStatusCode)
                    {
                        await HandleBadRequestOrGenericError(response);
                    }
                }

            }
        }
    }
}
