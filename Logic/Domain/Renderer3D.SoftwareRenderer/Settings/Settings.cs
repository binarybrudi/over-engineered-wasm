namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Settings;

internal struct Settings
{
    public bool IsInitialized { get; set; } = false;
    public bool IsRunning { get; set; } = false;
    public float TargetFrameTime { get; set; } = 1f;
    public int PixelCount { get; set; } = 0;

    public Settings()
    {
    }


}
