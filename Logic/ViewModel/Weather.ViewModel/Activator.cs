using Brudibytes.Core.Contract.Bootstrapping;
using Brudibytes.Core.EventBus.Contract;
using Diamond.Logic.ViewModel.Weather.ViewModel.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Diamond.Logic.ViewModel.Weather.ViewModel;

public class Activator : IComponentActivator
{
    public void Activating() { }

    public void Activated() { }

    public void Deactivating() { }
    
    public void Deactivated() { }

    public void RegisterMappings(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IWeatherWidgetViewModel, WeatherWidgetViewModel>();
    }

    public void AddMessageSubscriptions(IEventBus eventBus) { }
}
