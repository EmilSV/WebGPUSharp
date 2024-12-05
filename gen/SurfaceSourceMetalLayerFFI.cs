using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceSourceMetalLayerFFI
{
    public ChainedStruct Chain = new();
    public void* Layer;

    public SurfaceSourceMetalLayerFFI() { }

}
