using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct StaticSamplerBindingLayoutFFI
{
    public ChainedStruct Chain;
    public SamplerHandle Sampler;
    public uint SampledTextureBinding;

    public StaticSamplerBindingLayoutFFI()
    {
    }


    public StaticSamplerBindingLayoutFFI(ChainedStruct chain = default, SamplerHandle sampler = default, uint sampledTextureBinding = default)
    {
        this.Chain = chain;
        this.Sampler = sampler;
        this.SampledTextureBinding = sampledTextureBinding;
    }

}
