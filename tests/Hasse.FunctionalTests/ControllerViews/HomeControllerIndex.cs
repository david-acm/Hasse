using System.Net.Http;
using System.Threading.Tasks;
using Hasse.Web;
using Xunit;

namespace Hasse.FunctionalTests.ControllerViews
{
    [Collection("Sequential")]
    public class HomeControllerIndex : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public HomeControllerIndex(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsViewWithCorrectMessage()
        {
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Contains("Hasse.Web", stringResponse);
        }
    }
}