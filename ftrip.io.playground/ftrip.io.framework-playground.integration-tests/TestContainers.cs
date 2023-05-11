using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using ftrip.io.framework_playground.integration_tests.Installers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Testcontainers.MariaDb;

namespace ftrip.io.framework_playground.integration_tests
{
    public static class TestContainers
    {
        public static MariaDbContainer BuildMariadbContainer(TestMariadbSettings settings)
        {
            return new MariaDbBuilder()
                .WithImage(settings.Image)
                .WithPortBinding(int.Parse(settings.Port), MariaDbBuilder.MariaDbPort)
                .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(MariaDbBuilder.MariaDbPort))
                .Build();
        }
    }

    public class TestContainersCollection : Collection<DockerContainer>
    {
        public async Task StartAll()
        {
            var starts = Items.Select(i => i.StartAsync());

            await Task.WhenAll(starts);
        }

        public async Task StopAll()
        {
            var starts = Items.Select(i => i.StartAsync());

            await Task.WhenAll(starts);
        }
    }
}