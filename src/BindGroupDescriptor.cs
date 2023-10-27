using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct BindGroupDescriptor
{
    public WGPURefText Label;
    public BindGroupLayout Layout;
    public ReadOnlySpan<BindGroupEntryFFI> Entries;
}