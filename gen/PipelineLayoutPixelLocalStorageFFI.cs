using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct PipelineLayoutPixelLocalStorageFFI
{
    public ChainedStruct Chain;
    public ulong TotalPixelLocalStorageSize;
    public nuint StorageAttachmentCount;
    public PipelineLayoutStorageAttachment* StorageAttachments;

    public PipelineLayoutPixelLocalStorageFFI() { }

}
