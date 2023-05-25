using ftrip.io.framework_playground.WeatherForecasts;
using ftrip.io.framework_playground.WeatherForecasts.UseCases.ReadByIdWeatherForecast;
using ftrip.io.framework_playground.WeatherForecasts.UseCases.ReadWeatherForecast;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ftrip.io.framework_playground.unit_tests
{
    public class ReadWeatherForecastRequestHandlerTests
    {
        public ReadWeatherForecastRequestHandlerTests()
        {
        }

        [Fact]
        public void ReadWeatherForecastRequestHandler_Constructor()
        {
            var handler = new ReadByIdWeatherForecastRequest();

            Assert.NotNull(handler);
        }

        [Fact]
        public async Task ReadWeatherForecastRequestHandler_HandleAsync()
        {
            var repositoryMock = new Mock<IWeatherForecastRepository>();

            var handler = new ReadByIdWeatherForecastRequestHandler(repositoryMock.Object);

            var weatherForecast = await handler.Handle(new ReadByIdWeatherForecastRequest()
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None);

            Assert.Null(weatherForecast);
        }
    }
}