using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassDepthStencilAttachmentFFI
{
    public TextureViewHandle View;
    public LoadOp DepthLoadOp;
    public StoreOp DepthStoreOp;
    public float DepthClearValue;
    public WebGPUBool DepthReadOnly;
    public LoadOp StencilLoadOp;
    public StoreOp StencilStoreOp;
    public uint StencilClearValue;
    public WebGPUBool StencilReadOnly;

    public RenderPassDepthStencilAttachmentFFI()
    {
    }


    public RenderPassDepthStencilAttachmentFFI(TextureViewHandle view = default, LoadOp depthLoadOp = default, StoreOp depthStoreOp = default, float depthClearValue = default, WebGPUBool depthReadOnly = default, LoadOp stencilLoadOp = default, StoreOp stencilStoreOp = default, uint stencilClearValue = default, WebGPUBool stencilReadOnly = default)
    {
        this.View = view;
        this.DepthLoadOp = depthLoadOp;
        this.DepthStoreOp = depthStoreOp;
        this.DepthClearValue = depthClearValue;
        this.DepthReadOnly = depthReadOnly;
        this.StencilLoadOp = stencilLoadOp;
        this.StencilStoreOp = stencilStoreOp;
        this.StencilClearValue = stencilClearValue;
        this.StencilReadOnly = stencilReadOnly;
    }

}
