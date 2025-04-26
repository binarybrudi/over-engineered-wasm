using Brudibytes.Core.Contract.Bootstrapping;
using Brudibytes.Core.EventBus.Contract;
using Diamond.Logic.Domain.Renderer3D.Contract;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Mapping;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer;

public class Activator : IComponentActivator
{
    public void Activating() { }

    public void Activated() { }

    public void Deactivating() { }

    public void Deactivated() { }

    public void RegisterMappings(IServiceCollection serviceCollection)
    {
        // mapper
        serviceCollection.AddTransient<IPixelMapper, PixelMapper>();
        
        serviceCollection.AddScoped<ISettingsSetter, SettingSetter>();
        serviceCollection.AddTransient<IColorBufferBuilder, ColorBufferBuilder>();
        serviceCollection.AddTransient<IFrameLimiter, FrameLimiter>();
        serviceCollection.AddTransient<IRenderer, Renderer>();
    }

    public void AddMessageSubscriptions(IEventBus eventBus) { }
}
