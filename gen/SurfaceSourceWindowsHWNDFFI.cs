using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceSourceWindowsHWNDFFI
{
    public ChainedStruct Chain;
    public void* Hinstance;
    public void* Hwnd;

    public SurfaceSourceWindowsHWNDFFI()
    {
    }

}
