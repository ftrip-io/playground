using ftrip.io.framework.ExceptionHandling.Exceptions;
using ftrip.io.framework.Globalization;
using ftrip.io.framework.Persistence.Contracts;
using ftrip.io.framework_playground.WeatherForecastRecords.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecastRecords.UseCases.DeleteWeatherForecastRecord
{
    public class DeleteWeatherForecastRecordRequestHandler : IRequestHandler<DeleteWeatherForecastRecordRequest, WeatherForecastRecord>
    {
        private readonly IRepository<WeatherForecastRecord, string> _repository;
        private readonly IStringManager _stringManager;

        public DeleteWeatherForecastRecordRequestHandler(
            IRepository<WeatherForecastRecord, string> repository,
            IStringManager stringManager)
        {
            _repository = repository;
            _stringManager = stringManager;
        }

        public async Task<WeatherForecastRecord> Handle(DeleteWeatherForecastRecordRequest request, CancellationToken cancellationToken)
        {
            var deletedWeatherForecast = await _repository.Delete(request.Id, cancellationToken);
            if (deletedWeatherForecast == null)
            {
                throw new MissingEntityException(
                    string.Format(_stringManager.GetString("Common_MissingEntity"), "WeatherForecastRecord", request.Id.ToString())
                );
            }

            return deletedWeatherForecast;
        }
    }
}