namespace WebGpuSharp;

/// <inheritdoc cref="FFI.SurfaceConfigurationFFI" />
public ref struct SurfaceConfiguration
{
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.Device" />
    public required Device Device;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.Format" />
    public required TextureFormat Format;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.Usage" />
    public TextureUsage Usage = TextureUsage.RenderAttachment;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.ViewFormats" />
    public ReadOnlySpan<TextureFormat> ViewFormats;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.AlphaMode" />
    public CompositeAlphaMode AlphaMode = CompositeAlphaMode.Auto;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.Width" />
    public required uint Width;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.Height" />
    public required uint Height;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.PresentMode" />
    public PresentMode PresentMode = PresentMode.Fifo;

    public SurfaceConfiguration()
    {
    }
}