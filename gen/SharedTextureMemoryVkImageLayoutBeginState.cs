using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryVkImageLayoutBeginState
{
    public ChainedStruct Chain;
    public int OldLayout;
    public int NewLayout;

    public SharedTextureMemoryVkImageLayoutBeginState() { }

}
