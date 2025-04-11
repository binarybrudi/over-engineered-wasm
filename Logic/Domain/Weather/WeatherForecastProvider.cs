using Brudibytes.Core.EventBus.Contract;
using Diamond.Data.Weather.Contract;
using Diamond.Logic.Domain.Weather.Contract;
using Diamond.Logic.Domain.Weather.Contract.DataClasses;
using Diamond.Logic.Domain.Weather.Contract.Messaging;

namespace Diamond.Logic.Domain.Weather;

internal sealed class WeatherForecastProvider : IWeatherForecastProvider
{
    private readonly ICurrentWeatherProjection _currentWeatherProjection;

    public WeatherForecastProvider(ICurrentWeatherProjection currentWeatherProjection)
    {
        _currentWeatherProjection = currentWeatherProjection;
    }

    public async Task<WeatherForecast> ProvideCurrentAsync()
    {
        var current = await _currentWeatherProjection.GetCurrentWeatherAsync();
        
        var forecast = await Task.FromResult(new WeatherForecast()
        {
            DateTime = DateTimeOffset.UtcNow,
            Temperature = current.Temperature
        });

        return forecast;
    }
}