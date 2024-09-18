using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceSourceMetalLayerFFI
{
    public ChainedStruct Chain;
    public void* Layer;

    public SurfaceSourceMetalLayerFFI()
    {
    }


    public SurfaceSourceMetalLayerFFI(ChainedStruct chain = default, void* layer = default)
    {
        this.Chain = chain;
        this.Layer = layer;
    }

}
