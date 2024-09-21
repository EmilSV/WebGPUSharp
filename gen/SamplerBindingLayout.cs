using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SamplerBindingLayout
{
    public ChainedStruct* NextInChain;
    public SamplerBindingType Type = SamplerBindingType.Filtering;

    public SamplerBindingLayout()
    {
    }

}
