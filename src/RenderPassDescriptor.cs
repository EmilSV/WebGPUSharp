using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct RenderPassDescriptor
{
    public WGPURefText label;
    public ReadOnlySpan<RenderPassColorAttachmentFFI> ColorAttachments;
    public ref RenderPassDepthStencilAttachmentFFI DepthStencilAttachment;
}