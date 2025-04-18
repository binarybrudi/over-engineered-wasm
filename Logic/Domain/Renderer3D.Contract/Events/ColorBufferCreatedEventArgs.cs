using Diamond.Logic.Domain.Renderer3D.Contract.DataClasses.Screen;

namespace Diamond.Logic.Domain.Renderer3D.Contract.Events;

public class ColorBufferCreatedEventArgs : EventArgs
{
    public ColorBuffer Buffer { get; init; }

    public ColorBufferCreatedEventArgs(ColorBuffer buffer)
    {
        Buffer = buffer;
    }
}
