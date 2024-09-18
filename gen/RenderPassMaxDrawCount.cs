using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct RenderPassMaxDrawCount
{
    public ChainedStruct Chain;
    public ulong MaxDrawCount;

    public RenderPassMaxDrawCount()
    {
    }


    public RenderPassMaxDrawCount(ChainedStruct chain = default, ulong maxDrawCount = default)
    {
        this.Chain = chain;
        this.MaxDrawCount = maxDrawCount;
    }

}
