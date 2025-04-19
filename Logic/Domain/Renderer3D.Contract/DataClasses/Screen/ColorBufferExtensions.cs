namespace Diamond.Logic.Domain.Renderer3D.Contract.DataClasses.Screen;

public static class ColorBufferExtensions
{
    public static byte[] ToRgba(this ColorBuffer colorBuffer)
    {
        var resultSize = colorBuffer.Buffer.Length * 4;
        var result = new byte[resultSize];

        var currentPosition = 0;
        foreach (var byteArray in colorBuffer.Buffer.Select(pixel => pixel.ToRgba()))
        {
            Buffer.BlockCopy(byteArray, 0, result, currentPosition, byteArray.Length);
            currentPosition += byteArray.Length;
        }

        return result;
    }
}
