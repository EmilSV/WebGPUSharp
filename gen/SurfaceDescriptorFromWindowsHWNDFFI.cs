using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromWindowsHWNDFFI
{
    public SurfaceSourceWindowsHWNDFFI Value;

    public SurfaceDescriptorFromWindowsHWNDFFI()
    {
    }


    public SurfaceDescriptorFromWindowsHWNDFFI(SurfaceSourceWindowsHWNDFFI value = default)
    {
        this.Value = value;
    }

}
