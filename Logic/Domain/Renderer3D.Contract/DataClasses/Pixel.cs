namespace Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

public readonly struct Pixel
{
    public byte Alpha { get; }
    public byte Red { get; }
    public byte Green { get; }
    public byte Blue { get; }
    
    public Pixel() : this(0, 0, 0, byte.MaxValue) { }

    public Pixel(byte red, byte green, byte blue, byte alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }
}
