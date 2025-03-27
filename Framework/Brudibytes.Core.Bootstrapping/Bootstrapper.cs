using Brudibytes.Core.Contract;
using Brudibytes.Core.Contract.Bootstrapping;
using Brudibytes.Core.EventBus.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Brudibytes.Core.Bootstrapping;

public class Bootstrapper : IBootstrapper
{
    private readonly IComponentActivator[] _componentActivators;
    
    public Bootstrapper(IComponentActivator[] componentActivators)
    {
        _componentActivators = componentActivators;
    }

    public void ActivatingAll()
    {
        foreach (var componentActivator in _componentActivators)
        {
            componentActivator.Activating();
        }
    }

    public void ActivatedAll()
    {
        foreach (var componentActivator in _componentActivators)
        {
            componentActivator.Activated();
        }
    }

    public void DeactivatedAll()
    {
        foreach (var componentActivator in _componentActivators)
        {
            componentActivator.Deactivated();
        }
    }

    public void DeactivatingAll()
    {
        foreach (var componentActivator in _componentActivators)
        {
            componentActivator.Deactivating();
        }
    }

    public void RegisterAllMappings(IServiceCollection serviceCollection)
    {
        foreach (var componentActivator in _componentActivators)
        {
            componentActivator.RegisterMappings(serviceCollection);
        }
    }

    public void AddAllMessageSubscriptions(IEventBus eventBus)
    {
        foreach (var componentActivator in _componentActivators)
        {
            componentActivator.AddMessageSubscriptions(eventBus);
        }
    }
}