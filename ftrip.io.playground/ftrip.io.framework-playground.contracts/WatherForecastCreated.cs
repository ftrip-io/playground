using ftrip.io.framework.Domain;
using ftrip.io.framework.messaging.Attributes;

namespace ftrip.io.framework_playground.contracts
{
    [Queue(Name = "ticketQueue1")]
    [Queue(Name = "ticketQueue2")]
    public class WatherForecastCreated : Event<string>
    {
        public string Summary { get; set; }
    }
}