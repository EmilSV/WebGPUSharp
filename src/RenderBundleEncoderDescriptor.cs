namespace WebGpuSharp;

public ref struct RenderBundleEncoderDescriptor
{
	public WGPURefText Label;
	public ReadOnlySpan<TextureFormat> ColorFormats;
	public TextureFormat DepthStencilFormat;
	public uint SampleCount;
	public WGPUBool DepthReadOnly;
	public WGPUBool StencilReadOnly;
}

