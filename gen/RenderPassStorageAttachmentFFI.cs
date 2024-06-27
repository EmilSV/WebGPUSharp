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

    public RenderPassStorageAttachmentFFI()
    {
    }


    public RenderPassStorageAttachmentFFI(ChainedStruct* nextInChain = default, ulong offset = default, TextureViewHandle storage = default, LoadOp loadOp = default, StoreOp storeOp = default, Color clearValue = default)
    {
        this.NextInChain = nextInChain;
        this.Offset = offset;
        this.Storage = storage;
        this.LoadOp = loadOp;
        this.StoreOp = storeOp;
        this.ClearValue = clearValue;
    }


    public RenderPassStorageAttachmentFFI(ulong offset = default, TextureViewHandle storage = default, LoadOp loadOp = default, StoreOp storeOp = default, Color clearValue = default)
    {
        this.Offset = offset;
        this.Storage = storage;
        this.LoadOp = loadOp;
        this.StoreOp = storeOp;
        this.ClearValue = clearValue;
    }

}
