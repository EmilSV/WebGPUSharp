using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromXlibWindowFFI
{
    public ChainedStruct Chain;
    public void* Display;
    public ulong Window;

    public SurfaceDescriptorFromXlibWindowFFI()
    {
    }


    public SurfaceDescriptorFromXlibWindowFFI(ChainedStruct chain = default, void* display = default, ulong window = default)
    {
        this.Chain = chain;
        this.Display = display;
        this.Window = window;
    }

}
