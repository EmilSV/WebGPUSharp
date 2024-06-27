using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct PipelineLayoutPixelLocalStorageFFI
{
    public ChainedStruct Chain;
    public ulong TotalPixelLocalStorageSize;
    public nuint StorageAttachmentCount;
    public PipelineLayoutStorageAttachment* StorageAttachments;

    public PipelineLayoutPixelLocalStorageFFI()
    {
    }


    public PipelineLayoutPixelLocalStorageFFI(ChainedStruct chain = default, ulong totalPixelLocalStorageSize = default, nuint storageAttachmentCount = default, PipelineLayoutStorageAttachment* storageAttachments = default)
    {
        this.Chain = chain;
        this.TotalPixelLocalStorageSize = totalPixelLocalStorageSize;
        this.StorageAttachmentCount = storageAttachmentCount;
        this.StorageAttachments = storageAttachments;
    }

}
