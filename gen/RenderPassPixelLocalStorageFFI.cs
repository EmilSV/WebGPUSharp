using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderPassPixelLocalStorageFFI
{
    public ChainedStruct Chain;
    public ulong TotalPixelLocalStorageSize;
    public nuint StorageAttachmentCount;
    public RenderPassStorageAttachmentFFI* StorageAttachments;

    public RenderPassPixelLocalStorageFFI()
    {
    }


    public RenderPassPixelLocalStorageFFI(ChainedStruct chain = default, ulong totalPixelLocalStorageSize = default, nuint storageAttachmentCount = default, RenderPassStorageAttachmentFFI* storageAttachments = default)
    {
        this.Chain = chain;
        this.TotalPixelLocalStorageSize = totalPixelLocalStorageSize;
        this.StorageAttachmentCount = storageAttachmentCount;
        this.StorageAttachments = storageAttachments;
    }

}
