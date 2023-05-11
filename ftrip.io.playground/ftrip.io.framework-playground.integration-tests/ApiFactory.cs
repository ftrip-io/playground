using ftrip.io.framework.Installers;
using ftrip.io.framework_playground.integration_tests.Installers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ftrip.io.framework_playground.integration_tests
{
    public class ApiFactory : WebApplicationFactory<Startup>, IAsyncLifetime
    {
        protected readonly TestMariadbSettings _mariadbSettings;

        protected readonly TestContainersCollection _testContainers;

        protected IServiceScope _serviceScope;

        public ApiFactory()
        {
            _mariadbSettings = new TestMariadbSettings();

            _testContainers = new TestContainersCollection()
            {
                TestContainers.BuildMariadbContainer(_mariadbSettings)
            };
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            Environment.SetEnvironmentVariable("IN_TEST_MODE", "true");

            builder.ConfigureServices((IServiceCollection services) =>
            {
                InstallerCollection.With(
                    new EnvironmentInstaller(),
                    new FakeJwtInstaller(services),
                    new TestMariadbInstaller(services, _mariadbSettings)
                ).Install();
            });
        }

        public IServiceScope CreateServiceScope()
        {
            return Services.CreateScope();
        }

        public T GetService<T>()
        {
            var serviceScope = GetServiceScope();

            return serviceScope.ServiceProvider.GetService<T>();
        }

        protected IServiceScope GetServiceScope()
        {
            if (_serviceScope == null)
            {
                _serviceScope = CreateServiceScope();
            }

            return _serviceScope;
        }

        public async Task InitializeAsync()
        {
            await _testContainers.StartAll();
        }

        public async Task DisposeAsync()
        {
            await _testContainers.StopAll();
            Dispose();
        }
    }
}