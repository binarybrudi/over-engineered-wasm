using System.Collections.Immutable;

namespace Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

public readonly struct ColorBuffer
{
    public IImmutableList<ColorRgba> Pixels { get; }

    public ColorBuffer(IImmutableList<ColorRgba> pixels)
    {
        Pixels = pixels;
    }
}
