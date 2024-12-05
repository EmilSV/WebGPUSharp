using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct StaticSamplerBindingLayoutFFI
{
    public ChainedStruct Chain = new();
    public SamplerHandle Sampler;
    public uint SampledTextureBinding;

    public StaticSamplerBindingLayoutFFI() { }

}
