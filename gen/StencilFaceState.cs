using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct StencilFaceState
{
    public CompareFunction Compare;
    public StencilOperation FailOp;
    public StencilOperation DepthFailOp;
    public StencilOperation PassOp;

    public StencilFaceState()
    {
    }


    public StencilFaceState(CompareFunction compare = CompareFunction.Always, StencilOperation failOp = StencilOperation.Keep, StencilOperation depthFailOp = StencilOperation.Keep, StencilOperation passOp = StencilOperation.Keep)
    {
        this.Compare = compare;
        this.FailOp = failOp;
        this.DepthFailOp = depthFailOp;
        this.PassOp = passOp;
    }

}
