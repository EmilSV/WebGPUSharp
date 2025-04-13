using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a render (graphics) pipeline.
/// 
/// For use with <see cref="DeviceHandle.CreateRenderPipeline" />.
/// </summary>
public unsafe partial struct RenderPipelineDescriptorFFI
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
    /// A debug label to apply to the pipeline.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// The layout of bind groups for this pipeline.
    /// 
    /// If this is set, then <see cref="DeviceHandle.CreateRenderPipeline" /> will raise a validation error if the layout doesn't match what the shader module(s) expect.
    /// 
    /// Using the same PipelineLayout for many RenderPipeline or ComputePipeline pipelines guarantees that you don't have to rebind any resources when switching between those pipelines.
    /// Default pipeline layout
    /// 
    /// If layout is None, then the pipeline has a default layout created and used instead. The default layout is deduced from the shader modules.
    /// 
    /// You can use <see cref="RenderPipelineHandle.GetBindGroupLayout" /> to create bind groups for use with the default layout. However, these bind groups cannot be used with any other pipelines.
    /// This is convenient for simple pipelines, but using an explicit layout is recommended in most cases.
    /// </summary>
    public PipelineLayoutHandle Layout;
    /// <summary>
    /// Describes the vertex shader entry point of the pipeline and its input buffer layouts.
    /// </summary>
    public required VertexStateFFI Vertex;
    /// <summary>
    /// Describes the primitive-related properties of the pipeline.
    /// </summary>
    public PrimitiveState Primitive = new();
    /// <summary>
    /// Describes the optional depth-stencil properties, including the testing, operations, and bias.
    /// </summary>
    public DepthStencilState* DepthStencil;
    /// <summary>
    /// Describes the multi-sampling properties of the pipeline.
    /// </summary>
    public MultisampleState Multisample = new();
    /// <summary>
    /// Describes the fragment shader entry point of the pipeline and its output colors. If
    /// not provided, the #no-color-output mode is enabled.
    /// </summary>
    public FragmentStateFFI* Fragment;

    public RenderPipelineDescriptorFFI() { }

}
