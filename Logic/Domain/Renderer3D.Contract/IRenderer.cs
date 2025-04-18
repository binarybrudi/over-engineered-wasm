using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.Contract.Events;

namespace Diamond.Logic.Domain.Renderer3D.Contract;

public interface IRenderer
{
    event EventHandler<ColorBufferCreatedEventArgs> BufferCreated;
    void Initialize(RenderSettings settings);
    void StartRenderLoop();
    void UpdateSetting(RenderSettings settings);
}
