using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using QaAutomationPortfolio.Clients;

namespace QaAutomationPortfolio.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class ApiTests
    {
        private static HttpClient _httpClient = null!;
        private static ApiClient _apiClient = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };

            _apiClient = new ApiClient(_httpClient);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _httpClient.Dispose();
        }

        [Test]
        public async Task Get_Post_By_Id_Should_Return_200()
        {
            var response = await _apiClient.GetPostById(1);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public async Task Get_Post_Should_Contain_Expected_Title()
        {
            var response = await _apiClient.GetPostById(1);
            var content = await response.Content.ReadAsStringAsync();

            var json = JsonDocument.Parse(content);
            var title = json.RootElement.GetProperty("title").GetString();

            Assert.That(title, Is.Not.Null);
            Assert.That(title!.Length, Is.GreaterThan(5));
        }

        [Test]
        public async Task Invalid_Endpoint_Should_Return_404()
        {
            var response = await _apiClient.GetInvalidEndpoint();
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }

        [Test]
        public async Task Create_Post_Should_Return_201()
        {
            var payload = new
            {
                title = "Portfolio Test",
                body = "QA automation test",
                userId = 1
            };

            var response = await _apiClient.CreatePost(payload);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
        }
    }
}