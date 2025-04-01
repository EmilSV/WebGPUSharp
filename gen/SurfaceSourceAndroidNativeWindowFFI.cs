using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A surface source for a native Android window.
/// </summary>
public unsafe partial struct SurfaceSourceAndroidNativeWindowFFI
{
    public ChainedStruct Chain;
    /// <summary>
    /// The native Android window.
    /// </summary>
    public void* Window;

    public SurfaceSourceAndroidNativeWindowFFI() { }

}
