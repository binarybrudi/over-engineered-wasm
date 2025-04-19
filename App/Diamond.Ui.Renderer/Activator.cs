using Brudibytes.Core.Contract.Bootstrapping;
using Brudibytes.Core.EventBus.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Diamond.Ui.Renderer;

public class Activator : IComponentActivator
{
    public void Activating() { }
    public void Activated() { }
    public void Deactivating() { }
    public void Deactivated() { }
    public void AddMessageSubscriptions(IEventBus eventBus) { }
    public void RegisterMappings(IServiceCollection serviceCollection) { }
}
