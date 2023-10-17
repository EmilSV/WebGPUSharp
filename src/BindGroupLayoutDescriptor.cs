namespace WebGpuSharp;

public ref partial struct BindGroupLayoutDescriptor
{
    public WGPURefText Label;
    public ReadOnlySpan<BindGroupLayoutEntry> Entries;
}