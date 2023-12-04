namespace WebGpuSharp;

public ref partial struct BindGroupLayoutDescriptor
{
    public WGPURefText Label;
    public required ReadOnlySpan<BindGroupLayoutEntry> Entries;
}