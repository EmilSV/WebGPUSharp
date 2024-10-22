using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;

    public SurfaceDescriptorFFI() { }

}
