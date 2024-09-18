using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromAndroidNativeWindowFFI
{
    public SurfaceSourceAndroidNativeWindowFFI Value;

    public SurfaceDescriptorFromAndroidNativeWindowFFI()
    {
    }


    public SurfaceDescriptorFromAndroidNativeWindowFFI(SurfaceSourceAndroidNativeWindowFFI value = default)
    {
        this.Value = value;
    }

}
