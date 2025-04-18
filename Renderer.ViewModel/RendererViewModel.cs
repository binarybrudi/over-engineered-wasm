using Brudibytes.MVVM;
using Diamond.Logic.Domain.Renderer3D.Contract;
using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses.Screen;
using Diamond.Logic.ViewModel.Renderer.ViewModel.Contract;
using Diamond.Logic.ViewModel.Renderer.ViewModel.Contract.DataClasses;

namespace Diamond.Logic.ViewModel.Renderer.ViewModel;

public class RendererViewModel : ViewModelBase, IRendererViewModel
{
    private readonly ComputationService _computationService;
    private readonly IRenderer _renderer;
    private Dimensions _dimensions = new(){ Height = 100, Width = 100};
    private Func<byte[], Task> _callback;

    public Dimensions Dimensions
    {
        get  => _dimensions;
        private set => SetField(ref _dimensions, value);
    }

    public void SetDimensions(Dimensions dimensions)
    {
        Dimensions = dimensions;
        Console.WriteLine(Dimensions);
    }

    public void SetAsyncCallback(Func<byte[], Task> callback)
    {
        _callback = callback;
    }

    public RendererViewModel(
        ComputationService computationService,
        IRenderer renderer)
    {
        _computationService = computationService;
        _computationService.BufferCreated += ComputationServiceOnBufferCreated;
        _renderer = renderer;
        _callback = _ => Task.CompletedTask;
    }

    private void ComputationServiceOnBufferCreated(ColorBuffer obj)
    {
        OnBufferCreated(obj);
    }

    public async Task StartRendering()
    {
        _renderer.Initialize(new RenderSettings()
        {
            TargetFrameRate = 10,
            Dimensions = new() { Height = Dimensions.Height, Width = Dimensions.Width },
            OnCreatedNextColorBuffer = OnBufferCreated
        });
        await _computationService.ComputeAsync(_renderer);
    }

    private Task OnBufferCreated(ColorBuffer colorBuffer)
    {
        var rgba = colorBuffer.ToRgba();
        return _callback(rgba);
    }
}
