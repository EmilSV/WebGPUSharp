using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromAndroidNativeWindowFFI
{
    public ChainedStruct Chain;
    public void* Window;

    public SurfaceDescriptorFromAndroidNativeWindowFFI()
    {
    }


    public SurfaceDescriptorFromAndroidNativeWindowFFI(ChainedStruct chain = default, void* window = default)
    {
        this.Chain = chain;
        this.Window = window;
    }

}
