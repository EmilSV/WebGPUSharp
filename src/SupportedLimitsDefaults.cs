namespace WebGpuSharp;


public static class SupportedLimitsDefaults
{
    /// <summary>
    /// The maximum allowed value for the size.width of a texture created with dimension "1d".
    /// </summary>
    public const uint MAX_TEXTURE_DIMENSION_1D = 8192;

    /// <summary>
    /// The maximum allowed value for the size.width and size.height of a texture created with dimension "2d".
    /// </summary>
    public const uint MAX_TEXTURE_DIMENSION_2D = 8192;

    /// <summary>
    /// The maximum allowed value for the size.width, size.height and size.depthOrArrayLayers of a texture created with dimension "3d".
    /// </summary>
    public const uint MAX_TEXTURE_DIMENSION_3D = 2048;

    /// <summary>
    /// The maximum allowed value for the size.depthOrArrayLayers of a texture created with dimension "2d".
    /// </summary>
    public const uint MAX_TEXTURE_ARRAY_LAYERS = 256;

    /// <summary>
    /// The maximum number of GPUBindGroupLayouts allowed in bindGroupLayouts when creating a GPUPipelineLayout. 
    /// </summary>
    public const uint MAX_BIND_GROUPS = 4;

    /// <summary>
    /// The maximum number of bind group and vertex buffer slots used simultaneously, 
    /// counting any empty slots below the highest index. Validated in createRenderPipeline() and in draw calls. 
    /// </summary>
    public const uint MAX_BIND_GROUPS_PLUS_VERTEX_BUFFERS = 24;


    /// <summary>
    /// The number of binding indices available when creating a GPUBindGroupLayout.
    /// </summary>
    public const uint MAX_BINDINGS_PER_BIND_GROUP = 1000;

    /// <summary>
    /// The maximum number of GPUBindGroupLayoutEntry entries across a GPUPipelineLayout
    /// which are uniform buffers with dynamic offsets. 
    /// </summary>
    public const uint MAX_DYNAMIC_UNIFORM_BUFFERS_PER_PIPELINE_LAYOUT = 8;

    /// <summary>
    /// For each possible GPUShaderStage stage, 
    /// the maximum number of GPUBindGroupLayoutEntry entries across a GPUPipelineLayout which are sampled textures. 
    /// </summary>
    public const uint MAX_DYNAMIC_STORAGE_BUFFERS_PER_PIPELINE_LAYOUT = 4;

    /// <summary>
    /// For each possible GPUShaderStage stage, 
    /// the maximum number of GPUBindGroupLayoutEntry entries across a GPUPipelineLayout which are samplers. 
    /// </summary>
    public const uint MAX_SAMPLED_TEXTURES_PER_SHADER_STAGE = 16;

    /// <summary>
    /// For each possible GPUShaderStage stage, 
    /// the maximum number of GPUBindGroupLayoutEntry entries across a GPUPipelineLayout which are storage buffers.    
    /// </summary>
    public const uint MAX_SAMPLERS_PER_SHADER_STAGE = 16;

    /// <summary>
    /// For each possible GPUShaderStage stage, 
    /// the maximum number of GPUBindGroupLayoutEntry entries across a GPUPipelineLayout which are storage textures.     
    /// </summary>
    public const uint MAX_STORAGE_BUFFERS_PER_SHADER_STAGE = 8;

    /// <summary>
    /// For each possible GPUShaderStage stage, 
    /// the maximum number of GPUBindGroupLayoutEntry entries across a GPUPipelineLayout which are storage textures.
    /// </summary>
    public const uint MAX_STORAGE_TEXTURES_PER_SHADER_STAGE = 4;

    /// <summary>
    /// For each possible GPUShaderStage stage, 
    /// the maximum number of GPUBindGroupLayoutEntry entries across a GPUPipelineLayout which are uniform buffers
    /// </summary>
    public const uint MAX_UNIFORM_BUFFERS_PER_SHADER_STAGE = 12;

    /// <summary>
    /// The maximum GPUBufferBinding.size for bindings with a GPUBindGroupLayoutEntry 
    /// entry for which entry.buffer?.type is "uniform". 
    /// </summary>
    public const uint MAX_UNIFORM_BUFFER_BINDING_SIZE = 65536;

