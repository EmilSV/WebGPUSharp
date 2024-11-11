using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
namespace WebGpuSharp;

[StructLayout(LayoutKind.Auto)]
public struct RenderPassColorAttachment :
    IWebGpuFFIConvertibleAlloc<RenderPassColorAttachment, RenderPassColorAttachmentFFI>
{
    public const uint DEPTH_SLICE_UNDEFINED = WebGPU_FFI.DEPTH_SLICE_UNDEFINED;

    public required TextureViewBase? View;
    public uint? DepthSlice;
    public TextureViewBase? ResolveTarget;
    public Color ClearValue;
    public required LoadOp LoadOp;
    public required StoreOp StoreOp;

    static void IWebGpuFFIConvertibleAlloc<RenderPassColorAttachment, RenderPassColorAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassColorAttachment input,
        WebGpuAllocatorHandle allocator,
        out RenderPassColorAttachmentFFI dest)
    {
        dest = new()
        {
            View = allocator.GetHandle(input.View),
            DepthSlice = input.DepthSlice ?? DEPTH_SLICE_UNDEFINED,
            ResolveTarget = allocator.GetHandle(input.ResolveTarget),
            LoadOp = input.LoadOp,
            StoreOp = input.StoreOp,
            ClearValue = input.ClearValue
        };
    }

}