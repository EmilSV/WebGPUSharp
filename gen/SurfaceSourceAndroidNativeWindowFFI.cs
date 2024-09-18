using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceSourceAndroidNativeWindowFFI
{
    public ChainedStruct Chain;
    public void* Window;

    public SurfaceSourceAndroidNativeWindowFFI()
    {
    }


    public SurfaceSourceAndroidNativeWindowFFI(ChainedStruct chain = default, void* window = default)
    {
        this.Chain = chain;
        this.Window = window;
    }

}
