using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a compute pipeline. For use with <see cref="DeviceHandle.CreateComputePipeline" />.
/// </summary>
public unsafe partial struct ComputePipelineDescriptorFFI
{
    /// <summary>
    /// Pointer to the first element in a chain of structures that extends this descriptor.
    /// </summary>
    /// <remarks>
    /// Enables struct-chaining, a pattern that extends existing structs with new members while 
    /// maintaining API compatibility. Each extension struct must be properly initialized with 
    /// correct sType values and linked together. For detailed information about struct-chaining,
    /// see: <see href="https://webgpu-native.github.io/webgpu-headers/StructChaining.html"/>
    /// </remarks>
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Debug label of the pipeline.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// The layout of the pipeline.
    /// 
    /// If this is set, then <see cref="DeviceHandle.CreateComputePipeline" />
    /// will raise a validation error if the layout doesn't match what the shader module(s) expect.
    /// 
    /// Using the same <see cref="PipelineLayoutHandle" />
    /// for many <see cref="RenderPipelineHandle" /> or <see cref="ComputePipelineHandle" />
    /// pipelines guarantees that you don't have to rebind any resources for when switching between those pipelines.
    /// 
    /// Default pipeline layout
    /// 
    /// If layout is None, then the pipeline has a default layout created and used instead. The default layout is deduced from the shader modules.
    /// You can use <see cref="ComputePipelineHandle.GetBindGroupLayout" /> to create bind groups for use with the default layout.
    /// However, these bind groups cannot be used with any other pipelines.
    /// This is convenient for simple pipelines, but using an explicit layout is recommended in most cases.
    /// </summary>
    public PipelineLayoutHandle Layout;
    /// <summary>
    /// Describes the compute shader entry point of the pipeline.
    /// </summary>
    public required ComputeStateFFI Compute;

    public ComputePipelineDescriptorFFI() { }

}
