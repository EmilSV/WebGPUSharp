using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ShaderModuleCompilationHintFFI
{
    public ChainedStruct* NextInChain;
    public required byte* EntryPoint;
    /// <summary>
    /// A  <see cref="WebGpuSharp.PipelineLayout"/> that the  <see cref="WebGpuSharp.ShaderModule"/> may be used with in a future
    ///  <see cref="WebGpuSharp.Device.CreateComputePipeline"/> or  <see cref="WebGpuSharp.Device.CreateRenderPipeline"/> call.
    /// If set to AutoLayoutMode.Auto the layout will be the default pipeline layout
    /// for the entry point associated with this hint will be used.
    /// </summary>
    public PipelineLayoutHandle Layout;

    public ShaderModuleCompilationHintFFI()
    {
    }

}
