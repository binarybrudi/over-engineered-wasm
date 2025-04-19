using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

namespace Diamond.Logic.Domain.Renderer3D.Contract;

public interface IRenderer
{
    void Initialize(RenderSettings settings);
    Task StartRenderLoopAsync();
    void UpdateSetting(RenderSettings settings);
}
