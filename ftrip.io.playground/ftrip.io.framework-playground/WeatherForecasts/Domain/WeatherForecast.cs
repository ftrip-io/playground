using ftrip.io.framework.Domain;
using System;
using System.Collections.Generic;

namespace ftrip.io.framework_playground.WeatherForecasts.Domain
{
    public class WeatherForecast : Entity<Guid>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public virtual WeatherForecastNestedSingle WeatherForecastNestedSingle { get; set; }

        public virtual List<WeatherForecastNestedMultiple> WeatherForecastNestedMultiples { get; set; }
    }

    public class WeatherForecastNestedSingle : Entity<Guid>
    {
        public string Name { get; set; }
        public Guid WeatherForecastId { get; set; }
    }

    public class WeatherForecastNestedMultiple : Entity<Guid>
    {
        public string Name { get; set; }
        public Guid WeatherForecastId { get; set; }
    }
}