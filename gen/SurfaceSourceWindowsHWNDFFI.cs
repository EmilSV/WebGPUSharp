using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A surface source for a Windows HWND.
/// </summary>
public unsafe partial struct SurfaceSourceWindowsHWNDFFI
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    /// <summary>
    /// The Windows HINSTANCE.
    /// </summary>
    public void* Hinstance;
    /// <summary>
    /// The Windows HWND.
    /// </summary>
    public void* Hwnd;

    public SurfaceSourceWindowsHWNDFFI() { }

}
