namespace Diamond.Logic.Domain.Renderer3D.Contract.DataClasses;

public readonly struct ColorRgba
{
    public byte Alpha { get; }
    public byte Red { get; }
    public byte Green { get; }
    public byte Blue { get; }
    
    public ColorRgba() : this(0, 0, 0, byte.MaxValue) { }

    public ColorRgba(byte red, byte green, byte blue, byte alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }
    
    /// <summary>
    /// Create the instance using a 32-bit unsigned integer where:
    /// <list type="bullet">
    /// <item><description>Bits 31-24 represent the red channel</description></item>
    /// <item><description>Bits 23-16 represent the green channel</description></item>
    /// <item><description>Bits 15-8 represent the blue channel</description></item>
    /// <item><description>Bits 7-0 represent the alpha channel</description></item>
    /// </list>
    /// </summary>
    /// <param name="rgba">uint32 value will be split into its individual byte components for red, green, blue, and alpha channels.</param>
    /// <remarks>
    /// Each component is extracted using bit shifting (<c>&gt;&gt;</c>) and masking (<c>&amp; 0xFF</c>) operations, then cast to a byte.
    /// </remarks>
    /// <example>
    /// <code>var pixel = new Pixel(0xFF00FF80); // R:255, G:0, B:255, A:128</code>
    /// </example>
    public ColorRgba(uint rgba)
    {
        Red = (byte)((rgba >> 24) & 0xFF);
        Green = (byte)((rgba >> 16) & 0xFF);
        Blue = (byte)((rgba >> 8) & 0xFF);
        Alpha = (byte)(rgba & 0xFF);
    }
}
