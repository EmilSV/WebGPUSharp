using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromXcbWindowFFI
{
    public ChainedStruct Chain;
    public void* Connection;
    public uint Window;

    public SurfaceDescriptorFromXcbWindowFFI()
    {
    }


    public SurfaceDescriptorFromXcbWindowFFI(ChainedStruct chain = default, void* connection = default, uint window = default)
    {
        this.Chain = chain;
        this.Connection = connection;
        this.Window = window;
    }

}
