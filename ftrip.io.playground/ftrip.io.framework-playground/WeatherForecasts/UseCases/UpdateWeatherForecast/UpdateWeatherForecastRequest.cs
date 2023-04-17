using ftrip.io.framework.Mapping;
using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.UpdateWeatherForecast
{
    [Mappable(Destination = typeof(WeatherForecast))]
    public class UpdateWeatherForecastRequest : IRequest<WeatherForecast>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}