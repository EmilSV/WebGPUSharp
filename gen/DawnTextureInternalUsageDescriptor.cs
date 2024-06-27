using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnTextureInternalUsageDescriptor
{
    public ChainedStruct Chain;
    public TextureUsage InternalUsage;

    public DawnTextureInternalUsageDescriptor()
    {
    }


    public DawnTextureInternalUsageDescriptor(ChainedStruct chain = default, TextureUsage internalUsage = default)
    {
        this.Chain = chain;
        this.InternalUsage = internalUsage;
    }

}
