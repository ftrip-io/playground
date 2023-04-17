using ftrip.io.framework_playground.WeatherForecastRecords.Domain;
using MediatR;
using System.Text.Json.Serialization;

namespace ftrip.io.framework_playground.WeatherForecastRecords.UseCases.UpdateWeatherForecastRecord
{
    public class UpdateWeatherForecastRecordRequest : IRequest<WeatherForecastRecord>
    {
        [JsonIgnore]
        public string Id { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}