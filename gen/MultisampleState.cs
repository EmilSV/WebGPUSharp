using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes the multi-sampling state of a render pipeline.
/// </summary>
public unsafe partial struct MultisampleState
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
    /// Number of samples per pixel. This  <see cref="RenderPipeline"/> will be compatible only
    /// with attachment textures ( <see cref="RenderPassDescriptor.ColorAttachments"/>
    /// and  <see cref="RenderPassDescriptor.DepthStencilAttachment"/>)
    /// with matching  <see cref="TextureDescriptor.SampleCount"/>s.
    /// </summary>
    public uint Count = 1;
    /// <summary>
    /// Mask determining which samples are written to.
    /// </summary>
    public uint Mask = 0xFFFFFFFF;
    /// <summary>
    /// When `true` indicates that a fragment's alpha channel should be used to generate a sample
    /// coverage mask.
    /// </summary>
    public WebGPUBool AlphaToCoverageEnabled = false;

    public MultisampleState() { }

}
