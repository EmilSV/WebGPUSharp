using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DepthStencilStateDepthWriteDefinedDawn
{
    public ChainedStruct Chain;
    public WebGPUBool DepthWriteDefined;

    public DepthStencilStateDepthWriteDefinedDawn()
    {
    }


    public DepthStencilStateDepthWriteDefinedDawn(ChainedStruct chain = default, WebGPUBool depthWriteDefined = default)
    {
        this.Chain = chain;
        this.DepthWriteDefined = depthWriteDefined;
    }

}
