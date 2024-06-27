using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct PipelineLayoutStorageAttachment
{
    public ChainedStruct* NextInChain;
    public ulong Offset;
    public TextureFormat Format;

    public PipelineLayoutStorageAttachment()
    {
    }


    public PipelineLayoutStorageAttachment(ChainedStruct* nextInChain = default, ulong offset = default, TextureFormat format = default)
    {
        this.NextInChain = nextInChain;
        this.Offset = offset;
        this.Format = format;
    }


    public PipelineLayoutStorageAttachment(ulong offset = default, TextureFormat format = default)
    {
        this.Offset = offset;
        this.Format = format;
    }

}
