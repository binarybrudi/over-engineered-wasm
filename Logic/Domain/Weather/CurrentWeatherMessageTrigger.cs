using Brudibytes.Core.EventBus.Contract;
using Diamond.Logic.Domain.Weather.Contract;
using Diamond.Logic.Domain.Weather.Contract.Messaging;

namespace Diamond.Logic.Domain.Weather;

internal sealed class CurrentWeatherMessageTrigger : ICurrentWeatherMessageTrigger
{
    private readonly IEventBus _eventBus;
    private readonly ICurrentWeatherProvider _currentWeatherProvider;

    public CurrentWeatherMessageTrigger(IEventBus eventBus,
        ICurrentWeatherProvider currentWeatherProvider)
    {
        _eventBus = eventBus;
        _currentWeatherProvider = currentWeatherProvider;
    }

    public void TriggerCurrentWeather()
    {
        Task.Run(async () =>
        {
            var current = await _currentWeatherProvider.ProvideCurrentAsync();
            var message = new CurrentForecastMessage()
            {
                CreatedAt = DateTime.Now,
                CurrentWeather = new()
                {
                    DateTime = DateTime.Now,
                    Temperature = current.Temperature
                }
            };
            await _eventBus.PublishAsync(message);
        });
    }
}