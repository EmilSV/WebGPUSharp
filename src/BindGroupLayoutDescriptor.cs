namespace WebGpuSharp;

/// <inheritdoc cref="FFI.BindGroupLayoutDescriptorFFI"/>
public ref partial struct BindGroupLayoutDescriptor
{
    public WGPURefText Label;
    public required ReadOnlySpan<BindGroupLayoutEntry> Entries;
}