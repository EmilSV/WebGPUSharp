using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct PipelineLayoutDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public nuint BindGroupLayoutCount;
    public required BindGroupLayoutHandle* BindGroupLayouts;

    public PipelineLayoutDescriptorFFI()
    {
    }

}
