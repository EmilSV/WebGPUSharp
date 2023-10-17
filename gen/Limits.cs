using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
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
		this.MaxTextureDimension1D = default;
		this.MaxTextureDimension2D = default;
		this.MaxTextureDimension3D = default;
		this.MaxTextureArrayLayers = default;
		this.MaxBindGroups = default;
		this.MaxBindGroupsPlusVertexBuffers = default;
		this.MaxBindingsPerBindGroup = default;
		this.MaxDynamicUniformBuffersPerPipelineLayout = default;
		this.MaxDynamicStorageBuffersPerPipelineLayout = default;
		this.MaxSampledTexturesPerShaderStage = default;
		this.MaxSamplersPerShaderStage = default;
		this.MaxStorageBuffersPerShaderStage = default;
		this.MaxStorageTexturesPerShaderStage = default;
		this.MaxUniformBuffersPerShaderStage = default;
		this.MaxUniformBufferBindingSize = default;
		this.MaxStorageBufferBindingSize = default;
		this.MinUniformBufferOffsetAlignment = default;
		this.MinStorageBufferOffsetAlignment = default;
		this.MaxVertexBuffers = default;
		this.MaxBufferSize = default;
		this.MaxVertexAttributes = default;
		this.MaxVertexBufferArrayStride = default;
		this.MaxInterStageShaderComponents = default;
		this.MaxInterStageShaderVariables = default;
		this.MaxColorAttachments = default;
		this.MaxColorAttachmentBytesPerSample = default;
		this.MaxComputeWorkgroupStorageSize = default;
		this.MaxComputeInvocationsPerWorkgroup = default;
		this.MaxComputeWorkgroupSizeX = default;
		this.MaxComputeWorkgroupSizeY = default;
		this.MaxComputeWorkgroupSizeZ = default;
		this.MaxComputeWorkgroupsPerDimension = default;
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

