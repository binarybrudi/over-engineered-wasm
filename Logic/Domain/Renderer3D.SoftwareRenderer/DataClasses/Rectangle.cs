using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.DataClasses;

internal struct Rectangle
{
    public readonly int X;
    public readonly int Y;
    public readonly int Width;
    public readonly int Height;
    public readonly ColorRgba ColorRgba;

    public Rectangle(int x, int y, int width, int height, ColorRgba colorRgba)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        ColorRgba = colorRgba;
    }
}
