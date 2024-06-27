using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct RenderPassDescriptorMaxDrawCount
{
    public ChainedStruct Chain;
    public ulong MaxDrawCount;

    public RenderPassDescriptorMaxDrawCount()
    {
    }


    public RenderPassDescriptorMaxDrawCount(ChainedStruct chain = default, ulong maxDrawCount = default)
    {
        this.Chain = chain;
        this.MaxDrawCount = maxDrawCount;
    }

}
