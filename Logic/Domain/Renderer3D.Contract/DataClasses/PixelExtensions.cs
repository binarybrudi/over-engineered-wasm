namespace Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

public static class PixelExtensions
{
    public static byte[] ToRgba(this Pixel pixel)
    {
        return [pixel.Red, pixel.Green, pixel.Blue, pixel.Alpha];
    }
}
