using ftrip.io.framework_playground.WeatherForecastRecords.Domain;
using MediatR;
using System;

namespace ftrip.io.framework_playground.WeatherForecastRecords.UseCases.CreateWeatherForecastRecord
{
    public class CreateWeatherForecastRecordRequest : IRequest<WeatherForecastRecord>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}