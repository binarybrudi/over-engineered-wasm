using Brudibytes.Blazor;
using Diamond.Logic.ViewModel.Renderer.ViewModel.Contract;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Diamond.Ui.Renderer;

public partial class RendererView : ViewModelComponentBase<IRendererViewModel>
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _module;
    private ElementReference? _canvasElementReference;
    private DotNetObjectReference<RendererView>? _dotNetObjectReference;

    public RendererView(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    protected override async Task OnAfterFirstRenderAsync()
    {
        _dotNetObjectReference = DotNetObjectReference.Create(this);
        _module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Diamond.Ui.Renderer/RendererView.razor.js");
        await _module.InvokeVoidAsync("initCanvas", _canvasElementReference, _dotNetObjectReference);
        ViewModel.SetAsyncCallback(RenderFrameAsync);
        await ViewModel.StartRendering();
    }

    public async Task RenderFrameAsync(byte[] rgbaData)
    {
        if (_module is not null)
        {
            try
            {
                await _module.InvokeVoidAsync("renderFrame", _canvasElementReference, rgbaData);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error rendering frame: {ex.Message}");
            }
        }
    }

    [JSInvokable]
    public void NotifyCanvasResize(int width, int height)
    {
        if (ViewModel.Dimensions.Width != width
            || ViewModel.Dimensions.Height != height)
        {
            ViewModel.SetDimensions(new(){Height = height, Width = width});
        }
    }

    public override async ValueTask DisposeAsync()
    {
        _dotNetObjectReference?.Dispose();
 
        try
        {
            if (_module is not null)
            {
                await _module.InvokeVoidAsync("cleanupCanvas", _canvasElementReference);
                await _module.DisposeAsync();
            }
        }
        catch (JSDisconnectedException) { }
    }
}

