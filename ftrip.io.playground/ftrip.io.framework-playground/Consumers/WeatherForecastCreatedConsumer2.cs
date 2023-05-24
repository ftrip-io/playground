using ftrip.io.framework.messaging.Attributes;
using ftrip.io.framework_playground.contracts;
using MassTransit;
using Serilog;
using System;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.Consumers
{
    [Queue(Name = "ticketQueue1")]
    public class WeatherForecastCreatedConsumer2 : IConsumer<WatherForecastCreated>
    {
        public async Task Consume(ConsumeContext<WatherForecastCreated> context)
        {
            Console.WriteLine(context.CorrelationId);

            var x = context.Message;

            Console.WriteLine(x.Summary + " from WeatherForecastCreatedConsumer2");
            Log.Logger.Information(x.Summary + " from WeatherForecastCreatedConsumer2");

            await Task.CompletedTask;
        }
    }
}