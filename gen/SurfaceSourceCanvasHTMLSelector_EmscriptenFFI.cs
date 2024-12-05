using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceSourceCanvasHTMLSelector_EmscriptenFFI
{
    public ChainedStruct Chain;
    public StringViewFFI Selector = new();

    public SurfaceSourceCanvasHTMLSelector_EmscriptenFFI() { }

}
