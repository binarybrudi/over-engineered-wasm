using Brudibytes.Core.Contract.Bootstrapping;
using Brudibytes.Core.EventBus.Contract;
using Diamond.Logic.Domain.Weather.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Diamond.Logic.Domain.Weather;

public class Activator : IComponentActivator
{
    public void Activating() { }

    public void Activated() { }

    public void Deactivating() { }

    public void Deactivated() { }

    public void RegisterMappings(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICurrentWeatherProvider, CurrentWeatherProvider>();
        serviceCollection.AddTransient<ICurrentWeatherMessageTrigger, CurrentWeatherMessageTrigger>();
    }

    public void AddMessageSubscriptions(IEventBus eventBus) { }
}
