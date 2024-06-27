using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct ColorTargetStateExpandResolveTextureDawn
{
    public ChainedStruct Chain;
    public WebGPUBool Enabled;

    public ColorTargetStateExpandResolveTextureDawn()
    {
    }


    public ColorTargetStateExpandResolveTextureDawn(ChainedStruct chain = default, WebGPUBool enabled = default)
    {
        this.Chain = chain;
        this.Enabled = enabled;
    }

}
