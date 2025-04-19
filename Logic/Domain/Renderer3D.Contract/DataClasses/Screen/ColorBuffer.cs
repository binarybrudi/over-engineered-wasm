namespace Diamond.Logic.Domain.Renderer3D.Contract.DataClasses.Screen;

public class ColorBuffer
{
    public Pixel[] Buffer { get; }

    public ColorBuffer(int size)
    {
        Buffer = new Pixel[size];
        for (int i = 0; i < size; i++)
        {
            Buffer[i] = new Pixel();
        }
    }
}
