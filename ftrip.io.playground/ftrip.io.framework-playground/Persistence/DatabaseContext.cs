using ftrip.io.framework.Contexts;
using ftrip.io.framework.Persistence.Sql.Database;
using ftrip.io.framework_playground.WeatherForecasts.Domain;
using Microsoft.EntityFrameworkCore;

namespace ftrip.io.framework_playground.Persistence
{
    public class DatabaseContext : DatabaseContextBase<DatabaseContext>
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, CurrentUserContext currentUserContext) :
            base(options, currentUserContext)
        {
        }
    }
}