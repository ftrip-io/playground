using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.ReadWeatherForecast
{
    public class ReadWeatherForecastRequestHandler : IRequestHandler<ReadWeatherForecastRequest, WeatherForecast>
    {
        public ReadWeatherForecastRequestHandler()
        {
        }

        public Task<WeatherForecast> Handle(ReadWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return Task.FromResult(new WeatherForecast() { });
            }

            return Task.FromResult(new WeatherForecast()
            {
                Id = Guid.NewGuid(),
                Active = true,
                TemperatureC = 20
            });
        }
    }
}