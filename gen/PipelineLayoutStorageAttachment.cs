using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct PipelineLayoutStorageAttachment
{
    public ChainedStruct* NextInChain;
    public ulong Offset;
    public TextureFormat Format;

    public PipelineLayoutStorageAttachment() { }

}
