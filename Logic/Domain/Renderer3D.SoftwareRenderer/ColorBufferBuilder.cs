using System.Collections.Immutable;
using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.DataClasses;
using Diamond.Logic.Domain.Renderer3D.SoftwareRenderer.Mapping;

namespace Diamond.Logic.Domain.Renderer3D.SoftwareRenderer;

internal sealed class ColorBufferBuilder : IColorBufferBuilder
{
    private readonly IPixelMapper _pixelMapper;
    private RenderDimensions _dimensions = new();
    private MutableColorRgba[] _pixels = [];

    private int Height => _dimensions.Height;
    private int Width => _dimensions.Width;

    public ColorBufferBuilder(IPixelMapper pixelMapper)
    {
        _pixelMapper = pixelMapper;
    }

    public ColorBuffer Build()
    {
        var pixels = _pixelMapper.From(_pixels);
        return new ColorBuffer(ImmutableList.CreateRange(pixels));
    }

    public IColorBufferBuilder Clear(ColorRgba colorRgba)
    {
        for (var i = 0; i < _pixels.Length; i++)
        {
            _pixelMapper.Map(ref colorRgba, ref _pixels[i]);
        }
        return this;
    }

    public IColorBufferBuilder DrawGrid(int gap, ColorRgba colorRgba)
    {
        for (var x = 0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                if (x % gap == 0 || y % gap == 0)
                {
                    DrawPixel(x, y, colorRgba);
                }
            }
        }
        return this;
    }

    public IColorBufferBuilder DrawGridDots(int gap, ColorRgba colorRgba)
    {
        for (var x = 0; x < Width; x += gap)
        {
            for (var y = 0; y < Height; y += gap)
            {
                DrawPixel(x, y, colorRgba);
            }
        }
        return this;
    }

    public IColorBufferBuilder DrawLine(int x1, int y1, int x2, int y2, ColorRgba colorRgba)
    {
        for (var x = x1; x <= x2; x++)
        {
            for (var y = y1; y <= y2; y++)
            {
                DrawPixel(x, y, colorRgba);
            }
        }
        return this;
    }

    public IColorBufferBuilder DrawPixel(int x, int y, ColorRgba colorRgba)
    {
        var row = y * Width;
        var column = x;
        var index = row + column;
        _pixelMapper.Map(ref colorRgba, ref _pixels[index]);
        return this;
    }

    public IColorBufferBuilder DrawRectangle(Rectangle rectangle)
    {
        for (var y = rectangle.Y; y <= rectangle.Y + rectangle.Height; y++)
        {
            DrawLine(rectangle.X, y, rectangle.X + rectangle.Width, y, rectangle.ColorRgba);
        }
        
        return this;
    }

    public IColorBufferBuilder SetDimensions(RenderDimensions dimensions)
    {
        _dimensions = dimensions;
        AllocateMutablePixels();
        return this;
    }
 
    public IColorBufferBuilder Fill(ColorRgba colorRgba)
    {
        for (var i = 0; i < _pixels.Length; i++)
        {
            _pixelMapper.Map(ref colorRgba, ref _pixels[i]);
        }
        return this;
    }
 
    private void AllocateMutablePixels()
    {
        _pixels = new MutableColorRgba[_dimensions.Width * _dimensions.Height];
        for (var i = 0; i < _pixels.Length; i++)
        {
            _pixels[i] = new MutableColorRgba();
        }
    }
}
