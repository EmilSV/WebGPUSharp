using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryVkImageLayoutEndState
{
    public ChainedStructOut Chain;
    public int OldLayout;
    public int NewLayout;

    public SharedTextureMemoryVkImageLayoutEndState()
    {
    }


    public SharedTextureMemoryVkImageLayoutEndState(ChainedStructOut chain = default, int oldLayout = default, int newLayout = default)
    {
        this.Chain = chain;
        this.OldLayout = oldLayout;
        this.NewLayout = newLayout;
    }

}
