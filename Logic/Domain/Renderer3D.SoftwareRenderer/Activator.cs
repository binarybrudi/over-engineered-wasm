using Brudibytes.Core.Contract.Bootstrapping;
using Brudibytes.Core.EventBus.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer;

public class Activator : IComponentActivator
{
    public void Activating() { }

    public void Activated() { }

    public void Deactivating() { }

    public void Deactivated() { }

    public void RegisterMappings(IServiceCollection serviceCollection) { }

    public void AddMessageSubscriptions(IEventBus eventBus) { }
}
