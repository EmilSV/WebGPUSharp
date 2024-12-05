using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceSourceAndroidNativeWindowFFI
{
    public ChainedStruct Chain = new();
    public void* Window;

    public SurfaceSourceAndroidNativeWindowFFI() { }

}
