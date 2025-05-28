namespace WebGpuSharp;

/// <inheritdoc cref="FFI.RenderBundleEncoderDescriptorFFI"/>
public ref struct RenderBundleEncoderDescriptor
{
    /// <inheritdoc cref="FFI.RenderBundleEncoderDescriptorFFI.Label"/>
    public WGPURefText Label;
    /// <inheritdoc cref="FFI.RenderBundleEncoderDescriptorFFI.ColorFormats"/>
    public required ReadOnlySpan<TextureFormat> ColorFormats;
    /// <inheritdoc cref="FFI.RenderBundleEncoderDescriptorFFI.DepthStencilFormat"/>
    public TextureFormat DepthStencilFormat;
    /// <inheritdoc cref="FFI.RenderBundleEncoderDescriptorFFI.SampleCount"/>
    public uint SampleCount = 1;
    /// <inheritdoc cref="FFI.RenderBundleEncoderDescriptorFFI.DepthReadOnly"/>
    public WebGPUBool DepthReadOnly = false;
    /// <inheritdoc cref="FFI.RenderBundleEncoderDescriptorFFI.StencilReadOnly"/>
    public WebGPUBool StencilReadOnly = false;

    public RenderBundleEncoderDescriptor()
    {
    }
}