    /// <summary>
    /// The maximum GPUBufferBinding.size for bindings with a GPUBindGroupLayoutEntry entry
    /// for which entry.buffer?.type is "storage" or "read-only-storage". 
    /// </summary>
    public const uint MAX_STORAGE_BUFFER_BINDING_SIZE = 134217728;

    /// <summary>
    /// The required alignment for GPUBufferBinding.offset and the dynamic offsets provided in setBindGroup(),
    /// for bindings with a GPUBindGroupLayoutEntry entry for which entry.buffer?.type is "uniform". 
    /// </summary>
    public const uint MIN_UNIFORM_BUFFER_OFFSET_ALIGNMENT = 256;

    /// <summary>
    /// The required alignment for GPUBufferBinding.offset and the dynamic offsets provided in setBindGroup(),
    /// for bindings with a GPUBindGroupLayoutEntry entry for which entry.buffer?.type is "storage" or "read-only-storage". 
    /// </summary>
    public const uint MIN_STORAGE_BUFFER_OFFSET_ALIGNMENT = 256;

    /// <summary>
    /// The maximum number of buffers when creating a GPURenderPipeline.
    /// </summary>
    public const uint MAX_VERTEX_BUFFERS = 8;

    /// <summary>
    /// The maximum size of size when creating a GPUBuffer.
    /// </summary>
    public const uint MAX_BUFFER_SIZE = 268435456;

    /// <summary>
    /// The maximum number of attributes in total across buffers when creating a GPURenderPipeline.
    /// </summary>
    public const uint MAX_VERTEX_ATTRIBUTES = 16;

    /// <summary>
    /// The maximum allowed arrayStride when creating a GPURenderPipeline.
    /// </summary>
    public const uint MAX_VERTEX_BUFFER_ARRAY_STRIDE = 2048;

    /// <summary>
    /// The maximum allowed number of components of input or output variables
    /// for inter-stage communication (like vertex outputs or fragment inputs).
    /// </summary>
    public const uint MAX_INTER_STAGE_SHADER_COMPONENTS = 60;

    /// <summary>
    /// The maximum allowed number of input or output variables for inter-stage
    /// communication (like vertex outputs or fragment inputs).
    /// </summary>
    public const uint MAX_INTER_STAGE_SHADER_VARIABLES = 16;

    /// <summary>
    /// The maximum allowed number of color attachments in GPURenderPipelineDescriptor.fragment.targets,
    /// GPURenderPassDescriptor.colorAttachments, and GPURenderPassLayout.colorFormats. 
    /// </summary>
    public const uint MAX_COLOR_ATTACHMENTS = 8;

    /// <summary>
    /// The maximum number of bytes necessary to hold one sample (pixel or subpixel)
    /// of render pipeline output data, across all color attachments.
    /// </summary>
    public const uint MAX_COLOR_ATTACHMENT_BYTES_PER_SAMPLE = 32;

    /// <summary>
    /// The maximum number of bytes of workgroup storage used for a compute stage GPUShaderModule entry-point.
    /// </summary>
    public const uint MAX_COMPUTE_WORKGROUP_STORAGE_SIZE = 16384;

    /// <summary>
    /// The maximum value of the product of the workgroup_size dimensions for a compute stage GPUShaderModule entry-point.
    /// </summary>
    public const uint MAX_COMPUTE_INVOCATIONS_PER_WORKGROUP = 256;

    /// <summary>
    /// The maximum value of the workgroup_size X dimension for a compute stage GPUShaderModule entry-point.
    /// </summary>
    public const uint MAX_COMPUTE_WORKGROUP_SIZE_X = 256;

    /// <summary>
    /// The maximum value of the workgroup_size Y dimensions for a compute stage GPUShaderModule entry-point.
    /// </summary>
    public const uint MAX_COMPUTE_WORKGROUP_SIZE_Y = 256;

    /// <summary>
    /// The maximum value of the workgroup_size Z dimensions for a compute stage GPUShaderModule entry-point.
    /// </summary>
    public const uint MAX_COMPUTE_WORKGROUP_SIZE_Z = 64;

