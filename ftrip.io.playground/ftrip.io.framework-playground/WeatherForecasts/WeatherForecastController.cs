using ftrip.io.framework.Persistence.Contracts;
using ftrip.io.framework_playground.WeatherForecasts.Domain;
using ftrip.io.framework_playground.WeatherForecasts.UseCases.CreateWeatherForecast;
using ftrip.io.framework_playground.WeatherForecasts.UseCases.DeleteWeatherForecast;
using ftrip.io.framework_playground.WeatherForecasts.UseCases.UpdateWeatherForecast;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecasts
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepository<WeatherForecast, Guid> _repository;
        private readonly IMediator _mediator;

        public WeatherForecastController(
            IRepository<WeatherForecast, Guid> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAllAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _repository.Read(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadOneAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _repository.Read(id, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateWeatherForecastRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateWeatherForecastRequest request, CancellationToken cancellationToken = default)
        {
            request.Id = id;

            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new DeleteWeatherForecastRequest() { Id = id }, cancellationToken));
        }
    }
}