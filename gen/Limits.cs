using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct Limits
{
    public uint MaxTextureDimension1D;
    public uint MaxTextureDimension2D;
    public uint MaxTextureDimension3D;
    public uint MaxTextureArrayLayers;
    public uint MaxBindGroups;
    public uint MaxBindGroupsPlusVertexBuffers;
    public uint MaxBindingsPerBindGroup;
    public uint MaxDynamicUniformBuffersPerPipelineLayout;
    public uint MaxDynamicStorageBuffersPerPipelineLayout;
    public uint MaxSampledTexturesPerShaderStage;
    public uint MaxSamplersPerShaderStage;
    public uint MaxStorageBuffersPerShaderStage;
    public uint MaxStorageTexturesPerShaderStage;
    public uint MaxUniformBuffersPerShaderStage;
    public ulong MaxUniformBufferBindingSize;
    public ulong MaxStorageBufferBindingSize;
    public uint MinUniformBufferOffsetAlignment;
    public uint MinStorageBufferOffsetAlignment;
    public uint MaxVertexBuffers;
    public ulong MaxBufferSize;
    public uint MaxVertexAttributes;
    public uint MaxVertexBufferArrayStride;
    public uint MaxInterStageShaderComponents;
    public uint MaxInterStageShaderVariables;
    public uint MaxColorAttachments;
    public uint MaxColorAttachmentBytesPerSample;
    public uint MaxComputeWorkgroupStorageSize;
    public uint MaxComputeInvocationsPerWorkgroup;
    public uint MaxComputeWorkgroupSizeX;
    public uint MaxComputeWorkgroupSizeY;
    public uint MaxComputeWorkgroupSizeZ;
    public uint MaxComputeWorkgroupsPerDimension;

    public Limits()
    {
    }


    public Limits(uint maxTextureDimension1D = default, uint maxTextureDimension2D = default, uint maxTextureDimension3D = default, uint maxTextureArrayLayers = default, uint maxBindGroups = default, uint maxBindGroupsPlusVertexBuffers = default, uint maxBindingsPerBindGroup = default, uint maxDynamicUniformBuffersPerPipelineLayout = default, uint maxDynamicStorageBuffersPerPipelineLayout = default, uint maxSampledTexturesPerShaderStage = default, uint maxSamplersPerShaderStage = default, uint maxStorageBuffersPerShaderStage = default, uint maxStorageTexturesPerShaderStage = default, uint maxUniformBuffersPerShaderStage = default, ulong maxUniformBufferBindingSize = default, ulong maxStorageBufferBindingSize = default, uint minUniformBufferOffsetAlignment = default, uint minStorageBufferOffsetAlignment = default, uint maxVertexBuffers = default, ulong maxBufferSize = default, uint maxVertexAttributes = default, uint maxVertexBufferArrayStride = default, uint maxInterStageShaderComponents = default, uint maxInterStageShaderVariables = default, uint maxColorAttachments = default, uint maxColorAttachmentBytesPerSample = default, uint maxComputeWorkgroupStorageSize = default, uint maxComputeInvocationsPerWorkgroup = default, uint maxComputeWorkgroupSizeX = default, uint maxComputeWorkgroupSizeY = default, uint maxComputeWorkgroupSizeZ = default, uint maxComputeWorkgroupsPerDimension = default)
    {
        this.MaxTextureDimension1D = maxTextureDimension1D;
        this.MaxTextureDimension2D = maxTextureDimension2D;
        this.MaxTextureDimension3D = maxTextureDimension3D;
        this.MaxTextureArrayLayers = maxTextureArrayLayers;
        this.MaxBindGroups = maxBindGroups;
        this.MaxBindGroupsPlusVertexBuffers = maxBindGroupsPlusVertexBuffers;
        this.MaxBindingsPerBindGroup = maxBindingsPerBindGroup;
        this.MaxDynamicUniformBuffersPerPipelineLayout = maxDynamicUniformBuffersPerPipelineLayout;
        this.MaxDynamicStorageBuffersPerPipelineLayout = maxDynamicStorageBuffersPerPipelineLayout;
        this.MaxSampledTexturesPerShaderStage = maxSampledTexturesPerShaderStage;
        this.MaxSamplersPerShaderStage = maxSamplersPerShaderStage;
        this.MaxStorageBuffersPerShaderStage = maxStorageBuffersPerShaderStage;
        this.MaxStorageTexturesPerShaderStage = maxStorageTexturesPerShaderStage;
        this.MaxUniformBuffersPerShaderStage = maxUniformBuffersPerShaderStage;
        this.MaxUniformBufferBindingSize = maxUniformBufferBindingSize;
        this.MaxStorageBufferBindingSize = maxStorageBufferBindingSize;
        this.MinUniformBufferOffsetAlignment = minUniformBufferOffsetAlignment;
        this.MinStorageBufferOffsetAlignment = minStorageBufferOffsetAlignment;
        this.MaxVertexBuffers = maxVertexBuffers;
        this.MaxBufferSize = maxBufferSize;
        this.MaxVertexAttributes = maxVertexAttributes;
        this.MaxVertexBufferArrayStride = maxVertexBufferArrayStride;
        this.MaxInterStageShaderComponents = maxInterStageShaderComponents;
        this.MaxInterStageShaderVariables = maxInterStageShaderVariables;
        this.MaxColorAttachments = maxColorAttachments;
        this.MaxColorAttachmentBytesPerSample = maxColorAttachmentBytesPerSample;
        this.MaxComputeWorkgroupStorageSize = maxComputeWorkgroupStorageSize;
        this.MaxComputeInvocationsPerWorkgroup = maxComputeInvocationsPerWorkgroup;
        this.MaxComputeWorkgroupSizeX = maxComputeWorkgroupSizeX;
        this.MaxComputeWorkgroupSizeY = maxComputeWorkgroupSizeY;
        this.MaxComputeWorkgroupSizeZ = maxComputeWorkgroupSizeZ;
        this.MaxComputeWorkgroupsPerDimension = maxComputeWorkgroupsPerDimension;
    }

}
