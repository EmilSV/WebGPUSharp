using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleCompilationHintFFI
{
    public ChainedStruct* NextInChain;
    public required byte* EntryPoint;
    public PipelineLayoutHandle Layout;

    public ShaderModuleCompilationHintFFI()
    {
    }

}
