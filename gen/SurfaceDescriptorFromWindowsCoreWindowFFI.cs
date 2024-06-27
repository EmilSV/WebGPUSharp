using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromWindowsCoreWindowFFI
{
    public ChainedStruct Chain;
    public void* CoreWindow;

    public SurfaceDescriptorFromWindowsCoreWindowFFI()
    {
    }


    public SurfaceDescriptorFromWindowsCoreWindowFFI(ChainedStruct chain = default, void* coreWindow = default)
    {
        this.Chain = chain;
        this.CoreWindow = coreWindow;
    }

}
