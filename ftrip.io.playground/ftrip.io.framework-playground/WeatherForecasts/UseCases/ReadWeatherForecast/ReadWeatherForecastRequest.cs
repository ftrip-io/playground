using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.ReadWeatherForecast
{
    public class ReadWeatherForecastRequest : IRequest<WeatherForecast>
    {
        public Guid Id { get; set; }
    }
}