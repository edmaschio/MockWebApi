using MockWebApi.Ports;

namespace MockWebApi.Tests.Fixtures
{
    public class WeatherForecastConfigStub : IWeatherForecastConfigService
    {
        public int NumberOfDays() => 6;
    }
}
