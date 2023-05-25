using ftrip.io.framework.Tracing;
using ftrip.io.framework_playground.WeatherForecasts.UseCases.CreateWeatherForecast;
using ftrip.io.framework_playground.WeatherForecasts.UseCases.DeleteWeatherForecast;
using ftrip.io.framework_playground.WeatherForecasts.UseCases.ReadByIdWeatherForecast;
using ftrip.io.framework_playground.WeatherForecasts.UseCases.ReadWeatherForecast;
using ftrip.io.framework_playground.WeatherForecasts.UseCases.UpdateWeatherForecast;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecasts
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly ITracer _tracer;

        public WeatherForecastController(
            IMediator mediator,
            ILogger logger,
            ITracer tracer)
        {
            _mediator = mediator;
            _logger = logger;
            _tracer = tracer;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAllAsync(CancellationToken cancellationToken = default)
        {
            _logger.Information("Text pre {@Test} I posle", "Test");

            return Ok(await _mediator.Send(new ReadWeatherForecastRequest(), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadOneAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ReadByIdWeatherForecastRequest() { Id = id }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateWeatherForecastRequest request, CancellationToken cancellationToken = default)
        {
            using var activity = _tracer.ActivitySource.StartActivity("create forecast");

            _logger.Information("Text pre {@Test} I posle", "Test");

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