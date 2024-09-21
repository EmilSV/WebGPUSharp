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


    public SamplerBindingLayout(ChainedStruct* nextInChain = default, SamplerBindingType type = SamplerBindingType.Filtering)
    {
        this.NextInChain = nextInChain;
        this.Type = type;
    }


    public SamplerBindingLayout(SamplerBindingType type = SamplerBindingType.Filtering)
    {
        this.Type = type;
    }

}
