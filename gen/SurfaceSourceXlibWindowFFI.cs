using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A surface source for an Xlib window.
/// </summary>
public unsafe partial struct SurfaceSourceXlibWindowFFI
{
    public ChainedStruct Chain;
    /// <summary>
    /// The Xlib display.
    /// </summary>
    public void* Display;
    /// <summary>
    /// The Xlib window.
    /// </summary>
    public ulong Window;

    public SurfaceSourceXlibWindowFFI() { }

}
