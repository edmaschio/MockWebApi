using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using MockWebApi.Ports;
using MockWebApi.Tests.Fixtures;
using MockWebApi.Tests.Utils;
using System.Threading.Tasks;
using Xunit;

namespace MockWebApi.Tests
{
    public class WeatherForecastControllerTests : IntegrationTest
    {
        public WeatherForecastControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GET_retrieves_weather_forecast()
        {
            var forecast = await _client.GetAndDeserialize<WeatherForecast[]>("/weatherforecast");
            forecast.Should().HaveCount(6);
        }

        [Fact]
        public async Task GET_with_invalid_config_results_in_a_bad_request()
        {
            var clientWithInvalidConfig = _applicationFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient<IWeatherForecastConfigService, InvalidWeatherForecastConfigStub>();
                });
            }).CreateClient();

            var response = await clientWithInvalidConfig.GetAsync("/weatherforecast");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        public class InvalidWeatherForecastConfigStub : IWeatherForecastConfigService
        {
            public int NumberOfDays() => -3;
        }
    }
}