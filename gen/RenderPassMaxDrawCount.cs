using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct RenderPassMaxDrawCount
{
    public ChainedStruct Chain = new();
    public ulong MaxDrawCount;

    public RenderPassMaxDrawCount() { }

}
