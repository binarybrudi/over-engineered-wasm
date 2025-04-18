using System.Diagnostics;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer;

internal sealed class FrameLimiter : IFrameLimiter
{
    private readonly Stopwatch _stopwatch = new();
    
    public void Restart()
    {
        _stopwatch.Restart();
    }

    public int CalculateSleepTime(float targetFrameTime)
    {
        float frameProcessingTime = _stopwatch.ElapsedMilliseconds;
        var sleepTime = (int)Math.Max(0, targetFrameTime - frameProcessingTime);
        return sleepTime;
    }

    public async Task SleepAsync(float targetFrameTime)
    {
        var sleepTime = CalculateSleepTime(targetFrameTime);
        if (sleepTime == 0) return;
        await Task.Delay(sleepTime);
    }


    public void Stop()
    {
        _stopwatch.Stop();
    }
}
