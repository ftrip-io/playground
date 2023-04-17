using AutoMapper;
using ftrip.io.framework_playground.WeatherForecastRecords.Domain;
using ftrip.io.framework_playground.WeatherForecastRecords.UseCases.CreateWeatherForecastRecord;
using ftrip.io.framework_playground.WeatherForecastRecords.UseCases.UpdateWeatherForecastRecord;

namespace ftrip.io.framework_playground.WeatherForecastRecords.Mappings
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateWeatherForecastRecordRequest, WeatherForecastRecord>();
            CreateMap<UpdateWeatherForecastRecordRequest, WeatherForecastRecord>();
        }
    }
}