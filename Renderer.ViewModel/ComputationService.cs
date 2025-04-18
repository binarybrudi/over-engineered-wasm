using Diamond.Logic.Domain.Renderer3D.Contract;
using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses.Screen;
using Diamond.Logic.Domain.Renderer3D.Contract.Events;

namespace Diamond.Logic.ViewModel.Renderer.ViewModel;

public class ComputationService
{
    private ColorBuffer? _colorBufferResult;
    public event Action<ColorBuffer>? BufferCreated;
    
    /// <summary>
    /// Performs a computation that allows UI updates during processing
    /// </summary>
    public async Task<ColorBuffer> ComputeAsync(IRenderer renderer, CancellationToken cancellationToken = default)
    {
        // Create a TaskCompletionSource to control the completion of the operation
        var tcs = new TaskCompletionSource<ColorBuffer>();
        
        // Start the computation in a separate "logical" thread
        // Note: This doesn't create a true thread in WebAssembly
        _ = Task.Run(async () =>
        {
            try
            {
                renderer.BufferCreated += RendererOnBufferCreated;
                renderer.StartRenderLoop();

                for (;;)
                {
                    // Check cancellation
                    if (cancellationToken.IsCancellationRequested)
                    {
                        tcs.SetCanceled();
                        return;
                    }
                    
                    // Important: Allow the UI thread to process
                    // This is the key to keeping the UI responsive
                    await Task.Delay(1);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                tcs.SetException(ex);
            }
            finally
            {
                renderer.BufferCreated -= RendererOnBufferCreated;
            }
        });
        
        // Return the Task that will complete when computation is done
        return await tcs.Task;
    }

    private void RendererOnBufferCreated(object? sender, ColorBufferCreatedEventArgs e)
    {
        _colorBufferResult = e.Buffer;
        BufferCreated?.Invoke(e.Buffer);
    }
}
