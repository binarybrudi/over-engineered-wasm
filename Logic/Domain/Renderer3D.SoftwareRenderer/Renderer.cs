using Diamond.Logic.Domain.Renderer3D.Contract;
using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses.Screen;
using Diamond.Logic.Domain.Renderer3D.Contract.Events;
using Diamond.Logic.Domain.Renderer3D.Contract.Exceptions;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Settings;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer;

internal class Renderer : IRenderer
{
    private readonly IFrameLimiter _frameLimiter;
    private readonly ISettingsSetter _settingsSetter;
    private Settings.Settings _settings;
    public event EventHandler<ColorBufferCreatedEventArgs>? BufferCreated;

    public Renderer(
        IFrameLimiter frameLimiter,
        ISettingsSetter settingsSetter)
    {
        _frameLimiter = frameLimiter;
        _settingsSetter = settingsSetter;
    }

    public void Initialize(RenderSettings settings)
    {
        _settings = _settingsSetter.Set(settings, _settings);
    }

    public void StartRenderLoop()
    {
        CheckInitialized();
        Task.Run(async () => await RenderLoopAsync());
    }

    public void UpdateSetting(RenderSettings settings)
    {
        _settings = _settingsSetter.Set(settings, _settings);
    }
    
        
    private void CheckInitialized()
    {
        if (_settings.IsInitialized is false)
        {
            throw new RendererNotInitializedException();
        }
    }

    private async Task RenderLoopAsync()
    {
        _settings.IsRunning = true;
        var colorBuffer = new ColorBuffer(_settings.PixelCount);
        while (_settings.IsRunning)
        {
            try
            {
                _frameLimiter.Restart();
                foreach (var pixel in colorBuffer.Buffer)
                {
                    pixel.Alpha = 255;
                    pixel.Red = 255;
                    pixel.Green = 0;
                    pixel.Blue = 0;
                }
            
                RaiseBufferCreated(colorBuffer);
                await _frameLimiter.SleepAsync(_settings.TargetFrameTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    private void RaiseBufferCreated(ColorBuffer buffer)
    {
        BufferCreated?.DynamicInvoke(this, new ColorBufferCreatedEventArgs(buffer));
    }
    
}
