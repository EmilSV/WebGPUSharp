using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromMetalLayerFFI
{
    public ChainedStruct Chain;
    public void* Layer;

    public SurfaceDescriptorFromMetalLayerFFI()
    {
    }


    public SurfaceDescriptorFromMetalLayerFFI(ChainedStruct chain = default, void* layer = default)
    {
        this.Chain = chain;
        this.Layer = layer;
    }

}
