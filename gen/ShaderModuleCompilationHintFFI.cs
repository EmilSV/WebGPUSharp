using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleCompilationHintFFI
{
    public ChainedStruct* NextInChain;
    public required byte* EntryPoint;
    /// <summary>
    /// A <see cref="FFI.PipelineLayout"/>that the <see cref="FFI.ShaderModule"/>may be used with in a future <see cref="FFI.Device.CreateComputePipeline"/>or <see cref="FFI.Device.CreateRenderPipeline"/>call.
    /// If set toAutoLayoutMode."auto"the layout will be thedefault pipeline layoutfor the entry point associated with this hint will be used.
    /// </summary>
    public PipelineLayoutHandle Layout;

    public ShaderModuleCompilationHintFFI()
    {
    }

}
