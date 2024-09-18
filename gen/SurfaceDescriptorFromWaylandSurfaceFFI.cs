using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromWaylandSurfaceFFI
{
    public SurfaceSourceWaylandSurfaceFFI Value;

    public SurfaceDescriptorFromWaylandSurfaceFFI()
    {
    }


    public SurfaceDescriptorFromWaylandSurfaceFFI(SurfaceSourceWaylandSurfaceFFI value = default)
    {
        this.Value = value;
    }

}
