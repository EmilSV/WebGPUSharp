using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A surface source for a Wayland surface.
/// </summary>
public unsafe partial struct SurfaceSourceWaylandSurfaceFFI
{
    public ChainedStruct Chain;
    /// <summary>
    /// The Wayland display.
    /// </summary>
    public void* Display;
    /// <summary>
    /// The Wayland surface.
    /// </summary>
    public void* Surface;

    public SurfaceSourceWaylandSurfaceFFI() { }

}