    /// <summary>
    /// The maximum value for the arguments of dispatchWorkgroups(workgroupCountX, workgroupCountY, workgroupCountZ).
    /// </summary>
    public const uint MAX_COMPUTE_WORKGROUPS_PER_DIMENSION = 65535;
    
    public static void SetToDefaultValues(ref SupportedLimits supportedLimits)
    {
        ref var limits = ref supportedLimits.Limits;

        limits.MaxTextureDimension1D = MAX_TEXTURE_DIMENSION_1D;
        limits.MaxTextureDimension2D = MAX_TEXTURE_DIMENSION_2D;
        limits.MaxTextureDimension3D = MAX_TEXTURE_DIMENSION_3D;
        limits.MaxTextureArrayLayers = MAX_TEXTURE_ARRAY_LAYERS;
        limits.MaxBindGroups = MAX_BIND_GROUPS;
        limits.MaxBindingsPerBindGroup = MAX_BINDINGS_PER_BIND_GROUP;
        limits.MaxDynamicUniformBuffersPerPipelineLayout = MAX_DYNAMIC_UNIFORM_BUFFERS_PER_PIPELINE_LAYOUT;
        limits.MaxDynamicStorageBuffersPerPipelineLayout = MAX_DYNAMIC_STORAGE_BUFFERS_PER_PIPELINE_LAYOUT;
        limits.MaxSampledTexturesPerShaderStage = MAX_SAMPLED_TEXTURES_PER_SHADER_STAGE;
        limits.MaxSamplersPerShaderStage = MAX_SAMPLERS_PER_SHADER_STAGE;
        limits.MaxStorageBuffersPerShaderStage = MAX_STORAGE_BUFFERS_PER_SHADER_STAGE;
        limits.MaxStorageTexturesPerShaderStage = MAX_STORAGE_TEXTURES_PER_SHADER_STAGE;
        limits.MaxUniformBuffersPerShaderStage = MAX_UNIFORM_BUFFERS_PER_SHADER_STAGE;
        limits.MaxUniformBufferBindingSize = MAX_UNIFORM_BUFFER_BINDING_SIZE;
        limits.MaxStorageBufferBindingSize = MAX_STORAGE_BUFFER_BINDING_SIZE;
        limits.MinUniformBufferOffsetAlignment = MIN_UNIFORM_BUFFER_OFFSET_ALIGNMENT;
        limits.MinStorageBufferOffsetAlignment = MIN_STORAGE_BUFFER_OFFSET_ALIGNMENT;
        limits.MaxVertexBuffers = MAX_VERTEX_BUFFERS;
        limits.MaxBufferSize = MAX_BUFFER_SIZE;
        limits.MaxVertexAttributes = MAX_VERTEX_ATTRIBUTES;
        limits.MaxVertexBufferArrayStride = MAX_VERTEX_BUFFER_ARRAY_STRIDE;
        limits.MaxInterStageShaderComponents = MAX_INTER_STAGE_SHADER_COMPONENTS;
        limits.MaxInterStageShaderVariables = MAX_INTER_STAGE_SHADER_VARIABLES;
        limits.MaxColorAttachments = MAX_COLOR_ATTACHMENTS;
        limits.MaxColorAttachmentBytesPerSample = MAX_COLOR_ATTACHMENT_BYTES_PER_SAMPLE;
        limits.MaxComputeWorkgroupStorageSize = MAX_COMPUTE_WORKGROUP_STORAGE_SIZE;
        limits.MaxComputeInvocationsPerWorkgroup = MAX_COMPUTE_INVOCATIONS_PER_WORKGROUP;
        limits.MaxComputeWorkgroupSizeX = MAX_COMPUTE_WORKGROUP_SIZE_X;
        limits.MaxComputeWorkgroupSizeY = MAX_COMPUTE_WORKGROUP_SIZE_Y;
        limits.MaxComputeWorkgroupSizeZ = MAX_COMPUTE_WORKGROUP_SIZE_Z;
        limits.MaxComputeWorkgroupsPerDimension = MAX_COMPUTE_WORKGROUPS_PER_DIMENSION;
    }
}