using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct BindGroupDescriptor
{
    public WGPURefText Label;
    public required BindGroupLayout Layout;
    public required ReadOnlySpan<BindGroupEntry> Entries;
}