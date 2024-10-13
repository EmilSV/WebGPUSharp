using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ComputePipelineDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label;
    public PipelineLayoutHandle Layout;
    /// <summary>
    /// Describes the compute shader entry point of the pipeline.
    /// </summary>
    public required ProgrammableStageDescriptorFFI Compute;

    public ComputePipelineDescriptorFFI()
    {
    }

}
