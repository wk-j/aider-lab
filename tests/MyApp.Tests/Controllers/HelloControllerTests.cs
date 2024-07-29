using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MyApp.Tests.Controllers
{
    public class HelloControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public HelloControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_ReturnsHelloWorld()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Hello");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("Hello, World!", content);
        }

        [Fact]
        public async Task GetWithName_ReturnsHelloName()
        {
            // Arrange
            var client = _factory.CreateClient();
            var name = "John";

            // Act
            var response = await client.GetAsync($"/Hello/{name}");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal($"Hello, {name}!", content);
        }
    }
}
