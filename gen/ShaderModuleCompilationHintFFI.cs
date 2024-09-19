using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleCompilationHintFFI
{
    public ChainedStruct* NextInChain;
    public byte* EntryPoint;
    public PipelineLayoutHandle Layout;

    public ShaderModuleCompilationHintFFI()
    {
    }


    public ShaderModuleCompilationHintFFI(ChainedStruct* nextInChain = default, byte* entryPoint = default, PipelineLayoutHandle layout = default)
    {
        this.NextInChain = nextInChain;
        this.EntryPoint = entryPoint;
        this.Layout = layout;
    }


    public ShaderModuleCompilationHintFFI(byte* entryPoint = default, PipelineLayoutHandle layout = default)
    {
        this.EntryPoint = entryPoint;
        this.Layout = layout;
    }

}
