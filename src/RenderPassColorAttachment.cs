using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

public struct RenderPassColorAttachment :
    IWebGpuFFIConvertible<RenderPassColorAttachment, RenderPassColorAttachmentFFI>
{
    public required TextureViewSource View;
    public uint DepthSlice;
    public TextureViewSource ResolveTarget;
    public Color ClearValue;
    public required LoadOp LoadOp;
    public required StoreOp StoreOp;

    static void IWebGpuFFIConvertible<RenderPassColorAttachment, RenderPassColorAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassColorAttachment input, out RenderPassColorAttachmentFFI dest)
    {
        dest = new RenderPassColorAttachmentFFI(
            view: input.View.GetHandle(),
            depthSlice: input.DepthSlice,
            resolveTarget: input.ResolveTarget.GetHandle(),
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