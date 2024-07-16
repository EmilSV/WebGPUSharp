namespace WebGpuSharp;


public static class LimitsDefaults
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

    public static void SetToDefaultValues(out Limits limits)
    {
        limits = new()
        {
            MaxTextureDimension1D = MAX_TEXTURE_DIMENSION_1D,
            MaxTextureDimension2D = MAX_TEXTURE_DIMENSION_2D,
            MaxTextureDimension3D = MAX_TEXTURE_DIMENSION_3D,
            MaxTextureArrayLayers = MAX_TEXTURE_ARRAY_LAYERS,
            MaxBindGroups = MAX_BIND_GROUPS,
            MaxBindingsPerBindGroup = MAX_BINDINGS_PER_BIND_GROUP,
            MaxDynamicUniformBuffersPerPipelineLayout = MAX_DYNAMIC_UNIFORM_BUFFERS_PER_PIPELINE_LAYOUT,
            MaxDynamicStorageBuffersPerPipelineLayout = MAX_DYNAMIC_STORAGE_BUFFERS_PER_PIPELINE_LAYOUT,
            MaxSampledTexturesPerShaderStage = MAX_SAMPLED_TEXTURES_PER_SHADER_STAGE,
            MaxSamplersPerShaderStage = MAX_SAMPLERS_PER_SHADER_STAGE,
            MaxStorageBuffersPerShaderStage = MAX_STORAGE_BUFFERS_PER_SHADER_STAGE,
            MaxStorageTexturesPerShaderStage = MAX_STORAGE_TEXTURES_PER_SHADER_STAGE,
            MaxUniformBuffersPerShaderStage = MAX_UNIFORM_BUFFERS_PER_SHADER_STAGE,
            MaxUniformBufferBindingSize = MAX_UNIFORM_BUFFER_BINDING_SIZE,
            MaxStorageBufferBindingSize = MAX_STORAGE_BUFFER_BINDING_SIZE,
            MinUniformBufferOffsetAlignment = MIN_UNIFORM_BUFFER_OFFSET_ALIGNMENT,
            MinStorageBufferOffsetAlignment = MIN_STORAGE_BUFFER_OFFSET_ALIGNMENT,
            MaxVertexBuffers = MAX_VERTEX_BUFFERS,
            MaxBufferSize = MAX_BUFFER_SIZE,
            MaxVertexAttributes = MAX_VERTEX_ATTRIBUTES,
            MaxVertexBufferArrayStride = MAX_VERTEX_BUFFER_ARRAY_STRIDE,
            MaxInterStageShaderComponents = MAX_INTER_STAGE_SHADER_COMPONENTS,
            MaxInterStageShaderVariables = MAX_INTER_STAGE_SHADER_VARIABLES,
            MaxColorAttachments = MAX_COLOR_ATTACHMENTS,
            MaxColorAttachmentBytesPerSample = MAX_COLOR_ATTACHMENT_BYTES_PER_SAMPLE,
            MaxComputeWorkgroupStorageSize = MAX_COMPUTE_WORKGROUP_STORAGE_SIZE,
            MaxComputeInvocationsPerWorkgroup = MAX_COMPUTE_INVOCATIONS_PER_WORKGROUP,
            MaxComputeWorkgroupSizeX = MAX_COMPUTE_WORKGROUP_SIZE_X,
            MaxComputeWorkgroupSizeY = MAX_COMPUTE_WORKGROUP_SIZE_Y,
            MaxComputeWorkgroupSizeZ = MAX_COMPUTE_WORKGROUP_SIZE_Z,
            MaxComputeWorkgroupsPerDimension = MAX_COMPUTE_WORKGROUPS_PER_DIMENSION,
            MaxBindGroupsPlusVertexBuffers = MAX_BIND_GROUPS_PLUS_VERTEX_BUFFERS
        };
    }

    public static Limits GetDefaultLimits()
    {
        SetToDefaultValues(out var limits);
        return limits;
    }
}