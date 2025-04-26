namespace Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

public record RenderSettings
{
    public int TargetFrameRate { get; init; } = 30;
    public required RenderDimensions Dimensions { get; init; }
    public required Func<ColorBuffer, Task> OnCreatedNextColorBuffer { get; init; }
}
