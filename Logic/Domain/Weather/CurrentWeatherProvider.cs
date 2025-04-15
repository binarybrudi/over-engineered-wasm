using Diamond.Data.Weather.Contract;
using Diamond.Logic.Domain.Weather.Contract;
using Diamond.Logic.Domain.Weather.Contract.DataClasses;

namespace Diamond.Logic.Domain.Weather;

internal sealed class CurrentWeatherProvider : ICurrentWeatherProvider
{
    private readonly ICurrentWeatherProjection _currentWeatherProjection;

    public CurrentWeatherProvider(ICurrentWeatherProjection currentWeatherProjection)
    {
        _currentWeatherProjection = currentWeatherProjection;
    }

    public async Task<CurrentWeather> ProvideCurrentAsync()
    {
        var current = await _currentWeatherProjection.GetCurrentWeatherAsync();
        
        var currentWeather = await Task.FromResult(new CurrentWeather()
        {
            IsDay = current.IsDay,
            DateTime = DateTimeOffset.UtcNow,
            Temperature = current.Temperature
        });

        return currentWeather;
    }
}