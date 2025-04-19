using Brudibytes.Core.Contract.DependencyInjection;

namespace Diamond.Vertical.ComponentMapping;

public class ComponentMap : IComponentMap
{
    public void Initialize(ICoCoKernel kernel)
    {
        InitializeUi(kernel);
        InitializeDomainLogic(kernel);
        InitializeFoundationLogic(kernel);
        InitializeViewModel(kernel);
        InitializeData(kernel);
    }
    private void InitializeData(ICoCoKernel kernel)
    {
        kernel.RegisterComponent<Diamond.Data.Weather.Http.OpenMeteo.Activator>();
    }

    private void InitializeFoundationLogic(ICoCoKernel kernel)
    {
        kernel.RegisterComponent<Diamond.Logic.Foundation.Calendar.Activator>();
    }

    private void InitializeViewModel(ICoCoKernel kernel)
    {
        kernel.RegisterComponent<Diamond.Logic.ViewModel.Renderer.ViewModel.Activator>();
        kernel.RegisterComponent<Diamond.Logic.ViewModel.Weather.ViewModel.Activator>();
    }

    private void InitializeUi(ICoCoKernel kernel)
    {
        kernel.RegisterComponent<Diamond.Ui.Renderer.Activator>();
        kernel.RegisterComponent<Diamond.Ui.Weather.Activator>();
    }

    private void InitializeDomainLogic(ICoCoKernel kernel)
    {
        kernel.RegisterComponent<Logic.Domain.Renderer3D.SoftwareRenderer.Activator>();
        kernel.RegisterComponent<Logic.Domain.Weather.Activator>();
    }
}
