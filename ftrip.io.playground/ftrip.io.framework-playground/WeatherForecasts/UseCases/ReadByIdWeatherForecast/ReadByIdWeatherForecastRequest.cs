using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.ReadByIdWeatherForecast
{
    public class ReadByIdWeatherForecastRequest : IRequest<WeatherForecast>
    {
        public Guid Id { get; set; }
    }
}