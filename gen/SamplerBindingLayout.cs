using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SamplerBindingLayout
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Indicates the required type of a sampler bound to this bindings.
    /// </summary>
    public SamplerBindingType Type = SamplerBindingType.Filtering;

    public SamplerBindingLayout()
    {
    }

}
