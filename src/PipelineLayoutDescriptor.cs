using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct PipelineLayoutDescriptor
{
    public WGPURefText Label;
    required public ReadOnlySpan<BindGroupLayout> BindGroupLayouts;
}