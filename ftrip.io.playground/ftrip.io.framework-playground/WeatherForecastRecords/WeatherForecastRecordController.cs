using ftrip.io.framework.Persistence.Contracts;
using ftrip.io.framework_playground.WeatherForecastRecords.Domain;
using ftrip.io.framework_playground.WeatherForecastRecords.UseCases.CreateWeatherForecastRecord;
using ftrip.io.framework_playground.WeatherForecastRecords.UseCases.DeleteWeatherForecastRecord;
using ftrip.io.framework_playground.WeatherForecastRecords.UseCases.UpdateWeatherForecastRecord;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.WeatherForecastRecords
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastRecordController : ControllerBase
    {
        private readonly IRepository<WeatherForecastRecord, string> _repository;
        private readonly IMediator _mediator;

        public WeatherForecastRecordController(
            IRepository<WeatherForecastRecord, string> repository,
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
        public async Task<IActionResult> ReadOneAsync(string id, CancellationToken cancellationToken = default)
        {
            return Ok(await _repository.Read(id, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateWeatherForecastRecordRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, UpdateWeatherForecastRecordRequest request, CancellationToken cancellationToken = default)
        {
            request.Id = id;

            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new DeleteWeatherForecastRecordRequest() { Id = id }, cancellationToken));
        }
    }
}