using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public static unsafe partial class WebGPU_FFI
{

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterPropertiesFreeMembers")]
	public static extern void AdapterPropertiesFreeMembers(AdapterPropertiesFFI value);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCreateInstance")]
	public static extern InstanceHandle CreateInstance(InstanceDescriptor* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuGetInstanceFeatures")]
	public static extern WGPUBool GetInstanceFeatures(InstanceFeatures* features);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryEndAccessStateFreeMembers")]
	public static extern void SharedTextureMemoryEndAccessStateFreeMembers(SharedTextureMemoryEndAccessStateFFI value);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterCreateDevice")]
	public static extern DeviceHandle AdapterCreateDevice(AdapterHandle adapter, DeviceDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterEnumerateFeatures")]
	public static extern nuint AdapterEnumerateFeatures(AdapterHandle adapter, FeatureName* features);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetInstance")]
	public static extern InstanceHandle AdapterGetInstance(AdapterHandle adapter);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetLimits")]
	public static extern WGPUBool AdapterGetLimits(AdapterHandle adapter, SupportedLimits* limits);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetProperties")]
	public static extern void AdapterGetProperties(AdapterHandle adapter, AdapterPropertiesFFI* properties);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterHasFeature")]
	public static extern WGPUBool AdapterHasFeature(AdapterHandle adapter, FeatureName feature);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterRequestDevice")]
	public static extern void AdapterRequestDevice(AdapterHandle adapter, DeviceDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<RequestDeviceStatus, DeviceHandle, byte*, void*, void> callback, void* userdata);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterReference")]
	public static extern void AdapterReference(AdapterHandle adapter);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterRelease")]
	public static extern void AdapterRelease(AdapterHandle adapter);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupSetLabel")]
	public static extern void BindGroupSetLabel(BindGroupHandle bindGroup, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupReference")]
	public static extern void BindGroupReference(BindGroupHandle bindGroup);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupRelease")]
	public static extern void BindGroupRelease(BindGroupHandle bindGroup);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupLayoutSetLabel")]
	public static extern void BindGroupLayoutSetLabel(BindGroupLayoutHandle bindGroupLayout, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupLayoutReference")]
	public static extern void BindGroupLayoutReference(BindGroupLayoutHandle bindGroupLayout);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupLayoutRelease")]
	public static extern void BindGroupLayoutRelease(BindGroupLayoutHandle bindGroupLayout);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferDestroy")]
	public static extern void BufferDestroy(BufferHandle buffer);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetConstMappedRange")]
	public static extern void* BufferGetConstMappedRange(BufferHandle buffer, nuint offset, nuint size);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetMapState")]
	public static extern BufferMapState BufferGetMapState(BufferHandle buffer);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetMappedRange")]
	public static extern void* BufferGetMappedRange(BufferHandle buffer, nuint offset, nuint size);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetSize")]
	public static extern ulong BufferGetSize(BufferHandle buffer);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetUsage")]
	public static extern BufferUsage BufferGetUsage(BufferHandle buffer);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferMapAsync")]
	public static extern void BufferMapAsync(BufferHandle buffer, MapMode mode, nuint offset, nuint size, delegate* unmanaged[Cdecl]<BufferMapAsyncStatus, void*, void> callback, void* userdata);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferSetLabel")]
	public static extern void BufferSetLabel(BufferHandle buffer, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferUnmap")]
	public static extern void BufferUnmap(BufferHandle buffer);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferReference")]
	public static extern void BufferReference(BufferHandle buffer);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferRelease")]
	public static extern void BufferRelease(BufferHandle buffer);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandBufferSetLabel")]
	public static extern void CommandBufferSetLabel(CommandBufferHandle commandBuffer, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandBufferReference")]
	public static extern void CommandBufferReference(CommandBufferHandle commandBuffer);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandBufferRelease")]
	public static extern void CommandBufferRelease(CommandBufferHandle commandBuffer);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderBeginComputePass")]
	public static extern ComputePassEncoderHandle CommandEncoderBeginComputePass(CommandEncoderHandle commandEncoder, ComputePassDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderBeginRenderPass")]
	public static extern RenderPassEncoderHandle CommandEncoderBeginRenderPass(CommandEncoderHandle commandEncoder, RenderPassDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderClearBuffer")]
	public static extern void CommandEncoderClearBuffer(CommandEncoderHandle commandEncoder, BufferHandle buffer, ulong offset, ulong size);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyBufferToBuffer")]
	public static extern void CommandEncoderCopyBufferToBuffer(CommandEncoderHandle commandEncoder, BufferHandle source, ulong sourceOffset, BufferHandle destination, ulong destinationOffset, ulong size);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyBufferToTexture")]
	public static extern void CommandEncoderCopyBufferToTexture(CommandEncoderHandle commandEncoder, ImageCopyBufferFFI* source, ImageCopyTextureFFI* destination, Extent3D* copySize);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyTextureToBuffer")]
	public static extern void CommandEncoderCopyTextureToBuffer(CommandEncoderHandle commandEncoder, ImageCopyTextureFFI* source, ImageCopyBufferFFI* destination, Extent3D* copySize);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyTextureToTexture")]
	public static extern void CommandEncoderCopyTextureToTexture(CommandEncoderHandle commandEncoder, ImageCopyTextureFFI* source, ImageCopyTextureFFI* destination, Extent3D* copySize);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderFinish")]
	public static extern CommandBufferHandle CommandEncoderFinish(CommandEncoderHandle commandEncoder, CommandBufferDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderInjectValidationError")]
	public static extern void CommandEncoderInjectValidationError(CommandEncoderHandle commandEncoder, byte* message);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderInsertDebugMarker")]
	public static extern void CommandEncoderInsertDebugMarker(CommandEncoderHandle commandEncoder, byte* markerLabel);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderPopDebugGroup")]
	public static extern void CommandEncoderPopDebugGroup(CommandEncoderHandle commandEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderPushDebugGroup")]
	public static extern void CommandEncoderPushDebugGroup(CommandEncoderHandle commandEncoder, byte* groupLabel);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderResolveQuerySet")]
	public static extern void CommandEncoderResolveQuerySet(CommandEncoderHandle commandEncoder, QuerySetHandle querySet, uint firstQuery, uint queryCount, BufferHandle destination, ulong destinationOffset);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderSetLabel")]
	public static extern void CommandEncoderSetLabel(CommandEncoderHandle commandEncoder, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderWriteBuffer")]
	public static extern void CommandEncoderWriteBuffer(CommandEncoderHandle commandEncoder, BufferHandle buffer, ulong bufferOffset, byte* data, ulong size);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderWriteTimestamp")]
	public static extern void CommandEncoderWriteTimestamp(CommandEncoderHandle commandEncoder, QuerySetHandle querySet, uint queryIndex);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderReference")]
	public static extern void CommandEncoderReference(CommandEncoderHandle commandEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderRelease")]
	public static extern void CommandEncoderRelease(CommandEncoderHandle commandEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderDispatchWorkgroups")]
	public static extern void ComputePassEncoderDispatchWorkgroups(ComputePassEncoderHandle computePassEncoder, uint workgroupCountX, uint workgroupCountY, uint workgroupCountZ);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderDispatchWorkgroupsIndirect")]
	public static extern void ComputePassEncoderDispatchWorkgroupsIndirect(ComputePassEncoderHandle computePassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderEnd")]
	public static extern void ComputePassEncoderEnd(ComputePassEncoderHandle computePassEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderInsertDebugMarker")]
	public static extern void ComputePassEncoderInsertDebugMarker(ComputePassEncoderHandle computePassEncoder, byte* markerLabel);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderPopDebugGroup")]
	public static extern void ComputePassEncoderPopDebugGroup(ComputePassEncoderHandle computePassEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderPushDebugGroup")]
	public static extern void ComputePassEncoderPushDebugGroup(ComputePassEncoderHandle computePassEncoder, byte* groupLabel);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetBindGroup")]
	public static extern void ComputePassEncoderSetBindGroup(ComputePassEncoderHandle computePassEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetLabel")]
	public static extern void ComputePassEncoderSetLabel(ComputePassEncoderHandle computePassEncoder, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetPipeline")]
	public static extern void ComputePassEncoderSetPipeline(ComputePassEncoderHandle computePassEncoder, ComputePipelineHandle pipeline);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderWriteTimestamp")]
	public static extern void ComputePassEncoderWriteTimestamp(ComputePassEncoderHandle computePassEncoder, QuerySetHandle querySet, uint queryIndex);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderReference")]
	public static extern void ComputePassEncoderReference(ComputePassEncoderHandle computePassEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderRelease")]
	public static extern void ComputePassEncoderRelease(ComputePassEncoderHandle computePassEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineGetBindGroupLayout")]
	public static extern BindGroupLayoutHandle ComputePipelineGetBindGroupLayout(ComputePipelineHandle computePipeline, uint groupIndex);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineSetLabel")]
	public static extern void ComputePipelineSetLabel(ComputePipelineHandle computePipeline, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineReference")]
	public static extern void ComputePipelineReference(ComputePipelineHandle computePipeline);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineRelease")]
	public static extern void ComputePipelineRelease(ComputePipelineHandle computePipeline);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateBindGroup")]
	public static extern BindGroupHandle DeviceCreateBindGroup(DeviceHandle device, BindGroupDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateBindGroupLayout")]
	public static extern BindGroupLayoutHandle DeviceCreateBindGroupLayout(DeviceHandle device, BindGroupLayoutDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateBuffer")]
	public static extern BufferHandle DeviceCreateBuffer(DeviceHandle device, BufferDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateCommandEncoder")]
	public static extern CommandEncoderHandle DeviceCreateCommandEncoder(DeviceHandle device, CommandEncoderDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateComputePipeline")]
	public static extern ComputePipelineHandle DeviceCreateComputePipeline(DeviceHandle device, ComputePipelineDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateComputePipelineAsync")]
	public static extern void DeviceCreateComputePipelineAsync(DeviceHandle device, ComputePipelineDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, ComputePipelineHandle, byte*, void*, void> callback, void* userdata);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateErrorBuffer")]
	public static extern BufferHandle DeviceCreateErrorBuffer(DeviceHandle device, BufferDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateErrorExternalTexture")]
	public static extern ExternalTextureHandle DeviceCreateErrorExternalTexture(DeviceHandle device);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateErrorShaderModule")]
	public static extern ShaderModuleHandle DeviceCreateErrorShaderModule(DeviceHandle device, ShaderModuleDescriptorFFI* descriptor, byte* errorMessage);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateErrorTexture")]
	public static extern TextureHandle DeviceCreateErrorTexture(DeviceHandle device, TextureDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateExternalTexture")]
	public static extern ExternalTextureHandle DeviceCreateExternalTexture(DeviceHandle device, ExternalTextureDescriptorFFI* externalTextureDescriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreatePipelineLayout")]
	public static extern PipelineLayoutHandle DeviceCreatePipelineLayout(DeviceHandle device, PipelineLayoutDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateQuerySet")]
	public static extern QuerySetHandle DeviceCreateQuerySet(DeviceHandle device, QuerySetDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderBundleEncoder")]
	public static extern RenderBundleEncoderHandle DeviceCreateRenderBundleEncoder(DeviceHandle device, RenderBundleEncoderDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderPipeline")]
	public static extern RenderPipelineHandle DeviceCreateRenderPipeline(DeviceHandle device, RenderPipelineDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderPipelineAsync")]
	public static extern void DeviceCreateRenderPipelineAsync(DeviceHandle device, RenderPipelineDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, RenderPipelineHandle, byte*, void*, void> callback, void* userdata);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateSampler")]
	public static extern SamplerHandle DeviceCreateSampler(DeviceHandle device, SamplerDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateShaderModule")]
	public static extern ShaderModuleHandle DeviceCreateShaderModule(DeviceHandle device, ShaderModuleDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateSwapChain")]
	public static extern SwapChainHandle DeviceCreateSwapChain(DeviceHandle device, SurfaceHandle surface, SwapChainDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateTexture")]
	public static extern TextureHandle DeviceCreateTexture(DeviceHandle device, TextureDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceDestroy")]
	public static extern void DeviceDestroy(DeviceHandle device);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceEnumerateFeatures")]
	public static extern nuint DeviceEnumerateFeatures(DeviceHandle device, FeatureName* features);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceForceLoss")]
	public static extern void DeviceForceLoss(DeviceHandle device, DeviceLostReason type, byte* message);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetAdapter")]
	public static extern AdapterHandle DeviceGetAdapter(DeviceHandle device);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetLimits")]
	public static extern WGPUBool DeviceGetLimits(DeviceHandle device, SupportedLimits* limits);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetQueue")]
	public static extern QueueHandle DeviceGetQueue(DeviceHandle device);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetSupportedSurfaceUsage")]
	public static extern TextureUsage DeviceGetSupportedSurfaceUsage(DeviceHandle device, SurfaceHandle surface);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceHasFeature")]
	public static extern WGPUBool DeviceHasFeature(DeviceHandle device, FeatureName feature);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceImportSharedFence")]
	public static extern SharedFenceHandle DeviceImportSharedFence(DeviceHandle device, SharedFenceDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceImportSharedTextureMemory")]
	public static extern SharedTextureMemoryHandle DeviceImportSharedTextureMemory(DeviceHandle device, SharedTextureMemoryDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceInjectError")]
	public static extern void DeviceInjectError(DeviceHandle device, ErrorType type, byte* message);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDevicePopErrorScope")]
	public static extern void DevicePopErrorScope(DeviceHandle device, delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> callback, void* userdata);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDevicePushErrorScope")]
	public static extern void DevicePushErrorScope(DeviceHandle device, ErrorFilter filter);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceSetDeviceLostCallback")]
	public static extern void DeviceSetDeviceLostCallback(DeviceHandle device, delegate* unmanaged[Cdecl]<DeviceLostReason, byte*, void*, void> callback, void* userdata);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceSetLabel")]
	public static extern void DeviceSetLabel(DeviceHandle device, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceSetLoggingCallback")]
	public static extern void DeviceSetLoggingCallback(DeviceHandle device, delegate* unmanaged[Cdecl]<LoggingType, byte*, void*, void> callback, void* userdata);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceSetUncapturedErrorCallback")]
	public static extern void DeviceSetUncapturedErrorCallback(DeviceHandle device, delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> callback, void* userdata);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceTick")]
	public static extern void DeviceTick(DeviceHandle device);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceValidateTextureDescriptor")]
	public static extern void DeviceValidateTextureDescriptor(DeviceHandle device, TextureDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceReference")]
	public static extern void DeviceReference(DeviceHandle device);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceRelease")]
	public static extern void DeviceRelease(DeviceHandle device);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureDestroy")]
	public static extern void ExternalTextureDestroy(ExternalTextureHandle externalTexture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureExpire")]
	public static extern void ExternalTextureExpire(ExternalTextureHandle externalTexture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureRefresh")]
	public static extern void ExternalTextureRefresh(ExternalTextureHandle externalTexture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureSetLabel")]
	public static extern void ExternalTextureSetLabel(ExternalTextureHandle externalTexture, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureReference")]
	public static extern void ExternalTextureReference(ExternalTextureHandle externalTexture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureRelease")]
	public static extern void ExternalTextureRelease(ExternalTextureHandle externalTexture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceCreateSurface")]
	public static extern SurfaceHandle InstanceCreateSurface(InstanceHandle instance, SurfaceDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceProcessEvents")]
	public static extern void InstanceProcessEvents(InstanceHandle instance);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceRequestAdapter")]
	public static extern void InstanceRequestAdapter(InstanceHandle instance, RequestAdapterOptionsFFI* options, delegate* unmanaged[Cdecl]<RequestAdapterStatus, AdapterHandle, byte*, void*, void> callback, void* userdata);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceWaitAny")]
	public static extern WaitStatus InstanceWaitAny(InstanceHandle instance, nuint futureCount, FutureWaitInfo* futures, ulong timeoutNS);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceReference")]
	public static extern void InstanceReference(InstanceHandle instance);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceRelease")]
	public static extern void InstanceRelease(InstanceHandle instance);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuPipelineLayoutSetLabel")]
	public static extern void PipelineLayoutSetLabel(PipelineLayoutHandle pipelineLayout, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuPipelineLayoutReference")]
	public static extern void PipelineLayoutReference(PipelineLayoutHandle pipelineLayout);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuPipelineLayoutRelease")]
	public static extern void PipelineLayoutRelease(PipelineLayoutHandle pipelineLayout);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetDestroy")]
	public static extern void QuerySetDestroy(QuerySetHandle querySet);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetGetCount")]
	public static extern uint QuerySetGetCount(QuerySetHandle querySet);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetGetType")]
	public static extern QueryType QuerySetGetType(QuerySetHandle querySet);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetSetLabel")]
	public static extern void QuerySetSetLabel(QuerySetHandle querySet, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetReference")]
	public static extern void QuerySetReference(QuerySetHandle querySet);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetRelease")]
	public static extern void QuerySetRelease(QuerySetHandle querySet);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueCopyExternalTextureForBrowser")]
	public static extern void QueueCopyExternalTextureForBrowser(QueueHandle queue, ImageCopyExternalTextureFFI* source, ImageCopyTextureFFI* destination, Extent3D* copySize, CopyTextureForBrowserOptionsFFI* options);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueCopyTextureForBrowser")]
	public static extern void QueueCopyTextureForBrowser(QueueHandle queue, ImageCopyTextureFFI* source, ImageCopyTextureFFI* destination, Extent3D* copySize, CopyTextureForBrowserOptionsFFI* options);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueOnSubmittedWorkDone")]
	public static extern void QueueOnSubmittedWorkDone(QueueHandle queue, ulong signalValue, delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void> callback, void* userdata);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueOnSubmittedWorkDoneF")]
	public static extern Future QueueOnSubmittedWorkDoneF(QueueHandle queue, QueueWorkDoneCallbackInfoFFI callbackInfo);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueSetLabel")]
	public static extern void QueueSetLabel(QueueHandle queue, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueSubmit")]
	public static extern void QueueSubmit(QueueHandle queue, nuint commandCount, CommandBufferHandle* commands);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueWriteBuffer")]
	public static extern void QueueWriteBuffer(QueueHandle queue, BufferHandle buffer, ulong bufferOffset, void* data, nuint size);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueWriteTexture")]
	public static extern void QueueWriteTexture(QueueHandle queue, ImageCopyTextureFFI* destination, void* data, nuint dataSize, TextureDataLayout* dataLayout, Extent3D* writeSize);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueReference")]
	public static extern void QueueReference(QueueHandle queue);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueRelease")]
	public static extern void QueueRelease(QueueHandle queue);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleSetLabel")]
	public static extern void RenderBundleSetLabel(RenderBundleHandle renderBundle, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleReference")]
	public static extern void RenderBundleReference(RenderBundleHandle renderBundle);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleRelease")]
	public static extern void RenderBundleRelease(RenderBundleHandle renderBundle);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDraw")]
	public static extern void RenderBundleEncoderDraw(RenderBundleEncoderHandle renderBundleEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDrawIndexed")]
	public static extern void RenderBundleEncoderDrawIndexed(RenderBundleEncoderHandle renderBundleEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDrawIndexedIndirect")]
	public static extern void RenderBundleEncoderDrawIndexedIndirect(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle indirectBuffer, ulong indirectOffset);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDrawIndirect")]
	public static extern void RenderBundleEncoderDrawIndirect(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle indirectBuffer, ulong indirectOffset);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderFinish")]
	public static extern RenderBundleHandle RenderBundleEncoderFinish(RenderBundleEncoderHandle renderBundleEncoder, RenderBundleDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderInsertDebugMarker")]
	public static extern void RenderBundleEncoderInsertDebugMarker(RenderBundleEncoderHandle renderBundleEncoder, byte* markerLabel);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderPopDebugGroup")]
	public static extern void RenderBundleEncoderPopDebugGroup(RenderBundleEncoderHandle renderBundleEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderPushDebugGroup")]
	public static extern void RenderBundleEncoderPushDebugGroup(RenderBundleEncoderHandle renderBundleEncoder, byte* groupLabel);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetBindGroup")]
	public static extern void RenderBundleEncoderSetBindGroup(RenderBundleEncoderHandle renderBundleEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetIndexBuffer")]
	public static extern void RenderBundleEncoderSetIndexBuffer(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle buffer, IndexFormat format, ulong offset, ulong size);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetLabel")]
	public static extern void RenderBundleEncoderSetLabel(RenderBundleEncoderHandle renderBundleEncoder, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetPipeline")]
	public static extern void RenderBundleEncoderSetPipeline(RenderBundleEncoderHandle renderBundleEncoder, RenderPipelineHandle pipeline);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetVertexBuffer")]
	public static extern void RenderBundleEncoderSetVertexBuffer(RenderBundleEncoderHandle renderBundleEncoder, uint slot, BufferHandle buffer, ulong offset, ulong size);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderReference")]
	public static extern void RenderBundleEncoderReference(RenderBundleEncoderHandle renderBundleEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderRelease")]
	public static extern void RenderBundleEncoderRelease(RenderBundleEncoderHandle renderBundleEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderBeginOcclusionQuery")]
	public static extern void RenderPassEncoderBeginOcclusionQuery(RenderPassEncoderHandle renderPassEncoder, uint queryIndex);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDraw")]
	public static extern void RenderPassEncoderDraw(RenderPassEncoderHandle renderPassEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDrawIndexed")]
	public static extern void RenderPassEncoderDrawIndexed(RenderPassEncoderHandle renderPassEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDrawIndexedIndirect")]
	public static extern void RenderPassEncoderDrawIndexedIndirect(RenderPassEncoderHandle renderPassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDrawIndirect")]
	public static extern void RenderPassEncoderDrawIndirect(RenderPassEncoderHandle renderPassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderEnd")]
	public static extern void RenderPassEncoderEnd(RenderPassEncoderHandle renderPassEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderEndOcclusionQuery")]
	public static extern void RenderPassEncoderEndOcclusionQuery(RenderPassEncoderHandle renderPassEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderExecuteBundles")]
	public static extern void RenderPassEncoderExecuteBundles(RenderPassEncoderHandle renderPassEncoder, nuint bundleCount, RenderBundleHandle* bundles);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderInsertDebugMarker")]
	public static extern void RenderPassEncoderInsertDebugMarker(RenderPassEncoderHandle renderPassEncoder, byte* markerLabel);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderPixelLocalStorageBarrier")]
	public static extern void RenderPassEncoderPixelLocalStorageBarrier(RenderPassEncoderHandle renderPassEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderPopDebugGroup")]
	public static extern void RenderPassEncoderPopDebugGroup(RenderPassEncoderHandle renderPassEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderPushDebugGroup")]
	public static extern void RenderPassEncoderPushDebugGroup(RenderPassEncoderHandle renderPassEncoder, byte* groupLabel);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetBindGroup")]
	public static extern void RenderPassEncoderSetBindGroup(RenderPassEncoderHandle renderPassEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetBlendConstant")]
	public static extern void RenderPassEncoderSetBlendConstant(RenderPassEncoderHandle renderPassEncoder, Color* color);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetIndexBuffer")]
	public static extern void RenderPassEncoderSetIndexBuffer(RenderPassEncoderHandle renderPassEncoder, BufferHandle buffer, IndexFormat format, ulong offset, ulong size);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetLabel")]
	public static extern void RenderPassEncoderSetLabel(RenderPassEncoderHandle renderPassEncoder, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetPipeline")]
	public static extern void RenderPassEncoderSetPipeline(RenderPassEncoderHandle renderPassEncoder, RenderPipelineHandle pipeline);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetScissorRect")]
	public static extern void RenderPassEncoderSetScissorRect(RenderPassEncoderHandle renderPassEncoder, uint x, uint y, uint width, uint height);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetStencilReference")]
	public static extern void RenderPassEncoderSetStencilReference(RenderPassEncoderHandle renderPassEncoder, uint reference);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetVertexBuffer")]
	public static extern void RenderPassEncoderSetVertexBuffer(RenderPassEncoderHandle renderPassEncoder, uint slot, BufferHandle buffer, ulong offset, ulong size);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetViewport")]
	public static extern void RenderPassEncoderSetViewport(RenderPassEncoderHandle renderPassEncoder, float x, float y, float width, float height, float minDepth, float maxDepth);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderWriteTimestamp")]
	public static extern void RenderPassEncoderWriteTimestamp(RenderPassEncoderHandle renderPassEncoder, QuerySetHandle querySet, uint queryIndex);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderReference")]
	public static extern void RenderPassEncoderReference(RenderPassEncoderHandle renderPassEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderRelease")]
	public static extern void RenderPassEncoderRelease(RenderPassEncoderHandle renderPassEncoder);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineGetBindGroupLayout")]
	public static extern BindGroupLayoutHandle RenderPipelineGetBindGroupLayout(RenderPipelineHandle renderPipeline, uint groupIndex);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineSetLabel")]
	public static extern void RenderPipelineSetLabel(RenderPipelineHandle renderPipeline, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineReference")]
	public static extern void RenderPipelineReference(RenderPipelineHandle renderPipeline);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineRelease")]
	public static extern void RenderPipelineRelease(RenderPipelineHandle renderPipeline);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSamplerSetLabel")]
	public static extern void SamplerSetLabel(SamplerHandle sampler, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSamplerReference")]
	public static extern void SamplerReference(SamplerHandle sampler);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSamplerRelease")]
	public static extern void SamplerRelease(SamplerHandle sampler);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleGetCompilationInfo")]
	public static extern void ShaderModuleGetCompilationInfo(ShaderModuleHandle shaderModule, delegate* unmanaged[Cdecl]<CompilationInfoRequestStatus, CompilationInfoFFI*, void*, void> callback, void* userdata);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleSetLabel")]
	public static extern void ShaderModuleSetLabel(ShaderModuleHandle shaderModule, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleReference")]
	public static extern void ShaderModuleReference(ShaderModuleHandle shaderModule);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleRelease")]
	public static extern void ShaderModuleRelease(ShaderModuleHandle shaderModule);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedFenceExportInfo")]
	public static extern void SharedFenceExportInfo(SharedFenceHandle sharedFence, SharedFenceExportInfo* info);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedFenceReference")]
	public static extern void SharedFenceReference(SharedFenceHandle sharedFence);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedFenceRelease")]
	public static extern void SharedFenceRelease(SharedFenceHandle sharedFence);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryBeginAccess")]
	public static extern WGPUBool SharedTextureMemoryBeginAccess(SharedTextureMemoryHandle sharedTextureMemory, TextureHandle texture, SharedTextureMemoryBeginAccessDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryCreateTexture")]
	public static extern TextureHandle SharedTextureMemoryCreateTexture(SharedTextureMemoryHandle sharedTextureMemory, TextureDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryEndAccess")]
	public static extern WGPUBool SharedTextureMemoryEndAccess(SharedTextureMemoryHandle sharedTextureMemory, TextureHandle texture, SharedTextureMemoryEndAccessStateFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryGetProperties")]
	public static extern void SharedTextureMemoryGetProperties(SharedTextureMemoryHandle sharedTextureMemory, SharedTextureMemoryProperties* properties);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemorySetLabel")]
	public static extern void SharedTextureMemorySetLabel(SharedTextureMemoryHandle sharedTextureMemory, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryReference")]
	public static extern void SharedTextureMemoryReference(SharedTextureMemoryHandle sharedTextureMemory);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryRelease")]
	public static extern void SharedTextureMemoryRelease(SharedTextureMemoryHandle sharedTextureMemory);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceReference")]
	public static extern void SurfaceReference(SurfaceHandle surface);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceRelease")]
	public static extern void SurfaceRelease(SurfaceHandle surface);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSwapChainGetCurrentTexture")]
	public static extern TextureHandle SwapChainGetCurrentTexture(SwapChainHandle swapChain);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSwapChainGetCurrentTextureView")]
	public static extern TextureViewHandle SwapChainGetCurrentTextureView(SwapChainHandle swapChain);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSwapChainPresent")]
	public static extern void SwapChainPresent(SwapChainHandle swapChain);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSwapChainReference")]
	public static extern void SwapChainReference(SwapChainHandle swapChain);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSwapChainRelease")]
	public static extern void SwapChainRelease(SwapChainHandle swapChain);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureCreateView")]
	public static extern TextureViewHandle TextureCreateView(TextureHandle texture, TextureViewDescriptorFFI* descriptor);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureDestroy")]
	public static extern void TextureDestroy(TextureHandle texture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetDepthOrArrayLayers")]
	public static extern uint TextureGetDepthOrArrayLayers(TextureHandle texture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetDimension")]
	public static extern TextureDimension TextureGetDimension(TextureHandle texture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetFormat")]
	public static extern TextureFormat TextureGetFormat(TextureHandle texture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetHeight")]
	public static extern uint TextureGetHeight(TextureHandle texture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetMipLevelCount")]
	public static extern uint TextureGetMipLevelCount(TextureHandle texture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetSampleCount")]
	public static extern uint TextureGetSampleCount(TextureHandle texture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetUsage")]
	public static extern TextureUsage TextureGetUsage(TextureHandle texture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetWidth")]
	public static extern uint TextureGetWidth(TextureHandle texture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureSetLabel")]
	public static extern void TextureSetLabel(TextureHandle texture, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureReference")]
	public static extern void TextureReference(TextureHandle texture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureRelease")]
	public static extern void TextureRelease(TextureHandle texture);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewSetLabel")]
	public static extern void TextureViewSetLabel(TextureViewHandle textureView, byte* label);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewReference")]
	public static extern void TextureViewReference(TextureViewHandle textureView);

	[DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewRelease")]
	public static extern void TextureViewRelease(TextureViewHandle textureView);
}
