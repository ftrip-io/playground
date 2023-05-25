using AutoMapper;
using ftrip.io.framework.Persistence.Contracts;
using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.UpdateWeatherForecast
{
    public class UpdateWeatherForecastRequestHandler : IRequestHandler<UpdateWeatherForecastRequest, WeatherForecast>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly IMapper _mapper;

        public UpdateWeatherForecastRequestHandler(
            IUnitOfWork unitOfWork,
            IWeatherForecastRepository weatherForecastRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _weatherForecastRepository = weatherForecastRepository;
            _mapper = mapper;
        }

        public async Task<WeatherForecast> Handle(UpdateWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Begin();

            var weatherForecast = _mapper.Map<WeatherForecast>(request);
            var existingWeatherForecast = await _weatherForecastRepository.Read(request.Id, cancellationToken);

            existingWeatherForecast.TemperatureC = weatherForecast.TemperatureC;
            existingWeatherForecast.Summary = weatherForecast.Summary;

            var updatedWeatherForecast = await _weatherForecastRepository.Update(existingWeatherForecast, cancellationToken);

            await _unitOfWork.Commit();

            return updatedWeatherForecast;
        }
    }
}