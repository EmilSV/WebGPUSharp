using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp;

public struct RenderPassColorAttachment :
    IWebGpuFFIConvertible<RenderPassColorAttachment, RenderPassColorAttachmentFFI>
{
    public TextureView? View;
    public TextureView? ResolveTarget;
    public LoadOp LoadOp;
    public StoreOp StoreOp;
    public Color ClearValue;

    static void IWebGpuFFIConvertible<RenderPassColorAttachment, RenderPassColorAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassColorAttachment input, out RenderPassColorAttachmentFFI dest)
    {
        dest = new RenderPassColorAttachmentFFI(
            view: ToFFI<TextureView, TextureViewHandle>(input.View),
            resolveTarget: ToFFI<TextureView, TextureViewHandle>(input.ResolveTarget),
            loadOp: input.LoadOp,
            storeOp: input.StoreOp,
            clearValue: input.ClearValue
        );
    }

    static void IWebGpuFFIConvertibleAlloc<RenderPassColorAttachment, RenderPassColorAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassColorAttachment input, WebGpuAllocatorHandle allocator, out RenderPassColorAttachmentFFI dest)
    {
        ToFFI(in input, out dest);
    }
}