using Brudibytes.Core.EventBus.Contract;
using Diamond.Logic.Domain.Weather.Contract;
using Diamond.Logic.Domain.Weather.Contract.Messaging;

namespace Diamond.Logic.Domain.Weather;

internal sealed class WeatherForecastMessageTrigger : IWeatherForecastMessageTrigger
{
    private readonly IEventBus _eventBus;

    public WeatherForecastMessageTrigger(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public async Task<bool> TriggerCurrentForecastAsync()
    {
        var message = new CurrentForecastMessage()
        {
            CreatedAt = DateTime.Now,
            WeatherForecast = new()
            {
                DateTime = DateTime.Now,
                Temperature = new Random().Next(-20, 45)
            }
        };
        await _eventBus.PublishAsync(message);
        return true;
    }
}