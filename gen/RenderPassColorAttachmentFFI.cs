using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassColorAttachmentFFI
{
    public ChainedStruct* NextInChain;
    public TextureViewHandle View;
    public uint DepthSlice;
    public TextureViewHandle ResolveTarget;
    public LoadOp LoadOp;
    public StoreOp StoreOp;
    public Color ClearValue;

    public RenderPassColorAttachmentFFI()
    {
    }


    public RenderPassColorAttachmentFFI(ChainedStruct* nextInChain = default, TextureViewHandle view = default, uint depthSlice = default, TextureViewHandle resolveTarget = default, LoadOp loadOp = default, StoreOp storeOp = default, Color clearValue = default)
    {
        this.NextInChain = nextInChain;
        this.View = view;
        this.DepthSlice = depthSlice;
        this.ResolveTarget = resolveTarget;
        this.LoadOp = loadOp;
        this.StoreOp = storeOp;
        this.ClearValue = clearValue;
    }


    public RenderPassColorAttachmentFFI(TextureViewHandle view = default, uint depthSlice = default, TextureViewHandle resolveTarget = default, LoadOp loadOp = default, StoreOp storeOp = default, Color clearValue = default)
    {
        this.View = view;
        this.DepthSlice = depthSlice;
        this.ResolveTarget = resolveTarget;
        this.LoadOp = loadOp;
        this.StoreOp = storeOp;
        this.ClearValue = clearValue;
    }

}
