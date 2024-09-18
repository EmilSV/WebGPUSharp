using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromXcbWindowFFI
{
    public SurfaceSourceXCBWindowFFI Value;

    public SurfaceDescriptorFromXcbWindowFFI()
    {
    }


    public SurfaceDescriptorFromXcbWindowFFI(SurfaceSourceXCBWindowFFI value = default)
    {
        this.Value = value;
    }

}
