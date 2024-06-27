using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SamplerBindingLayout
{
    public ChainedStruct* NextInChain;
    public SamplerBindingType Type;

    public SamplerBindingLayout()
    {
    }


    public SamplerBindingLayout(ChainedStruct* nextInChain = default, SamplerBindingType type = default)
    {
        this.NextInChain = nextInChain;
        this.Type = type;
    }


    public SamplerBindingLayout(SamplerBindingType type = default)
    {
        this.Type = type;
    }

}
