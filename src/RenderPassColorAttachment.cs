using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Auto)]
public struct RenderPassColorAttachment :
    IWebGpuFFIConvertible<RenderPassColorAttachment, RenderPassColorAttachmentFFI>
{
    public const uint DEPTH_SLICE_UNDEFINED = WebGPU_FFI.DEPTH_SLICE_UNDEFINED;

    public required TextureViewSource View;
    public uint? DepthSlice;
    public TextureViewSource ResolveTarget;
    public Color ClearValue;
    public required LoadOp LoadOp;
    public required StoreOp StoreOp;

    static void IWebGpuFFIConvertible<RenderPassColorAttachment, RenderPassColorAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassColorAttachment input, out RenderPassColorAttachmentFFI dest)
    {
        unsafe
        {
            dest = new RenderPassColorAttachmentFFI(
                view: input.View.GetHandle(),
                depthSlice: input.DepthSlice ?? DEPTH_SLICE_UNDEFINED,
                resolveTarget: input.ResolveTarget.GetHandle(),
                loadOp: input.LoadOp,
                storeOp: input.StoreOp,
                clearValue: input.ClearValue
            );
        }
    }

    static void IWebGpuFFIConvertibleAlloc<RenderPassColorAttachment, RenderPassColorAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassColorAttachment input, WebGpuAllocatorHandle allocator, out RenderPassColorAttachmentFFI dest)
    {
        ToFFI(in input, out dest);
    }
}