using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QaAutomationPortfolio.Clients
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetPostById(int id)
        {
            return await _client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
        }

        public async Task<HttpResponseMessage> GetInvalidEndpoint()
        {
            return await _client.GetAsync("https://jsonplaceholder.typicode.com/invalidendpoint");
        }

        public async Task<HttpResponseMessage> CreatePost(object payload)
        {
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json");

            return await _client.PostAsync(
                "https://jsonplaceholder.typicode.com/posts",
                jsonContent);
        }
    }
}