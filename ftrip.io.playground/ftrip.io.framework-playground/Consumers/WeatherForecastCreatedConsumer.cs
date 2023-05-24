using ftrip.io.framework.Correlation;
using ftrip.io.framework.messaging.Attributes;
using ftrip.io.framework.Tracing;
using ftrip.io.framework_playground.contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.Consumers
{
    [Queue(Name = "ticketQueue1")]
    [Queue(Name = "ticketQueue2")]
    public class WeatherForecastCreatedConsumer : IConsumer<WatherForecastCreated>
    {
        private readonly ITracer _tracer;

        public WeatherForecastCreatedConsumer(ITracer tracer)
        {
            _tracer = tracer;
        }

        public async Task Consume(ConsumeContext<WatherForecastCreated> context)
        {
            using (var activity = _tracer.ActivitySource.StartActivity("Testiram nesto")) ;

            Console.WriteLine(context.CorrelationId);

            var x = context.Message;

            Console.WriteLine(x.Summary + " from WeatherForecastCreatedConsumer");

            await Task.CompletedTask;
        }
    }
}