using Brudibytes.Core.Contract.Bootstrapping;
using Brudibytes.Core.Contract.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Brudibytes.Core.Microsoft.DependencyInjection.Adapter;

public class CoCoKernelAdapter : ICoCoKernel
{
    private readonly ServiceCollection _serviceCollection;
    private IServiceProvider? _serviceProvider;

    public CoCoKernelAdapter(ServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }
    
    public void AddTransient<TInterface, TImplementation>()
        where TInterface : class
        where TImplementation : class, TInterface
    {
        _serviceCollection.AddTransient<TInterface, TImplementation>();
    }

    public void RegisterComponent<TComponent>() where TComponent : class, IComponentActivator
    {
        _serviceCollection.AddTransient<IComponentActivator, TComponent>();
    }

    public void Build()
    {
        _serviceProvider = _serviceCollection.BuildServiceProvider();
    }

    public T Get<T>()
        where T : notnull
    {
        if (_serviceProvider is not null)
        {
            return _serviceProvider.GetRequiredService<T>();
        }
        
        throw new InvalidOperationException($"{nameof(ICoCoKernel)} wasn't been built.");
    }
}