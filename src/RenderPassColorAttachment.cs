using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
namespace WebGpuSharp;

[StructLayout(LayoutKind.Auto)]
public struct RenderPassColorAttachment :
    IWebGpuFFIConvertibleAlloc<RenderPassColorAttachment, RenderPassColorAttachmentFFI>
{
    public const uint DEPTH_SLICE_UNDEFINED = WebGPU_FFI.DEPTH_SLICE_UNDEFINED;

    public required ITextureViewSource View;
    public uint? DepthSlice;
    public ITextureViewSource? ResolveTarget;
    public Color ClearValue;
    public required LoadOp LoadOp;
    public required StoreOp StoreOp;

    static void IWebGpuFFIConvertibleAlloc<RenderPassColorAttachment, RenderPassColorAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassColorAttachment input,
        WebGpuAllocatorHandle allocator,
        out RenderPassColorAttachmentFFI dest)
    {
        var ownedViewHandle = input.View.UnsafeGetCurrentTextureViewOwnedHandle();
        var ownedResolveTargetHandle = input.ResolveTarget != null ?
            input.ResolveTarget.UnsafeGetCurrentTextureViewOwnedHandle() :
            TextureViewHandle.Null;
        allocator.AddHandleToDispose(ownedViewHandle);

        if (TextureViewHandle.IsNull(ownedResolveTargetHandle))
        {
            allocator.AddHandleToDispose(ownedResolveTargetHandle);
        }

        dest = new(
            view: ownedViewHandle,
            depthSlice: input.DepthSlice ?? DEPTH_SLICE_UNDEFINED,
            resolveTarget: ownedResolveTargetHandle,
            loadOp: input.LoadOp,
            storeOp: input.StoreOp,
            clearValue: input.ClearValue
        );
    }

}