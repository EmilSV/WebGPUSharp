using WebGpuSharp.FFI;

namespace WebGpuSharp;

/// <inheritdoc cref="BindGroupDescriptorFFI"/>
public ref partial struct BindGroupDescriptor
{
    /// <inheritdoc cref="BindGroupDescriptorFFI.Label"/>
    public WGPURefText Label;
    /// <inheritdoc cref="BindGroupDescriptorFFI.Layout"/>
    public required BindGroupLayout Layout;
    /// <inheritdoc cref="BindGroupDescriptorFFI.Entries"/>
    public required ReadOnlySpan<BindGroupEntry> Entries;
}