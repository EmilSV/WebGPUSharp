using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedTextureMemoryVkImageLayoutEndState
{
    public ChainedStructOut Chain = new();
    public int OldLayout;
    public int NewLayout;

    public SharedTextureMemoryVkImageLayoutEndState() { }

}
