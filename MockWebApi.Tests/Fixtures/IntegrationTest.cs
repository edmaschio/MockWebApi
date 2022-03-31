using System.Net.Http;
using Xunit;

namespace MockWebApi.Tests.Fixtures
{
    [Trait("Category", "Integration")]
    public abstract class IntegrationTest : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly ApiWebApplicationFactory _applicationFactory;
        protected readonly HttpClient _client;

        protected IntegrationTest(ApiWebApplicationFactory fixture)
        {
            _applicationFactory = fixture;
            _client = _applicationFactory.CreateClient();
        }
    }
}
