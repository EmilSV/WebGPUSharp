using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromXlibWindowFFI
{
    public SurfaceSourceXlibWindowFFI Value;

    public SurfaceDescriptorFromXlibWindowFFI()
    {
    }


    public SurfaceDescriptorFromXlibWindowFFI(SurfaceSourceXlibWindowFFI value = default)
    {
        this.Value = value;
    }

}
