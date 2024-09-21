using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderSourceSPIRVFFI
{
    public ChainedStruct Chain;
    public uint CodeSize;
    public uint* Code;

    public ShaderSourceSPIRVFFI()
    {
    }

}
