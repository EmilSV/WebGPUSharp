using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct BufferBindingLayout
{
    public ChainedStruct* NextInChain;
    public BufferBindingType Type;
    public WebGPUBool HasDynamicOffset;
    public ulong MinBindingSize;

    public BufferBindingLayout()
    {
    }


    public BufferBindingLayout(ChainedStruct* nextInChain = default, BufferBindingType type = default, WebGPUBool hasDynamicOffset = default, ulong minBindingSize = default)
    {
        this.NextInChain = nextInChain;
        this.Type = type;
        this.HasDynamicOffset = hasDynamicOffset;
        this.MinBindingSize = minBindingSize;
    }


    public BufferBindingLayout(BufferBindingType type = default, WebGPUBool hasDynamicOffset = default, ulong minBindingSize = default)
    {
        this.Type = type;
        this.HasDynamicOffset = hasDynamicOffset;
        this.MinBindingSize = minBindingSize;
    }

}
