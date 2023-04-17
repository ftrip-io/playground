using ftrip.io.framework.ExceptionHandling.Exceptions;
using ftrip.io.framework.Globalization;
using ftrip.io.framework.Persistence.Contracts;
using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.DeleteWeatherForecast
{
    public class DeleteWeatherForecastRequestHandler : IRequestHandler<DeleteWeatherForecastRequest, WeatherForecast>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<WeatherForecast, Guid> _repository;
        private readonly IStringManager _stringManager;

        public DeleteWeatherForecastRequestHandler(
            IUnitOfWork unitOfWork,
            IRepository<WeatherForecast, Guid> repository,
            IStringManager stringManager)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _stringManager = stringManager;
        }

        public async Task<WeatherForecast> Handle(DeleteWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Begin();

            var deletedWeatherForecast = await _repository.Delete(request.Id, cancellationToken);
            if (deletedWeatherForecast == null)
            {
                await _unitOfWork.Rollback();
                throw new MissingEntityException(
                    string.Format(_stringManager.GetString("Common_MissingEntity"), "WeatherForecastRecord", request.Id.ToString())
                );
            }

            await _unitOfWork.Commit();

            return deletedWeatherForecast;
        }
    }
}