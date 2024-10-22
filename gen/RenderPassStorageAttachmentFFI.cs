using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassStorageAttachmentFFI
{
    public ChainedStruct* NextInChain;
    public ulong Offset;
    public TextureViewHandle Storage;
    public LoadOp LoadOp;
    public StoreOp StoreOp;
    public Color ClearValue;

    public RenderPassStorageAttachmentFFI() { }

}
