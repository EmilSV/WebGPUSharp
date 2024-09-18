using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromMetalLayerFFI
{
    public SurfaceSourceMetalLayerFFI Value;

    public SurfaceDescriptorFromMetalLayerFFI()
    {
    }


    public SurfaceDescriptorFromMetalLayerFFI(SurfaceSourceMetalLayerFFI value = default)
    {
        this.Value = value;
    }

}
