using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceSourceXCBWindowFFI
{
    public ChainedStruct Chain;
    public void* Connection;
    public uint Window;

    public SurfaceSourceXCBWindowFFI()
    {
    }

}
