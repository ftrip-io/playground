using ftrip.io.framework.Mapping;
using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.CreateWeatherForecast
{
    [Mappable(Destination = typeof(WeatherForecast))]
    public class CreateWeatherForecastRequest : IRequest<WeatherForecast>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}