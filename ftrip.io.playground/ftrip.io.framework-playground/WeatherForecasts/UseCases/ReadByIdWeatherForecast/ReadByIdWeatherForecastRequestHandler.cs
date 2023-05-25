using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.ReadByIdWeatherForecast
{
    public class ReadByIdWeatherForecastRequestHandler : IRequestHandler<ReadByIdWeatherForecastRequest, WeatherForecast>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public ReadByIdWeatherForecastRequestHandler(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<WeatherForecast> Handle(ReadByIdWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            _weatherForecastRepository.Test();

            if (request.Id == Guid.Empty)
            {
                return (await _weatherForecastRepository.Read(cancellationToken)).First();
            }

            return await _weatherForecastRepository.Read(request.Id, cancellationToken);
        }
    }
}