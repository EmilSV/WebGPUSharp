using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct PipelineLayoutDescriptor
{
    public WGPURefText Label;
    public ReadOnlySpan<BindGroupLayoutHandle> BindGroupLayouts;
}