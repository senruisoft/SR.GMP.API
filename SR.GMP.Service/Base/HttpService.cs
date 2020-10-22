using SR.GMP.Service.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SR.GMP.Service.Base
{
    /// <summary>
    /// HTTP服务
    /// </summary>
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<TValue> SendAsync<TValue>(HttpMethod method, string url, object postData, string contentType = "application/json", Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(method, url);
            request.Content = new StringContent(JsonSerializer.Serialize(postData), Encoding.UTF8, contentType);
            if (headers != null && headers.Count > 0)
            {
                foreach (var item in headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<TValue>(responseStream);
        }
    }
}
