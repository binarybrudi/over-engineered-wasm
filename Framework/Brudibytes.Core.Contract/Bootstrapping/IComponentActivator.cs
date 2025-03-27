using Brudibytes.Core.EventBus.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Brudibytes.Core.Contract.Bootstrapping;

public interface IComponentActivator
{
    void Activating();
    void Activated();
    void Deactivating();
    void Deactivated();
    void RegisterMappings(IServiceCollection serviceCollection);
    void AddMessageSubscriptions(IEventBus eventBus);
}
