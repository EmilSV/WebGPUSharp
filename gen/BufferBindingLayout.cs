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


    public BufferBindingLayout(ChainedStruct* nextInChain = default, BufferBindingType type = BufferBindingType.Uniform, WebGPUBool hasDynamicOffset = false, ulong minBindingSize = 0)
    {
        this.NextInChain = nextInChain;
        this.Type = type;
        this.HasDynamicOffset = hasDynamicOffset;
        this.MinBindingSize = minBindingSize;
    }


    public BufferBindingLayout(BufferBindingType type = BufferBindingType.Uniform, WebGPUBool hasDynamicOffset = false, ulong minBindingSize = 0)
    {
        this.Type = type;
        this.HasDynamicOffset = hasDynamicOffset;
        this.MinBindingSize = minBindingSize;
    }

}
