using System.Collections.Immutable;

namespace Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

public readonly struct ColorBuffer
{
    public IImmutableList<Pixel> Pixels { get; }

    public ColorBuffer(IImmutableList<Pixel> pixels)
    {
        Pixels = pixels;
    }
}
