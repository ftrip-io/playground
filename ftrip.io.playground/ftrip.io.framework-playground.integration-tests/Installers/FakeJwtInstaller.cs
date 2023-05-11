using ftrip.io.framework.auth;
using ftrip.io.framework.Contexts;
using ftrip.io.framework.Installers;
using ftrip.io.framework.Secrets;
using Microsoft.Extensions.DependencyInjection;

namespace ftrip.io.framework_playground.integration_tests.Installers
{
    public class FakeJwtInstaller : IInstaller
    {
        private readonly IServiceCollection _services;

        public FakeJwtInstaller(IServiceCollection services)
        {
            _services = services;
        }

        public void Install()
        {
            _services.AddControllers(c => c.Filters.Add<FillCurrentUserContextFilter>());
            _services.AddSingleton<ISecretsManager, EnviromentSecretsManager>();
            _services.AddScoped(typeof(CurrentUserContext));
        }
    }
}