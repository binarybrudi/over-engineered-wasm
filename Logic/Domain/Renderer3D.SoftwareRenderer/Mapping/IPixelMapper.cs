using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.DataClasses;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Mapping;

internal interface IPixelMapper
{
    ColorRgba[] From(MutableColorRgba[] from);
    void Map(ref ColorRgba from, ref MutableColorRgba to);
}
