using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderBundleDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public RenderBundleDescriptorFFI()
    {
    }


    public RenderBundleDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
    }


    public RenderBundleDescriptorFFI(byte* label = default)
    {
        this.Label = label;
    }

}
