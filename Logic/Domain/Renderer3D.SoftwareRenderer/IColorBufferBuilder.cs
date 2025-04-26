using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer;

public interface IColorBufferBuilder
{
    ColorBuffer Build();
    IColorBufferBuilder SetDimensions(RenderDimensions dimensions);
    IColorBufferBuilder Fill(Pixel pixel);
}
