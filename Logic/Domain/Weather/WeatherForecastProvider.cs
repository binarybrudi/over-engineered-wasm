using Diamond.Logic.Domain.Weather.Contract;
using Diamond.Logic.Domain.Weather.Contract.DataClasses;

namespace Diamond.Logic.Domain.Weather;

public class WeatherForecastProvider  : IWeatherForecastProvider
{
    public Task<WeatherForecast> ProvideCurrentAsync()
    {
        return Task.FromResult(new WeatherForecast()
        {
            DateTime = DateTimeOffset.UtcNow,
            Temperature = 30
        });
    }
}