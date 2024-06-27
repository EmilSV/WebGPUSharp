using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ComputePipelineDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public PipelineLayoutHandle Layout;
    public ProgrammableStageDescriptorFFI Compute;

    public ComputePipelineDescriptorFFI()
    {
    }


    public ComputePipelineDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, PipelineLayoutHandle layout = default, ProgrammableStageDescriptorFFI compute = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.Layout = layout;
        this.Compute = compute;
    }


    public ComputePipelineDescriptorFFI(byte* label = default, PipelineLayoutHandle layout = default, ProgrammableStageDescriptorFFI compute = default)
    {
        this.Label = label;
        this.Layout = layout;
        this.Compute = compute;
    }

}
