using ftrip.io.framework_playground.WeatherForecasts.UseCases.ReadWeatherForecast;
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
            var handler = new ReadWeatherForecastRequestHandler();

            Assert.NotNull(handler);
        }

        [Fact]
        public async Task ReadWeatherForecastRequestHandler_HandleAsync()
        {
            var handler = new ReadWeatherForecastRequestHandler();

            var weatherForecast = await handler.Handle(new ReadWeatherForecastRequest()
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None);

            Assert.NotNull(weatherForecast);
        }
    }
}