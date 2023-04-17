using ftrip.io.framework.messaging.Attributes;
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
        public async Task Consume(ConsumeContext<WatherForecastCreated> context)
        {
            var x = context.Message;

            Console.WriteLine(x.Summary + " from WeatherForecastCreatedConsumer");

            await Task.CompletedTask;
        }
    }
}