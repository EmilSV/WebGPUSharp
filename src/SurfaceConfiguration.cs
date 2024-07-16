namespace WebGpuSharp;

public ref struct SurfaceConfiguration
{
    public Device Device;
    public TextureFormat Format;
    public TextureUsage Usage;
    public ReadOnlySpan<TextureFormat> ViewFormats;
    public CompositeAlphaMode AlphaMode;
    public uint Width;
    public uint Height;
    public PresentMode PresentMode;
}