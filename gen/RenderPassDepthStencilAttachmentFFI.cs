using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassDepthStencilAttachmentFFI
{
    public required TextureViewHandle View;
    public LoadOp DepthLoadOp;
    public StoreOp DepthStoreOp;
    public float DepthClearValue;
    public WebGPUBool DepthReadOnly = false;
    public LoadOp StencilLoadOp;
    public StoreOp StencilStoreOp;
    public uint StencilClearValue = 0;
    public WebGPUBool StencilReadOnly = false;

    public RenderPassDepthStencilAttachmentFFI()
    {
    }

}
