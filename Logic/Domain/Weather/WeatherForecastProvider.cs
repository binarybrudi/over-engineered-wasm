using Brudibytes.Core.EventBus.Contract;
using Diamond.Logic.Domain.Weather.Contract;
using Diamond.Logic.Domain.Weather.Contract.DataClasses;
using Diamond.Logic.Domain.Weather.Contract.Messaging;

namespace Diamond.Logic.Domain.Weather;

public class WeatherForecastProvider  : IWeatherForecastProvider
{
    private readonly IEventBus _eventBus;

    public WeatherForecastProvider(IEventBus  eventBus)
    {
        _eventBus = eventBus;
    }

    public async Task<WeatherForecast> ProvideCurrentAsync()
    {
        var forecast = await Task.FromResult(new WeatherForecast()
        {
            DateTime = DateTimeOffset.UtcNow,
            Temperature = 30
        });

        await _eventBus.PublishAsync(new CurrentForecastMessage()
        {
            CreatedAt = DateTimeOffset.UtcNow,
            WeatherForecast = forecast
        });
        
        return forecast;
    }
}