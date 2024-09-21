using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ComputePipelineDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public PipelineLayoutHandle Layout;
    public required ProgrammableStageDescriptorFFI Compute;

    public ComputePipelineDescriptorFFI()
    {
    }

}
