using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.Contract.Options;
using Shared.Contract.Provider;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Stuffpacker.Api.Client.ApiClient
{

    public class ApiAuthClientFactory : IApiAuthClientFactory, IDisposable
    {
        private readonly Lazy<HttpClient> _sharedClient;
        private readonly ILogger<ApiAuthClientFactory> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SiteOptions _siteOptions;
        private readonly ITokenProvider _tokenProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApiAuthClientFactory(
          IOptions<SiteOptions> siteOptions,
           ILogger<ApiAuthClientFactory> logger, IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider, IHttpContextAccessor httpContextAccessor)
        {


            _logger = logger;
            _siteOptions = siteOptions.Value;
            _httpClientFactory = httpClientFactory;
            _sharedClient =
                new Lazy<HttpClient>(() => CreateHttpClient());
            _tokenProvider = tokenProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiAuthClient> Create(ClaimsPrincipal user)
        {
            var requestMessage = await CreateRequestInternal(user);

            return new ApiAuthClient(CreateHttpClient(), requestMessage, true);
        }

        private async Task<HttpRequestMessage> CreateRequestInternal(ClaimsPrincipal user)
        {
            var reqMessage = new HttpRequestMessage();

            reqMessage.Headers.Accept.Clear();
            reqMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            await AddBearerToken(reqMessage, user);
            return reqMessage;
        }
        private async Task AddBearerToken(HttpRequestMessage client, ClaimsPrincipal directUser)
        {
            var accessToken= directUser.FindFirst("SpAdminApiToken");         
            client.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Value);
        }
        public void Dispose()
        {
            new HttpClientHandler { PreAuthenticate = true }?.Dispose();
        }

        private HttpClient CreateHttpClient()
        {
            var baseAddress = new Uri(_siteOptions.ApiBaseUrl);

            var client = _httpClientFactory.CreateClient("ApiClient");

            client.BaseAddress = baseAddress;
            client.Timeout = TimeSpan.FromSeconds(60);

            client.DefaultRequestHeaders.Accept.Clear();

            return client;
        }


    }
}
