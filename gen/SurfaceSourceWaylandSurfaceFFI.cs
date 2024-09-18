using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceSourceWaylandSurfaceFFI
{
    public ChainedStruct Chain;
    public void* Display;
    public void* Surface;

    public SurfaceSourceWaylandSurfaceFFI()
    {
    }


    public SurfaceSourceWaylandSurfaceFFI(ChainedStruct chain = default, void* display = default, void* surface = default)
    {
        this.Chain = chain;
        this.Display = display;
        this.Surface = surface;
    }

}
