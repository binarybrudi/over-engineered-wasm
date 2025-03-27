using Brudibytes.Core.Contract.DependencyInjection;

namespace Diamond.Vertical.ComponentMapping;

public class ComponentMap : IComponentMap
{
    public void Initialize(ICoCoKernel kernel)
    {
        InitializeDomainLogic(kernel);
    }

    private void InitializeDomainLogic(ICoCoKernel kernel)
    {
        kernel.RegisterComponent<Logic.Domain.Weather.Activator>();
    }
}
