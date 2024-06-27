using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromWindowsHWNDFFI
{
    public ChainedStruct Chain;
    public void* Hinstance;
    public void* Hwnd;

    public SurfaceDescriptorFromWindowsHWNDFFI()
    {
    }


    public SurfaceDescriptorFromWindowsHWNDFFI(ChainedStruct chain = default, void* hinstance = default, void* hwnd = default)
    {
        this.Chain = chain;
        this.Hinstance = hinstance;
        this.Hwnd = hwnd;
    }

}
