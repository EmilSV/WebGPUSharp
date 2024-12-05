using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceSourceWaylandSurfaceFFI
{
    public ChainedStruct Chain = new();
    public void* Display;
    public void* Surface;

    public SurfaceSourceWaylandSurfaceFFI() { }

}
