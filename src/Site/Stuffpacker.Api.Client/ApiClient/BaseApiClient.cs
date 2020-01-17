using Shared.Common;
using Shared.Contract.Error;
using Shared.Contract.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stuffpacker.Api.Client.ApiClient
{
    public class BaseApiClient
    {
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
    }
}
