using Brudibytes.Core.Contract.Bootstrapping;
using Brudibytes.Core.EventBus.Contract;
using Diamond.Ui.Weather.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Diamond.Ui.Weather;

public class Activator : IComponentActivator
{
    public void Activating() { }

    public void Activated() { }

    public void Deactivating() { }
    
    public void Deactivated() { }

    public void RegisterMappings(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<CurrentWeatherForecastMessageHandler>();
    }

    public void AddMessageSubscriptions(IEventBus eventBus)
    {
        // eventBus.Subscribe();
    }
}