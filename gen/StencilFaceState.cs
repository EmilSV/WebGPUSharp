using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct StencilFaceState
{
    public CompareFunction Compare = CompareFunction.Always;
    public StencilOperation FailOp = StencilOperation.Keep;
    public StencilOperation DepthFailOp = StencilOperation.Keep;
    public StencilOperation PassOp = StencilOperation.Keep;

    public StencilFaceState()
    {
    }

}
