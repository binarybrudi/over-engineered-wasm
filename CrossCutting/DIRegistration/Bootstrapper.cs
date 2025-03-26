using Brudibytes.Core.Contract.Bootstrapping;
using Brudibytes.Core.EventBus;
using Brudibytes.Core.EventBus.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Diamond.CrossCutting.DIRegistration;

public class Bootstrapper  : IBootstrapper
{
    public void ActivateAll(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        // infrastructure
        serviceCollection.AddSingleton<IEventBus, InMemoryEventBus>();
    }
}