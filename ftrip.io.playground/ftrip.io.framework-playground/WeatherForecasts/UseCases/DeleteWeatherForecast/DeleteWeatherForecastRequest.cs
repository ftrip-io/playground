using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.DeleteWeatherForecast
{
    public class DeleteWeatherForecastRequest : IRequest<WeatherForecast>
    {
        public Guid Id { get; set; }
    }
}