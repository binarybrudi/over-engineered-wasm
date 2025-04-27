using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.DataClasses;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Mapping;

internal sealed class PixelMapper : IPixelMapper
{
    public ColorRgba[] From(MutableColorRgba[] from)
    {
        return from.Select(
            x => new ColorRgba(
                x.Red, 
                x.Green, 
                x.Blue, 
                x.Alpha)
            )
        .ToArray();
    }

    public void Map(ref ColorRgba from, ref MutableColorRgba to)
    {
        to.Alpha = from.Alpha;
        to.Red = from.Red;
        to.Green = from.Green;
        to.Blue = from.Blue;
    }
}
