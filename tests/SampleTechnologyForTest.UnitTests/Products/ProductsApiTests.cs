using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace SampleTechnologyForTest.UnitTests.Products
{
    public class ProductsApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProductsApiTests(
            WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetProducts_Should_Return_Success_Status_Code()
        {
            var response = await _client.GetAsync("/api/products");

            response.EnsureSuccessStatusCode();
        }
    }
}
