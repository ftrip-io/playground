﻿using AutoMapper;
using ftrip.io.framework.messaging.Publisher;
using ftrip.io.framework.messaging.Settings;
using ftrip.io.framework.Persistence.Contracts;
using ftrip.io.framework_playground.contracts;
using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MassTransit;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.CreateWeatherForecast
{
    public class CreateWeatherForecastRecordRequestHandler : IRequestHandler<CreateWeatherForecastRequest, WeatherForecast>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<WeatherForecast, Guid> _repository;
        private readonly IMapper _mapper;

        //private readonly IMessagePublisher _messagePublisher;

        public CreateWeatherForecastRecordRequestHandler(
            IUnitOfWork unitOfWork,
            IRepository<WeatherForecast, Guid> repository,
            IMapper mapper)

        //IMessagePublisher messagePublisher)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;

            //_messagePublisher = messagePublisher;
        }

        public async Task<WeatherForecast> Handle(CreateWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Begin();

            var weatherForecast = _mapper.Map<WeatherForecast>(request);
            var createdWeatherForecast = await _repository.Create(weatherForecast, cancellationToken);

            //await _messagePublisher.Send<WatherForecastCreated, string>(new WatherForecastCreated()
            //{
            //    Id = weatherForecast.Id.ToString(),
            //    Summary = weatherForecast.Summary
            //}, cancellationToken);

            await _unitOfWork.Commit();

            return createdWeatherForecast;
        }
    }
}