namespace WebGpuSharp;

/// <inheritdoc cref="FFI.ComputePipelineDescriptorFFI" />
public ref struct ComputePipelineDescriptor
{
    /// <inheritdoc cref="FFI.ComputePipelineDescriptorFFI.Label" />
    public WGPURefText Label;
    /// <inheritdoc cref="FFI.ComputePipelineDescriptorFFI.Layout" />
    public PipelineLayout? Layout;
    /// <inheritdoc cref="FFI.ComputePipelineDescriptorFFI.Compute" />
    public required ComputeState Compute;
}