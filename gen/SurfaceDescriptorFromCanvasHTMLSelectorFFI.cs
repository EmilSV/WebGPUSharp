using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromCanvasHTMLSelectorFFI
{
    public ChainedStruct Chain;
    public byte* Selector;

    public SurfaceDescriptorFromCanvasHTMLSelectorFFI()
    {
    }


    public SurfaceDescriptorFromCanvasHTMLSelectorFFI(ChainedStruct chain = default, byte* selector = default)
    {
        this.Chain = chain;
        this.Selector = selector;
    }

}
