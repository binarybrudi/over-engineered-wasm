using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.DataClasses;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Mapping;

internal sealed class PixelMapper : IPixelMapper
{
    public Pixel[] From(MutablePixel[] from)
    {
        return from.Select(
            x => new Pixel(
                x.Red, 
                x.Green, 
                x.Blue, 
                x.Alpha)
            )
        .ToArray();
    }

    public void Map(ref Pixel from, ref MutablePixel to)
    {
        to.Alpha = from.Alpha;
        to.Red = from.Red;
        to.Green = from.Green;
        to.Blue = from.Blue;
    }
}
