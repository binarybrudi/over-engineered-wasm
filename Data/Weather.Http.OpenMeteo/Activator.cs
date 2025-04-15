using Brudibytes.Core.Contract.Bootstrapping;
using Brudibytes.Core.EventBus.Contract;
using Diamond.Data.Weather.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Diamond.Data.Weather.Http.OpenMeteo;

public class Activator : IComponentActivator
{
    public void Activating() { }

    public void Activated() { }

    public void Deactivating() { }

    public void Deactivated() { }

    public void RegisterMappings(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICurrentWeatherProjection, CurrentWeatherProjection>();
        serviceCollection.AddHttpClient(Constants.HttpClient.OpenMeteoHttpClientName, client =>
        {
            client.BaseAddress = new Uri(Constants.HttpClient.BaseAddress, UriKind.Absolute);
            client.Timeout = TimeSpan.FromSeconds(2);
        });
    }

    public void AddMessageSubscriptions(IEventBus eventBus) { }
}
