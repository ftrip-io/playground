using ftrip.io.framework.Correlation;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground
{
    public class UsersHttpClient
    {
        private readonly HttpClient _httpClient;

        public UsersHttpClient(HttpClient client, CorrelationContext correlationContext)
        {
            _httpClient = client;

            client.BaseAddress = new Uri("http://localhost:4999/");
            client.DefaultRequestHeaders.Add(CorrelationConstants.HeaderAttriute, correlationContext.Id);
        }

        public async Task<string> GetUsers()
        {
            return await _httpClient.GetStringAsync($"api/users/{Guid.NewGuid()}");
        }
    }
}