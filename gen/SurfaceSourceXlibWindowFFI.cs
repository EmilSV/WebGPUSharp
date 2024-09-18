using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceSourceXlibWindowFFI
{
    public ChainedStruct Chain;
    public void* Display;
    public ulong Window;

    public SurfaceSourceXlibWindowFFI()
    {
    }


    public SurfaceSourceXlibWindowFFI(ChainedStruct chain = default, void* display = default, ulong window = default)
    {
        this.Chain = chain;
        this.Display = display;
        this.Window = window;
    }

}
