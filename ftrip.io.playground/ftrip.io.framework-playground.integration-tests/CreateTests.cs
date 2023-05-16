using ftrip.io.framework_playground.WeatherForecasts.UseCases.CreateWeatherForecast;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace ftrip.io.framework_playground.integration_tests.Tests.Users
{
    public class CreateTests : TestBase
    {
        public CreateTests(ApiFactory factory) :
            base(factory)
        {
        }

        [Fact]
        public async Task CreateWeather_ReturnsOk()
        {
            // Arrange
            var request = new CreateWeatherForecastRequest()
            {
                Date = System.DateTime.Now,
                Summary = "CAO",
                TemperatureC = 20
            };

            // Act
            var client = _apiFactory.CreateClient();
            var response = await client.PostAsJsonAsync("api/WeatherForecast", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}