using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct BindGroupDescriptor
{
    public WGPURefText Label;
    public BindGroupLayoutHandle Layout;
    public ReadOnlySpan<BindGroupEntryFFI> Entries;
}