using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public SurfaceDescriptorFFI()
    {
    }


    public SurfaceDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
    }


    public SurfaceDescriptorFFI(byte* label = default)
    {
        this.Label = label;
    }

}
