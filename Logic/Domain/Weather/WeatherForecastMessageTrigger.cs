using Brudibytes.Core.EventBus.Contract;
using Diamond.Logic.Domain.Weather.Contract;
using Diamond.Logic.Domain.Weather.Contract.Messaging;

namespace Diamond.Logic.Domain.Weather;

internal sealed class WeatherForecastMessageTrigger : IWeatherForecastMessageTrigger
{
    private readonly IEventBus _eventBus;
    private readonly IWeatherForecastProvider _weatherForecastProvider;

    public WeatherForecastMessageTrigger(IEventBus eventBus,
        IWeatherForecastProvider weatherForecastProvider)
    {
        _eventBus = eventBus;
        _weatherForecastProvider = weatherForecastProvider;
    }

    public async Task<bool> TriggerCurrentForecastAsync()
    {
        var current = await _weatherForecastProvider.ProvideCurrentAsync();
        var message = new CurrentForecastMessage()
        {
            CreatedAt = DateTime.Now,
            WeatherForecast = new()
            {
                DateTime = DateTime.Now,
                Temperature = current.Temperature
            }
        };
        await _eventBus.PublishAsync(message);
        return true;
    }
}