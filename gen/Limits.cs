using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Each limit is a numeric limit on the usage of WebGPU on a device.
/// </summary>
public unsafe partial struct Limits
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
    /// Maximum allowed value for the size.Width of a texture created with <see cref="TextureDimension.D1" />. Defaults to 8192. Higher is “better”.
    /// </summary>
    public uint MaxTextureDimension1D = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum allowed value for the size.Width and size.Height of a texture created with <see cref="TextureDimension.D2" />. Defaults to 8192. Higher is “better”.
    /// </summary>
    public uint MaxTextureDimension2D = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum allowed value for the size.Width, size.Height, and size.DepthOrArrayLayers of a texture created with <see cref="TextureDimension.D3" />. Defaults to 2048. Higher is “better”.
    /// </summary>
    public uint MaxTextureDimension3D = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum allowed value for the size.DepthOrArrayLayers of a texture created with <see cref="TextureDimension.D2" />. Defaults to 256. Higher is “better”.
    /// </summary>
    public uint MaxTextureArrayLayers = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Amount of bind groups that can be attached to a pipeline at the same time. Defaults to 4. Higher is “better”.
    /// </summary>
    public uint MaxBindGroups = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// The maximum number of bind group and vertex buffer slots used simultaneously, counting any empty slots below the highest index. Validated in CreateRenderPipeline() and in draw calls.
    /// </summary>
    public uint MaxBindGroupsPlusVertexBuffers = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum binding index allowed in CreateBindGroupLayout. Defaults to 1000. Higher is “better”.
    /// </summary>
    public uint MaxBindingsPerBindGroup = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Amount of uniform buffer bindings that can be dynamic in a single pipeline. Defaults to 8. Higher is “better”.
    /// </summary>
    public uint MaxDynamicUniformBuffersPerPipelineLayout = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Amount of storage buffer bindings that can be dynamic in a single pipeline. Defaults to 4. Higher is “better”.
    /// </summary>
    public uint MaxDynamicStorageBuffersPerPipelineLayout = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Amount of sampled textures visible in a single shader stage. Defaults to 16. Higher is “better”.
    /// </summary>
    public uint MaxSampledTexturesPerShaderStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Amount of samplers visible in a single shader stage. Defaults to 16. Higher is “better”.
    /// </summary>
    public uint MaxSamplersPerShaderStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Amount of storage buffers visible in a single shader stage. Defaults to 8. Higher is “better”.
    /// </summary>
    public uint MaxStorageBuffersPerShaderStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Amount of storage textures visible in a single shader stage. Defaults to 4. Higher is “better”.
    /// </summary>
    public uint MaxStorageTexturesPerShaderStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Amount of uniform buffers visible in a single shader stage. Defaults to 12. Higher is “better”.
    /// </summary>
    public uint MaxUniformBuffersPerShaderStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum size in bytes of a binding to a uniform buffer. Defaults to 64 KiB. Higher is “better”.
    /// </summary>
    public ulong MaxUniformBufferBindingSize = FFI.WebGPU_FFI.LIMIT_U64_UNDEFINED;
    /// <summary>
    /// Maximum size in bytes of a binding to a storage buffer. Defaults to 128 MiB. Higher is “better”.
    /// </summary>
    public ulong MaxStorageBufferBindingSize = FFI.WebGPU_FFI.LIMIT_U64_UNDEFINED;
    /// <summary>
    /// The required alignment for BufferBinding.Offset and the dynamic offsets provided in SetBindGroup(), for bindings with a BindGroupLayoutEntry entry for which Entry.Buffer.Type is "uniform".
    /// </summary>
    public uint MinUniformBufferOffsetAlignment = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// The required alignment for BufferBinding.Offset and the dynamic offsets provided in SetBindGroup(), for bindings with a BindGroupLayoutEntry entry for which Entry.Buffer.Type is "storage" or "read-only-storage".
    /// </summary>
    public uint MinStorageBufferOffsetAlignment = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum length of VertexState.Buffers when creating a RenderPipeline. Defaults to 8. Higher is “better”.
    /// </summary>
    public uint MaxVertexBuffers = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// A limit above which buffer allocations are guaranteed to fail. Defaults to 256 MiB. Higher is “better”.
    /// 
    /// Buffer allocations below the maximum buffer size may not succeed depending on available memory, fragmentation and other factors.
    /// </summary>
    public ulong MaxBufferSize = FFI.WebGPU_FFI.LIMIT_U64_UNDEFINED;
    /// <summary>
    /// Maximum length of VertexBufferLayout.Attributes, summed over all VertexState.Buffers, when creating a RenderPipeline. Defaults to 16. Higher is “better”.
    /// </summary>
    public uint MaxVertexAttributes = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum value for VertexBufferLayout.ArrayStride when creating a RenderPipeline. Defaults to 2048. Higher is “better”.
    /// </summary>
    public uint MaxVertexBufferArrayStride = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// The maximum allowed number of input or output variables for inter-stage communication (like vertex outputs or fragment inputs). Defaults to 16. Higher is “better”.
    /// </summary>
    public uint MaxInterStageShaderVariables = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// The maximum allowed number of color attachments.
    /// </summary>
    public uint MaxColorAttachments = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// The maximum number of bytes necessary to hold one sample (pixel or subpixel) of render pipeline output data, across all color attachments. Defaults to 32. Higher is “better”.
    /// </summary>
    public uint MaxColorAttachmentBytesPerSample = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum number of bytes used for workgroup memory in a compute entry point. Defaults to 16384. Higher is “better”.
    /// </summary>
    public uint MaxComputeWorkgroupStorageSize = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum value of the product of the workgroup_size dimensions for a compute entry-point. Defaults to 256. Higher is “better”.
    /// </summary>
    public uint MaxComputeInvocationsPerWorkgroup = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// The maximum value of the workgroup_size X dimension for a compute stage ShaderModule entry-point. Defaults to 256. Higher is “better”.
    /// </summary>
    public uint MaxComputeWorkgroupSizeX = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// The maximum value of the workgroup_size Y dimension for a compute stage ShaderModule entry-point. Defaults to 256. Higher is “better”.
    /// </summary>
    public uint MaxComputeWorkgroupSizeY = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// The maximum value of the workgroup_size Z dimension for a compute stage ShaderModule entry-point. Defaults to 64. Higher is “better”.
    /// </summary>
    public uint MaxComputeWorkgroupSizeZ = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// The maximum value for each dimension of a ComputePass.Dispatch(x, y, z) operation. Defaults to 65535. Higher is “better”.
    /// </summary>
    public uint MaxComputeWorkgroupsPerDimension = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    public uint MaxImmediateSize = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum number of storage buffers that can be accessed from the vertex stage.
    /// Defaults to 0 in compatibility mode and matches <see cref="MaxStorageBuffersPerShaderStage" /> in core mode.
    /// </summary>
    public uint MaxStorageBuffersInVertexStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum number of storage textures that can be accessed from the vertex stage.
    /// Defaults to 0 in compatibility mode and matches <see cref="MaxStorageTexturesPerShaderStage" /> in core mode.
    /// </summary>
    public uint MaxStorageTexturesInVertexStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum number of storage buffers that can be accessed from the fragment stage.
    /// Defaults to 4 in compatibility mode and matches <see cref="MaxStorageBuffersPerShaderStage" /> in core mode.
    /// </summary>
    public uint MaxStorageBuffersInFragmentStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;
    /// <summary>
    /// Maximum number of storage textures that can be accessed from the fragment stage.
    /// Defaults to 4 in compatibility mode and matches <see cref="MaxStorageTexturesPerShaderStage" /> in core mode.
    /// </summary>
    public uint MaxStorageTexturesInFragmentStage = FFI.WebGPU_FFI.LIMIT_U32_UNDEFINED;

    public Limits() { }

}
