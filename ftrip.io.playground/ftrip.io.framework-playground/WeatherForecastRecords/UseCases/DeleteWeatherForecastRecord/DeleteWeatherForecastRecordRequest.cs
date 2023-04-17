using ftrip.io.framework_playground.WeatherForecastRecords.Domain;
using MediatR;

namespace ftrip.io.framework_playground.WeatherForecastRecords.UseCases.DeleteWeatherForecastRecord
{
    public class DeleteWeatherForecastRecordRequest : IRequest<WeatherForecastRecord>
    {
        public string Id { get; set; }
    }
}