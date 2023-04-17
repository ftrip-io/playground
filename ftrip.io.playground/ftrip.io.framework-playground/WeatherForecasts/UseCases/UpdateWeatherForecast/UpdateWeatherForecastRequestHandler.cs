using AutoMapper;
using ftrip.io.framework.Persistence.Contracts;
using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.UpdateWeatherForecast
{
    public class UpdateWeatherForecastRequestHandler : IRequestHandler<UpdateWeatherForecastRequest, WeatherForecast>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<WeatherForecast, Guid> _repository;
        private readonly IMapper _mapper;

        public UpdateWeatherForecastRequestHandler(
            IUnitOfWork unitOfWork,
            IRepository<WeatherForecast, Guid> repository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WeatherForecast> Handle(UpdateWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Begin();

            var weatherForecast = _mapper.Map<WeatherForecast>(request);
            var existingWeatherForecast = await _repository.Read(request.Id, cancellationToken);

            existingWeatherForecast.TemperatureC = weatherForecast.TemperatureC;
            existingWeatherForecast.Summary = weatherForecast.Summary;

            var updatedWeatherForecast = await _repository.Update(existingWeatherForecast, cancellationToken);

            await _unitOfWork.Commit();

            return updatedWeatherForecast;
        }
    }
}