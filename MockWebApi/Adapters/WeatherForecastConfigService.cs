using MockWebApi.Ports;

namespace MockWebApi.Adapters
{
    public class WeatherForecastConfigService : IWeatherForecastConfigService
    {
        public int NumberOfDays() => 7;
    }
}
