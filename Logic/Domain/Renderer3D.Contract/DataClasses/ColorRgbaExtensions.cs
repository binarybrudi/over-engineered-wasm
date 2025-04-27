namespace Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

public static class ColorRgbaExtensions
{
    public static byte[] ToRgba(this ColorRgba colorRgba)
    {
        return [colorRgba.Red, colorRgba.Green, colorRgba.Blue, colorRgba.Alpha];
    }
}
