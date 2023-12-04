using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct RenderPassDescriptor
{
    public WGPURefText label;
    public required  ReadOnlySpan<RenderPassColorAttachment> ColorAttachments;
    public WGPUNullableRef<RenderPassDepthStencilAttachment> DepthStencilAttachment;
    public QuerySet? OcclusionQuerySet;
    public WGPUNullableRef<RenderPassTimestampWrites> TimestampWrites;
}