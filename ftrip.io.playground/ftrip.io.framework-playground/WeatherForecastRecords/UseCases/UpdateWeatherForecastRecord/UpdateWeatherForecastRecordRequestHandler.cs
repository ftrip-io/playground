using AutoMapper;
using ftrip.io.framework.Persistence.Contracts;
using ftrip.io.framework_playground.WeatherForecastRecords.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecastRecords.UseCases.UpdateWeatherForecastRecord
{
    public class UpdateWeatherForecastRecordRequestHandler : IRequestHandler<UpdateWeatherForecastRecordRequest, WeatherForecastRecord>
    {
        private readonly IRepository<WeatherForecastRecord, string> _repository;
        private readonly IMapper _mapper;

        public UpdateWeatherForecastRecordRequestHandler(
            IRepository<WeatherForecastRecord, string> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WeatherForecastRecord> Handle(UpdateWeatherForecastRecordRequest request, CancellationToken cancellationToken)
        {
            var weatherForecast = _mapper.Map<WeatherForecastRecord>(request);
            var existingWeatherForecast = await _repository.Read(request.Id, cancellationToken);

            existingWeatherForecast.TemperatureC = weatherForecast.TemperatureC;
            existingWeatherForecast.Summary = weatherForecast.Summary;

            var updatedWeatherForecast = await _repository.Update(existingWeatherForecast, cancellationToken);

            return updatedWeatherForecast;
        }
    }
}