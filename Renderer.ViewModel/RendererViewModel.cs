using Brudibytes.MVVM;
using Diamond.Logic.Domain.Renderer3D.Contract;
using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses.Screen;
using Diamond.Logic.ViewModel.Renderer.ViewModel.Contract;
using Diamond.Logic.ViewModel.Renderer.ViewModel.Contract.DataClasses;

namespace Diamond.Logic.ViewModel.Renderer.ViewModel;

internal class RendererViewModel : ViewModelBase, IRendererViewModel
{
    private readonly IRenderer _renderer;
    private Dimensions _dimensions = new() { Height = 100, Width = 100 };
    private Func<byte[], Task> _onBufferCreatedCallback;

    public Dimensions Dimensions
    {
        get => _dimensions;
        private set => SetField(ref _dimensions, value);
    }

    public void SetDimensions(Dimensions dimensions)
    {
        Dimensions = dimensions;
    }

    public RendererViewModel(
        IRenderer renderer)
    {
        _renderer = renderer;
        _onBufferCreatedCallback = _ => Task.CompletedTask;
    }

    public async Task StartRendering(Func<byte[], Task> onBufferCreatedCallback)
    {
        _onBufferCreatedCallback = onBufferCreatedCallback;
        _renderer.Initialize(new RenderSettings()
        {
            TargetFrameRate = 10,
            Dimensions = new() { Height = Dimensions.Height, Width = Dimensions.Width },
            OnCreatedNextColorBuffer = OnBufferCreated
        });
        await _renderer.StartRenderLoopAsync();
    }

    private Task OnBufferCreated(ColorBuffer colorBuffer)
    {
        var rgba = colorBuffer.ToRgba();
        return _onBufferCreatedCallback(rgba);
    }
}
