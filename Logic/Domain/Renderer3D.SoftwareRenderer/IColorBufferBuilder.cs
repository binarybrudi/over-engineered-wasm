using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.DataClasses;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer;

internal interface IColorBufferBuilder
{
    ColorBuffer Build();
    IColorBufferBuilder Clear(ColorRgba colorRgba);
    IColorBufferBuilder DrawGrid(int gap, ColorRgba colorRgba);
    IColorBufferBuilder DrawGridDots(int gap, ColorRgba colorRgba);
    IColorBufferBuilder DrawLine(int x1, int y1, int x2, int y2, ColorRgba colorRgba);
    IColorBufferBuilder DrawPixel(int x, int y, ColorRgba colorRgba);
    IColorBufferBuilder DrawRectangle(Rectangle rectangle);
    IColorBufferBuilder Fill(ColorRgba colorRgba);
    IColorBufferBuilder SetDimensions(RenderDimensions dimensions);
}
