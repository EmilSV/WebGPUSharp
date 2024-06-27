using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public ShaderModuleDescriptorFFI()
    {
    }


    public ShaderModuleDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
    }


    public ShaderModuleDescriptorFFI(byte* label = default)
    {
        this.Label = label;
    }

}
