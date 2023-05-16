using ftrip.io.framework.Contexts;
using ftrip.io.framework.Persistence.Sql.Database;
using ftrip.io.framework_playground.WeatherForecasts.Domain;
using Microsoft.EntityFrameworkCore;

namespace ftrip.io.framework_playground.Persistence
{
    public class DatabaseContext : DatabaseContextBase<DatabaseContext>
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<WeatherForecastNestedSingle> WeatherForecastNestedSingles { get; set; }
        public DbSet<WeatherForecastNestedMultiple> WeatherForecastNestedMultiples { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, CurrentUserContext currentUserContext) :
            base(options, currentUserContext)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IgnoreSoftDelete(typeof(WeatherForecast));

            base.OnModelCreating(modelBuilder);
        }
    }
}