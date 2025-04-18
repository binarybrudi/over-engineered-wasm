namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer;

internal interface IFrameLimiter
{
    void Restart();
    int CalculateSleepTime(float targetFrameTime);
    Task SleepAsync(float targetFrameTime);
    void Stop();
}
