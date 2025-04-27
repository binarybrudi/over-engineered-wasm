using Diamond.Logic.Domain.Renderer3D.Contract;
using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.Contract.Exceptions;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Constants;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.DataClasses;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Settings;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer;

internal class Renderer : IRenderer
{
    private readonly IColorBufferBuilder _colorBufferBuilder;
    private readonly IFrameLimiter _frameLimiter;
    private readonly ISettingsSetter _settingsSetter;
    private Settings.Settings _settings;
    private Func<ColorBuffer, Task>? _bufferCreated;

    public Renderer(
        IColorBufferBuilder colorBufferBuilder,
        IFrameLimiter frameLimiter,
        ISettingsSetter settingsSetter)
    {
        _colorBufferBuilder = colorBufferBuilder;
        _frameLimiter = frameLimiter;
        _settingsSetter = settingsSetter;
    }

    public void Initialize(RenderSettings settings)
    {
        ApplySettingsInternal(settings);
    }

    public async Task StartRenderLoopAsync()
    {
        CheckInitialized();
        await RenderLoopAsync();
    }

    public void UpdateSetting(RenderSettings settings)
    {
        ApplySettingsInternal(settings);
    }

    private void ApplySettingsInternal(RenderSettings settings)
    {
        _settings = _settingsSetter.Set(settings, _settings);
        _bufferCreated = settings.OnCreatedNextColorBuffer;
        _colorBufferBuilder.SetDimensions(settings.Dimensions);
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
        while (_settings.IsRunning)
        {
            _frameLimiter.Restart();

            Update();
            Render();

            await _frameLimiter.SleepAsync(_settings.TargetFrameTime);
        }
    }
    private void Update()
    {
        _colorBufferBuilder
            .DrawGrid(10, new(Rgba.Black))
            .DrawGridDots(10, new(Rgba.White))
            .DrawRectangle(new(1, 1, 8, 8, new(Rgba.Pink)));
    }

    private void Render()
    {
        RaiseBufferCreated(_colorBufferBuilder.Build());
        _colorBufferBuilder.Clear(new(Rgba.Yellow));
    }

    private void RaiseBufferCreated(ColorBuffer buffer)
    {
        _bufferCreated?.DynamicInvoke(buffer);
    }
}
