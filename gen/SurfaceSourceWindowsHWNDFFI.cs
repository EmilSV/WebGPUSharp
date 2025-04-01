using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A surface source for a Windows HWND.
/// </summary>
public unsafe partial struct SurfaceSourceWindowsHWNDFFI
{
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
