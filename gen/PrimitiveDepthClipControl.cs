using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct PrimitiveDepthClipControl
{
    public ChainedStruct Chain;
    public WebGPUBool UnclippedDepth;

    public PrimitiveDepthClipControl()
    {
    }


    public PrimitiveDepthClipControl(ChainedStruct chain = default, WebGPUBool unclippedDepth = default)
    {
        this.Chain = chain;
        this.UnclippedDepth = unclippedDepth;
    }

}
