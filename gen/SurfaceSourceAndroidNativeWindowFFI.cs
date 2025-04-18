using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A surface source for a native Android window.
/// </summary>
public unsafe partial struct SurfaceSourceAndroidNativeWindowFFI
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    /// <summary>
    /// The native Android window.
    /// </summary>
    public void* Window;

    public SurfaceSourceAndroidNativeWindowFFI() { }

}
