using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassPixelLocalStorageFFI
{
    public ChainedStruct Chain = new();
    public ulong TotalPixelLocalStorageSize;
    public nuint StorageAttachmentCount;
    public RenderPassStorageAttachmentFFI* StorageAttachments;

    public RenderPassPixelLocalStorageFFI() { }

}
