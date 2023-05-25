using ftrip.io.framework.Persistence.Contracts;
using ftrip.io.framework.Persistence.Sql.Repository;
using ftrip.io.framework_playground.WeatherForecasts.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace ftrip.io.framework_playground.WeatherForecasts
{
    public interface IWeatherForecastRepository : IRepository<WeatherForecast, Guid>
    {
        void Test();
    }

    public class WeatherForecastRepository : Repository<WeatherForecast, Guid>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(DbContext context) :
            base(context)
        {
        }

        public void Test()
        {
            Console.WriteLine("asklfasfask;l");
        }
    }
}