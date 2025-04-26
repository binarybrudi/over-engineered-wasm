using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.DataClasses;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Mapping;

internal interface IPixelMapper
{
    Pixel[] From(MutablePixel[] from);
    void Map(ref Pixel from, ref MutablePixel to);
}
