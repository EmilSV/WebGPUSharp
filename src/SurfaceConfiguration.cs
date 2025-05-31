namespace WebGpuSharp;

/// <inheritdoc cref="FFI.SurfaceConfigurationFFI" />
public ref struct SurfaceConfiguration
{
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.Device" />
    public Device Device;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.Format" />
    public TextureFormat Format;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.Usage" />
    public TextureUsage Usage;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.ViewFormats" />
    public ReadOnlySpan<TextureFormat> ViewFormats;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.AlphaMode" />
    public CompositeAlphaMode AlphaMode;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.Width" />
    public uint Width;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.Height" />
    public uint Height;
    /// <inheritdoc cref="FFI.SurfaceConfigurationFFI.PresentMode" />
    public PresentMode PresentMode;
}