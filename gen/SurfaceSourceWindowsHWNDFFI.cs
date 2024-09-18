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


    public SurfaceSourceWindowsHWNDFFI(ChainedStruct chain = default, void* hinstance = default, void* hwnd = default)
    {
        this.Chain = chain;
        this.Hinstance = hinstance;
        this.Hwnd = hwnd;
    }

}
