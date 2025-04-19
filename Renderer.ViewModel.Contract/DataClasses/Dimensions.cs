using System.Diagnostics;

namespace Diamond.Logic.ViewModel.Renderer.ViewModel.Contract.DataClasses;

[DebuggerDisplay("{Width}x{Height}")]
public record Dimensions()
{
    public int Width { get; init; }
    public int Height { get; init; }
}
