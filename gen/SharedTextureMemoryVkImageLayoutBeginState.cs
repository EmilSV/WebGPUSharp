using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryVkImageLayoutBeginState
{
    public ChainedStruct Chain;
    public int OldLayout;
    public int NewLayout;

    public SharedTextureMemoryVkImageLayoutBeginState()
    {
    }


    public SharedTextureMemoryVkImageLayoutBeginState(ChainedStruct chain = default, int oldLayout = default, int newLayout = default)
    {
        this.Chain = chain;
        this.OldLayout = oldLayout;
        this.NewLayout = newLayout;
    }

}
