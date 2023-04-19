using ftrip.io.framework.auth;
using ftrip.io.framework.CQRS;
using ftrip.io.framework.ExceptionHandling.Extensions;
using ftrip.io.framework.Globalization;
using ftrip.io.framework.Installers;
using ftrip.io.framework.jobs.Extensions;
using ftrip.io.framework.jobs.Installers;
using ftrip.io.framework.Mapping;
using ftrip.io.framework.messaging.Installers;
using ftrip.io.framework.Persistence.NoSql.Mongodb.Installers;
using ftrip.io.framework.Persistence.Sql.Mariadb;
using ftrip.io.framework.Swagger;
using ftrip.io.framework.Validation;
using ftrip.io.framework_playground.Consumers;
using ftrip.io.framework_playground.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ftrip.io.framework_playground
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            InstallerCollection.With(
                new SwaggerInstaller<Startup>(services),
                new AutoMapperInstaller<Startup>(services),
                new FluentValidationInstaller<Startup>(services),
                new MariadbInstaller<DatabaseContext>(services),

                //new MongodbInstaller(services),
                new JwtAuthenticationInstaller(services),
                new CQRSInstaller<Startup>(services),

                new GlobalizationInstaller<Startup>(services),
                new HangfireInstaller(services),

                new RabbitMQInstaller<Startup>(services, RabbitMQInstallerType.Publisher | RabbitMQInstallerType.Consumer)

            ).Install();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseFtripioGlobalExceptionHandler();
            app.UseFtripionJobs<Startup>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseFtripioSwagger(Configuration.GetSection(nameof(SwaggerSettings)).Get<SwaggerSettings>());
        }
    }
}