namespace WebGpuSharp;

public ref struct RenderBundleEncoderDescriptor
{
    public WGPURefText Label;
    public required ReadOnlySpan<TextureFormat> ColorFormats;
    public TextureFormat DepthStencilFormat;
    public uint SampleCount = 1;
    public WebGPUBool DepthReadOnly = false;
    public WebGPUBool StencilReadOnly = false;

    public RenderBundleEncoderDescriptor()
    {
    }
}

