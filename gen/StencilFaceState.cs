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


    public StencilFaceState(CompareFunction compare = default, StencilOperation failOp = default, StencilOperation depthFailOp = default, StencilOperation passOp = default)
    {
        this.Compare = compare;
        this.FailOp = failOp;
        this.DepthFailOp = depthFailOp;
        this.PassOp = passOp;
    }

}
