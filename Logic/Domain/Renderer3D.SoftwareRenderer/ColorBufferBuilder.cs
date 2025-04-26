using System.Collections.Immutable;
using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.DataClasses;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Mapping;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer;

internal sealed class ColorBufferBuilder : IColorBufferBuilder
{
    private readonly IPixelMapper _pixelMapper;
    private MutablePixel[] _pixels = [];

    public ColorBufferBuilder(IPixelMapper pixelMapper)
    {
        _pixelMapper = pixelMapper;
    }

    public ColorBuffer Build()
    {
        var pixels = _pixelMapper.From(_pixels);
        return new ColorBuffer(ImmutableList.CreateRange(pixels));
    }

    public IColorBufferBuilder SetDimensions(RenderDimensions dimensions)
    {
        _pixels = new MutablePixel[dimensions.Width * dimensions.Height];
        for (var i = 0; i < _pixels.Length; i++)
        {
            _pixels[i] = new MutablePixel();
        }
        return this;
    }

    public IColorBufferBuilder Fill(Pixel pixel)
    {
        for (var i = 0; i < _pixels.Length; i++)
        {
            _pixelMapper.Map(ref pixel, ref _pixels[i]);
        }
        return this;
    }
}
