using Brudibytes.Core.EventBus.Contract;
using Diamond.Logic.Domain.Weather.Contract.Messaging;

namespace Diamond.Ui.Weather.Messaging;

public class CurrentWeatherForecastMessageHandler : IEventMessageHandler<CurrentForecastMessage>
{
    public Task HandleAsync(CurrentForecastMessage eventMessage)
    {
        return Task.CompletedTask;
    }
}
