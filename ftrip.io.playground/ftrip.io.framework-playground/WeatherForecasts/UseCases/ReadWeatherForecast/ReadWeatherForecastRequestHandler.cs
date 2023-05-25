using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.ReadWeatherForecast
{
    public class ReadWeatherForecastRequestHandler : IRequestHandler<ReadWeatherForecastRequest, IEnumerable<WeatherForecast>>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public ReadWeatherForecastRequestHandler(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<IEnumerable<WeatherForecast>> Handle(ReadWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            return await _weatherForecastRepository.Read(cancellationToken);
        }
    }
}