using WebGpuSharp.FFI;

namespace WebGpuSharp;

/// <inheritdoc cref ="PipelineLayoutDescriptorFFI"/>
public ref partial struct PipelineLayoutDescriptor
{
    /// <inheritdoc cref ="PipelineLayoutDescriptorFFI.Label"/>
    public WGPURefText Label;
    /// <inheritdoc cref ="PipelineLayoutDescriptorFFI.BindGroupLayouts"/>
    public required ReadOnlySpan<BindGroupLayout> BindGroupLayouts;

    public uint ImmediateSize = WebGPU_FFI.LIMIT_U32_UNDEFINED;

    public PipelineLayoutDescriptor()
    {
    }
}