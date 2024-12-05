using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnTextureInternalUsageDescriptor
{
    public ChainedStruct Chain = new();
    public TextureUsage InternalUsage;

    public DawnTextureInternalUsageDescriptor() { }

}
