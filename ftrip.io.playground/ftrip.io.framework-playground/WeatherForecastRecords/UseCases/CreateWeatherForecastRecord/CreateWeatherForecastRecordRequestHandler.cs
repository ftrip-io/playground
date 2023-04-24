﻿using AutoMapper;
using ftrip.io.framework.Persistence.Contracts;
using ftrip.io.framework_playground.WeatherForecastRecords.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecastRecords.UseCases.CreateWeatherForecastRecord
{
    public class CreateWeatherForecastRecordRequestHandler : IRequestHandler<CreateWeatherForecastRecordRequest, WeatherForecastRecord>
    {
        private readonly IRepository<WeatherForecastRecord, string> _repository;
        private readonly IMapper _mapper;

        public CreateWeatherForecastRecordRequestHandler(
            IRepository<WeatherForecastRecord, string> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WeatherForecastRecord> Handle(CreateWeatherForecastRecordRequest request, CancellationToken cancellationToken)
        {
            var weatherForecast = _mapper.Map<WeatherForecastRecord>(request);
            var x = 5;
            if (weatherForecast.Date < System.DateTime.MinValue.AddDays(100))
            {
                weatherForecast.Date = new System.DateTime();
            }
            var m = 5;
            var u = 5;
            var z = 5;
            var nj = 10;

            return await _repository.Create(weatherForecast, cancellationToken);
        }
    }
}