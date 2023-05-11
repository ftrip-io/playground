using Xunit;

namespace ftrip.io.framework_playground.integration_tests
{
    public class TestBase : IClassFixture<ApiFactory>
    {
        protected readonly ApiFactory _apiFactory;

        public TestBase(ApiFactory apiFactory)
        {
            _apiFactory = apiFactory;
        }
    }
}