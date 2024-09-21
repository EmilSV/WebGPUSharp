using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct PrimitiveState
{
    public ChainedStruct* NextInChain;
    public PrimitiveTopology Topology = PrimitiveTopology.TriangleList;
    public IndexFormat StripIndexFormat;
    public FrontFace FrontFace = FrontFace.CCW;
    public CullMode CullMode = CullMode.None;
    public WebGPUBool UnclippedDepth = false;

    public PrimitiveState()
    {
    }

}
