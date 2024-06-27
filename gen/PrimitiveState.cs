using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct PrimitiveState
{
    public ChainedStruct* NextInChain;
    public PrimitiveTopology Topology;
    public IndexFormat StripIndexFormat;
    public FrontFace FrontFace;
    public CullMode CullMode;

    public PrimitiveState()
    {
    }


    public PrimitiveState(ChainedStruct* nextInChain = default, PrimitiveTopology topology = default, IndexFormat stripIndexFormat = default, FrontFace frontFace = default, CullMode cullMode = default)
    {
        this.NextInChain = nextInChain;
        this.Topology = topology;
        this.StripIndexFormat = stripIndexFormat;
        this.FrontFace = frontFace;
        this.CullMode = cullMode;
    }


    public PrimitiveState(PrimitiveTopology topology = default, IndexFormat stripIndexFormat = default, FrontFace frontFace = default, CullMode cullMode = default)
    {
        this.Topology = topology;
        this.StripIndexFormat = stripIndexFormat;
        this.FrontFace = frontFace;
        this.CullMode = cullMode;
    }

}
