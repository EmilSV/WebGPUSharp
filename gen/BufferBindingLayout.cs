using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct BufferBindingLayout
{
    public ChainedStruct* NextInChain;
    public BufferBindingType Type = BufferBindingType.Uniform;
    public WebGPUBool HasDynamicOffset = false;
    public ulong MinBindingSize = 0;

    public BufferBindingLayout()
    {
    }

}
