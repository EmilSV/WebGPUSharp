using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceSourceCanvasHTMLSelector_EmscriptenFFI
{
    public ChainedStruct Chain;
    public byte* Selector;

    public SurfaceSourceCanvasHTMLSelector_EmscriptenFFI()
    {
    }


    public SurfaceSourceCanvasHTMLSelector_EmscriptenFFI(ChainedStruct chain = default, byte* selector = default)
    {
        this.Chain = chain;
        this.Selector = selector;
    }

}
