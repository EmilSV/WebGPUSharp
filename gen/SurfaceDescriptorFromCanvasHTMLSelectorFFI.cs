using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SurfaceDescriptorFromCanvasHTMLSelectorFFI
{
    public SurfaceSourceCanvasHTMLSelector_EmscriptenFFI Value;

    public SurfaceDescriptorFromCanvasHTMLSelectorFFI()
    {
    }


    public SurfaceDescriptorFromCanvasHTMLSelectorFFI(SurfaceSourceCanvasHTMLSelector_EmscriptenFFI value = default)
    {
        this.Value = value;
    }

}
