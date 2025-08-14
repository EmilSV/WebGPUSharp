using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="RenderPassColorAttachmentFFI"/>
[StructLayout(LayoutKind.Auto)]
public struct RenderPassColorAttachment :
    IWebGpuFFIConvertibleAlloc<RenderPassColorAttachment, RenderPassColorAttachmentFFI>
{

    /// <inheritdoc cref="RenderPassColorAttachmentFFI.View"/>
    public required TextureView? View;
    /// <inheritdoc cref="RenderPassColorAttachmentFFI.DepthSlice"/>
    public uint? DepthSlice;
    /// <inheritdoc cref="RenderPassColorAttachmentFFI.ResolveTarget"/>
    public TextureView? ResolveTarget;
    /// <inheritdoc cref="RenderPassColorAttachmentFFI.ClearValue"/>
    public Color ClearValue;
    /// <inheritdoc cref="RenderPassColorAttachmentFFI.LoadOp"/>
    public required LoadOp LoadOp;
    /// <inheritdoc cref="RenderPassColorAttachmentFFI.StoreOp"/>
    public required StoreOp StoreOp;

    static void IWebGpuFFIConvertibleAlloc<RenderPassColorAttachment, RenderPassColorAttachmentFFI>.UnsafeConvertToFFI(
        in RenderPassColorAttachment input,
        WebGpuAllocatorHandle allocator,
        out RenderPassColorAttachmentFFI dest)
    {
        dest = new()
        {
            View = allocator.GetHandle(input.View),
            DepthSlice = input.DepthSlice ?? WebGPU_FFI.DEPTH_SLICE_UNDEFINED,
            ResolveTarget = allocator.GetHandle(input.ResolveTarget),
            LoadOp = input.LoadOp,
            StoreOp = input.StoreOp,
            ClearValue = input.ClearValue
        };
    }

}