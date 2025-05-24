namespace WebGpuSharp;

/// <inheritdoc cref="FFI.QuerySetDescriptorFFI" />
public ref struct QuerySetDescriptor
{
    /// <inheritdoc cref="FFI.QuerySetDescriptorFFI.Label" />
    public WGPURefText Label;
    /// <inheritdoc cref="FFI.QuerySetDescriptorFFI.Type" />
    public required QueryType Type;
    /// <inheritdoc cref="FFI.QuerySetDescriptorFFI.Count" />
    public required uint Count;
}