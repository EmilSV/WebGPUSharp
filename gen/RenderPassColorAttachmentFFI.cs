using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassColorAttachmentFFI
{
    public ChainedStruct* NextInChain;
    public required TextureViewHandle View;
    public uint DepthSlice;
    public TextureViewHandle ResolveTarget;
    public required LoadOp LoadOp;
    public required StoreOp StoreOp;
    public Color ClearValue;

    public RenderPassColorAttachmentFFI()
    {
    }

}
