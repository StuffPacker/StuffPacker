using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stuffpacker.Api.Client.ApiClient
{
    public class ApiAuthClient : IDisposable
    {
        private readonly HttpClient _client;
        private readonly HttpRequestMessage _message;
        private readonly bool _disposeClient;

        public ApiAuthClient(HttpClient client, HttpRequestMessage httpRequestMessage, bool disposeClient)
        {
            _client = client;
            _message = httpRequestMessage;
            _disposeClient = disposeClient;
        }

        public void Dispose()
        {
            if (_disposeClient)
            {
                _client?.Dispose();
            }

            _message?.Dispose();
        }

        public async Task<HttpResponseMessage> PostAsync(string relUrl, HttpContent requestBody)
        {
            _message.Content = requestBody;
            _message.Method = HttpMethod.Post;
            _message.RequestUri = new Uri(relUrl, UriKind.Relative);
            var rnd = new Random();
            var maxTest = 0;
            while (maxTest < 10)
            {
                maxTest++;
                var result = await _client.SendAsync(_message);
                if (result.StatusCode == HttpStatusCode.Conflict)
                {
                    await Task.Delay(rnd.Next(1, 1000));
                    continue;
                }
                return result;
            }
            throw new IndexOutOfRangeException("tried 10 times but no luck");

        }
        public async Task<HttpResponseMessage> PatchAsync(string relUrl, HttpContent requestBody)
        {
            _message.Content = requestBody;
            _message.Method = HttpMethod.Patch;
            _message.RequestUri = new Uri(relUrl, UriKind.Relative);
            var rnd = new Random();
            var maxTest = 0;
            while (maxTest < 10)
            {
                maxTest++;
                var result = await _client.SendAsync(_message);
                if (result.StatusCode == HttpStatusCode.Conflict)
                {
                    await Task.Delay(rnd.Next(1, 1000));
                    continue;
                }
                return result;
            }
            throw new IndexOutOfRangeException("tried 10 times but no luck");
        }

        public async Task<HttpResponseMessage> GetAsync(string relUrl)
        {
            _message.Method = HttpMethod.Get;
            _message.RequestUri = new Uri(relUrl, UriKind.Relative);
            return await _client.SendAsync(_message);
        }

        public async Task<HttpResponseMessage> PutAsync(string relUrl, HttpContent requestBody)
        {
            _message.Content = requestBody;
            _message.Method = HttpMethod.Put;
            _message.RequestUri = new Uri(relUrl, UriKind.Relative);
            var rnd = new Random();
            var maxTest = 0;
            while (maxTest < 10)
            {
                maxTest++;
                var result = await _client.SendAsync(_message);
                if (result.StatusCode == HttpStatusCode.Conflict)
                {
                    await Task.Delay(rnd.Next(1, 1000));
                    continue;
                }
                return result;
            }
            throw new IndexOutOfRangeException("tried 10 times but no luck");

        }

        public async Task<HttpResponseMessage> DeleteAsync(string relUrl, HttpContent requestBody)
        {
            _message.Content = requestBody;
            _message.Method = HttpMethod.Delete;
            _message.RequestUri = new Uri(relUrl, UriKind.Relative);
            var rnd = new Random();
            var maxTest = 0;
            while (maxTest < 10)
            {
                maxTest++;
                var result = await _client.SendAsync(_message);
                if (result.StatusCode == HttpStatusCode.Conflict)
                {
                    await Task.Delay(rnd.Next(1, 1000));
                    continue;
                }
                return result;
            }
            throw new IndexOutOfRangeException("tried 10 times but no luck");

        }
    }
}
