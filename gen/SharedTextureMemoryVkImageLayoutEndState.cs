using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryVkImageLayoutEndState
{
    public ChainedStructOut Chain;
    public int OldLayout;
    public int NewLayout;

    public SharedTextureMemoryVkImageLayoutEndState() { }

}
