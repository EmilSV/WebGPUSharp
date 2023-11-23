using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct RenderPassDescriptor
{
    public WGPURefText label;
    public ReadOnlySpan<RenderPassColorAttachment> ColorAttachments;
    public WGPUNullableRef<RenderPassDepthStencilAttachment> DepthStencilAttachment;
    public QuerySet? OcclusionQuerySet;
}