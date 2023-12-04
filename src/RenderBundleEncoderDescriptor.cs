namespace WebGpuSharp;

public ref struct RenderBundleEncoderDescriptor
{
    public WGPURefText Label;
    public required ReadOnlySpan<TextureFormat> ColorFormats;
    public TextureFormat DepthStencilFormat;
    public uint SampleCount = 1;
    public WGPUBool DepthReadOnly = false;
    public WGPUBool StencilReadOnly = false;

    public RenderBundleEncoderDescriptor()
    {
    }
}

