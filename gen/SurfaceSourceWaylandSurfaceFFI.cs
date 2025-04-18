using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A surface source for a Wayland surface.
/// </summary>
public unsafe partial struct SurfaceSourceWaylandSurfaceFFI
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
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
