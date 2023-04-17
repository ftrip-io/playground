using ftrip.io.framework.Domain;
using System;

namespace ftrip.io.framework_playground.WeatherForecasts.Domain
{
    public class WeatherForecast : Entity<Guid>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}