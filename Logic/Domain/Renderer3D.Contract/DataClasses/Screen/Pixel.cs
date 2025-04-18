namespace Diamond.Logic.Domain.Renderer3D.Contract.DataClasses.Screen;

public record Pixel
{
    public byte Alpha { get; set; }
    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }
}
