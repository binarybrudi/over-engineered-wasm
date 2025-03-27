using Brudibytes.Core.Contract.Bootstrapping;

namespace Brudibytes.Core.Contract.DependencyInjection;

public interface ICoCoKernel
{
    void AddTransient<TInterface, TImplementation>()
        where TInterface : class
        where TImplementation : class, TInterface;
    
    void RegisterComponent<TComponent>()
        where TComponent : class, IComponentActivator;

    void Build();
    
    T Get<T>()
        where T : notnull;
}
