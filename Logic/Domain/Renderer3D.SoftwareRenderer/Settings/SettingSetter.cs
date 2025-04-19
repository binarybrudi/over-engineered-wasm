using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Settings;

internal class SettingSetter : ISettingsSetter
{
    public Settings Set(RenderSettings settings, Settings container)
    {
        var fpsLimit = Math.Max(1, settings.TargetFrameRate);
        var targetFrameTime = 1000f / fpsLimit;

        container.IsInitialized = true;
        container.TargetFrameTime = targetFrameTime;
        container.PixelCount = settings.Dimensions.Width * settings.Dimensions.Height;

        return container;
    }
}
