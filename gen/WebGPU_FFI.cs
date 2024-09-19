using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe static partial class WebGPU_FFI
{
    public const uint ARRAY_LAYER_COUNT_UNDEFINED = uint.MaxValue;
    public const uint COPY_STRIDE_UNDEFINED = uint.MaxValue;
    public const uint DEPTH_SLICE_UNDEFINED = uint.MaxValue;
    public const uint LIMIT_U32_UNDEFINED = uint.MaxValue;
    public const ulong LIMIT_U64_UNDEFINED = ulong.MaxValue;
    public const uint MIP_LEVEL_COUNT_UNDEFINED = uint.MaxValue;
    public const uint QUERY_SET_INDEX_UNDEFINED = uint.MaxValue;
    public static readonly nuint WHOLE_MAP_SIZE = nuint.MaxValue;
    public const ulong WHOLE_SIZE = ulong.MaxValue;

    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterInfoFreeMembers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterInfoFreeMembers(FFI.AdapterInfoFFI value);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterPropertiesFreeMembers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterPropertiesFreeMembers(FFI.AdapterPropertiesFFI value);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCreateInstance", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.InstanceHandle CreateInstance(InstanceDescriptor* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuGetInstanceFeatures", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status GetInstanceFeatures(InstanceFeatures* features);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceCapabilitiesFreeMembers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceCapabilitiesFreeMembers(FFI.SurfaceCapabilitiesFFI value);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterEnumerateFeatures", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint AdapterEnumerateFeatures(FFI.AdapterHandle adapter, FeatureName* features);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterGetInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status AdapterGetInfo(FFI.AdapterHandle adapter, FFI.AdapterInfoFFI* info);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterGetLimits", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status AdapterGetLimits(FFI.AdapterHandle adapter, SupportedLimits* limits);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterGetProperties", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status AdapterGetProperties(FFI.AdapterHandle adapter, FFI.AdapterPropertiesFFI* properties);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterHasFeature", CallingConvention = CallingConvention.Cdecl)]
    public static extern WebGPUBool AdapterHasFeature(FFI.AdapterHandle adapter, FeatureName feature);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterRequestDevice", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterRequestDevice(FFI.AdapterHandle adapter, FFI.DeviceDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<RequestDeviceStatus, FFI.DeviceHandle, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterAddRef(FFI.AdapterHandle adapter);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterRelease(FFI.AdapterHandle adapter);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupSetLabel(FFI.BindGroupHandle bindGroup, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupSetLabel2(FFI.BindGroupHandle bindGroup, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupAddRef(FFI.BindGroupHandle bindGroup);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupRelease(FFI.BindGroupHandle bindGroup);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupLayoutSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupLayoutSetLabel(FFI.BindGroupLayoutHandle bindGroupLayout, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupLayoutSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupLayoutSetLabel2(FFI.BindGroupLayoutHandle bindGroupLayout, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupLayoutAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupLayoutAddRef(FFI.BindGroupLayoutHandle bindGroupLayout);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupLayoutRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupLayoutRelease(FFI.BindGroupLayoutHandle bindGroupLayout);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferDestroy(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetConstMappedRange", CallingConvention = CallingConvention.Cdecl)]
    public static extern void* BufferGetConstMappedRange(FFI.BufferHandle buffer, nuint offset, nuint size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetMapState", CallingConvention = CallingConvention.Cdecl)]
    public static extern BufferMapState BufferGetMapState(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetMappedRange", CallingConvention = CallingConvention.Cdecl)]
    public static extern void* BufferGetMappedRange(FFI.BufferHandle buffer, nuint offset, nuint size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetSize", CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong BufferGetSize(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetUsage", CallingConvention = CallingConvention.Cdecl)]
    public static extern BufferUsage BufferGetUsage(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferMapAsync", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferMapAsync(FFI.BufferHandle buffer, MapMode mode, nuint offset, nuint size, delegate* unmanaged[Cdecl]<BufferMapAsyncStatus, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferSetLabel(FFI.BufferHandle buffer, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferSetLabel2(FFI.BufferHandle buffer, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferUnmap", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferUnmap(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferAddRef(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferRelease(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandBufferSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandBufferSetLabel(FFI.CommandBufferHandle commandBuffer, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandBufferSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandBufferSetLabel2(FFI.CommandBufferHandle commandBuffer, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandBufferAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandBufferAddRef(FFI.CommandBufferHandle commandBuffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandBufferRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandBufferRelease(FFI.CommandBufferHandle commandBuffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderBeginComputePass", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.ComputePassEncoderHandle CommandEncoderBeginComputePass(FFI.CommandEncoderHandle commandEncoder, FFI.ComputePassDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderBeginRenderPass", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.RenderPassEncoderHandle CommandEncoderBeginRenderPass(FFI.CommandEncoderHandle commandEncoder, FFI.RenderPassDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderClearBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderClearBuffer(FFI.CommandEncoderHandle commandEncoder, FFI.BufferHandle buffer, ulong offset, ulong size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyBufferToBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderCopyBufferToBuffer(FFI.CommandEncoderHandle commandEncoder, FFI.BufferHandle source, ulong sourceOffset, FFI.BufferHandle destination, ulong destinationOffset, ulong size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyBufferToTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderCopyBufferToTexture(FFI.CommandEncoderHandle commandEncoder, FFI.ImageCopyBufferFFI* source, FFI.ImageCopyTextureFFI* destination, Extent3D* copySize);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyTextureToBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderCopyTextureToBuffer(FFI.CommandEncoderHandle commandEncoder, FFI.ImageCopyTextureFFI* source, FFI.ImageCopyBufferFFI* destination, Extent3D* copySize);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyTextureToTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderCopyTextureToTexture(FFI.CommandEncoderHandle commandEncoder, FFI.ImageCopyTextureFFI* source, FFI.ImageCopyTextureFFI* destination, Extent3D* copySize);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderFinish", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.CommandBufferHandle CommandEncoderFinish(FFI.CommandEncoderHandle commandEncoder, FFI.CommandBufferDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderInsertDebugMarker(FFI.CommandEncoderHandle commandEncoder, byte* markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderInsertDebugMarker2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderInsertDebugMarker2(FFI.CommandEncoderHandle commandEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderPopDebugGroup(FFI.CommandEncoderHandle commandEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderPushDebugGroup(FFI.CommandEncoderHandle commandEncoder, byte* groupLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderPushDebugGroup2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderPushDebugGroup2(FFI.CommandEncoderHandle commandEncoder, FFI.StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderResolveQuerySet", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderResolveQuerySet(FFI.CommandEncoderHandle commandEncoder, FFI.QuerySetHandle querySet, uint firstQuery, uint queryCount, FFI.BufferHandle destination, ulong destinationOffset);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderSetLabel(FFI.CommandEncoderHandle commandEncoder, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderSetLabel2(FFI.CommandEncoderHandle commandEncoder, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderWriteTimestamp", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderWriteTimestamp(FFI.CommandEncoderHandle commandEncoder, FFI.QuerySetHandle querySet, uint queryIndex);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderAddRef(FFI.CommandEncoderHandle commandEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderRelease(FFI.CommandEncoderHandle commandEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderDispatchWorkgroups", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderDispatchWorkgroups(FFI.ComputePassEncoderHandle computePassEncoder, uint workgroupCountX, uint workgroupCountY, uint workgroupCountZ);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderDispatchWorkgroupsIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderDispatchWorkgroupsIndirect(FFI.ComputePassEncoderHandle computePassEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderEnd", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderEnd(FFI.ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderInsertDebugMarker(FFI.ComputePassEncoderHandle computePassEncoder, byte* markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderInsertDebugMarker2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderInsertDebugMarker2(FFI.ComputePassEncoderHandle computePassEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderPopDebugGroup(FFI.ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderPushDebugGroup(FFI.ComputePassEncoderHandle computePassEncoder, byte* groupLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderPushDebugGroup2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderPushDebugGroup2(FFI.ComputePassEncoderHandle computePassEncoder, FFI.StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderSetBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderSetBindGroup(FFI.ComputePassEncoderHandle computePassEncoder, uint groupIndex, FFI.BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderSetLabel(FFI.ComputePassEncoderHandle computePassEncoder, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderSetLabel2(FFI.ComputePassEncoderHandle computePassEncoder, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderSetPipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderSetPipeline(FFI.ComputePassEncoderHandle computePassEncoder, FFI.ComputePipelineHandle pipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderAddRef(FFI.ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderRelease(FFI.ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineGetBindGroupLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.BindGroupLayoutHandle ComputePipelineGetBindGroupLayout(FFI.ComputePipelineHandle computePipeline, uint groupIndex);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePipelineSetLabel(FFI.ComputePipelineHandle computePipeline, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePipelineSetLabel2(FFI.ComputePipelineHandle computePipeline, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePipelineAddRef(FFI.ComputePipelineHandle computePipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePipelineRelease(FFI.ComputePipelineHandle computePipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.BindGroupHandle DeviceCreateBindGroup(FFI.DeviceHandle device, FFI.BindGroupDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateBindGroupLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.BindGroupLayoutHandle DeviceCreateBindGroupLayout(FFI.DeviceHandle device, FFI.BindGroupLayoutDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.BufferHandle DeviceCreateBuffer(FFI.DeviceHandle device, FFI.BufferDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateCommandEncoder", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.CommandEncoderHandle DeviceCreateCommandEncoder(FFI.DeviceHandle device, FFI.CommandEncoderDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateComputePipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.ComputePipelineHandle DeviceCreateComputePipeline(FFI.DeviceHandle device, FFI.ComputePipelineDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateComputePipelineAsync", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceCreateComputePipelineAsync(FFI.DeviceHandle device, FFI.ComputePipelineDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, FFI.ComputePipelineHandle, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreatePipelineLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.PipelineLayoutHandle DeviceCreatePipelineLayout(FFI.DeviceHandle device, FFI.PipelineLayoutDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateQuerySet", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.QuerySetHandle DeviceCreateQuerySet(FFI.DeviceHandle device, FFI.QuerySetDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateRenderBundleEncoder", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.RenderBundleEncoderHandle DeviceCreateRenderBundleEncoder(FFI.DeviceHandle device, FFI.RenderBundleEncoderDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateRenderPipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.RenderPipelineHandle DeviceCreateRenderPipeline(FFI.DeviceHandle device, FFI.RenderPipelineDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateRenderPipelineAsync", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceCreateRenderPipelineAsync(FFI.DeviceHandle device, FFI.RenderPipelineDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, FFI.RenderPipelineHandle, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateSampler", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.SamplerHandle DeviceCreateSampler(FFI.DeviceHandle device, FFI.SamplerDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateShaderModule", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.ShaderModuleHandle DeviceCreateShaderModule(FFI.DeviceHandle device, FFI.ShaderModuleDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.TextureHandle DeviceCreateTexture(FFI.DeviceHandle device, FFI.TextureDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceDestroy(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceEnumerateFeatures", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint DeviceEnumerateFeatures(FFI.DeviceHandle device, FeatureName* features);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetLimits", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status DeviceGetLimits(FFI.DeviceHandle device, SupportedLimits* limits);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetQueue", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.QueueHandle DeviceGetQueue(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceHasFeature", CallingConvention = CallingConvention.Cdecl)]
    public static extern WebGPUBool DeviceHasFeature(FFI.DeviceHandle device, FeatureName feature);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDevicePopErrorScope", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DevicePopErrorScope(FFI.DeviceHandle device, delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> oldCallback, void* userdata);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDevicePushErrorScope", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DevicePushErrorScope(FFI.DeviceHandle device, ErrorFilter filter);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceSetLabel(FFI.DeviceHandle device, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceSetLabel2(FFI.DeviceHandle device, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceSetUncapturedErrorCallback", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceSetUncapturedErrorCallback(FFI.DeviceHandle device, delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceAddRef(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceRelease(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceCreateSurface", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.SurfaceHandle InstanceCreateSurface(FFI.InstanceHandle instance, FFI.SurfaceDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceEnumerateWGSLLanguageFeatures", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint InstanceEnumerateWGSLLanguageFeatures(FFI.InstanceHandle instance, WGSLFeatureName* features);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceHasWGSLLanguageFeature", CallingConvention = CallingConvention.Cdecl)]
    public static extern WebGPUBool InstanceHasWGSLLanguageFeature(FFI.InstanceHandle instance, WGSLFeatureName feature);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceProcessEvents", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InstanceProcessEvents(FFI.InstanceHandle instance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceRequestAdapter", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InstanceRequestAdapter(FFI.InstanceHandle instance, FFI.RequestAdapterOptionsFFI* options, delegate* unmanaged[Cdecl]<RequestAdapterStatus, FFI.AdapterHandle, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceWaitAny", CallingConvention = CallingConvention.Cdecl)]
    public static extern WaitStatus InstanceWaitAny(FFI.InstanceHandle instance, nuint futureCount, FutureWaitInfo* futures, ulong timeoutNS);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InstanceAddRef(FFI.InstanceHandle instance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InstanceRelease(FFI.InstanceHandle instance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuPipelineLayoutSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void PipelineLayoutSetLabel(FFI.PipelineLayoutHandle pipelineLayout, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuPipelineLayoutSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void PipelineLayoutSetLabel2(FFI.PipelineLayoutHandle pipelineLayout, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuPipelineLayoutAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void PipelineLayoutAddRef(FFI.PipelineLayoutHandle pipelineLayout);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuPipelineLayoutRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void PipelineLayoutRelease(FFI.PipelineLayoutHandle pipelineLayout);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuerySetDestroy(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetGetCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint QuerySetGetCount(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetGetType", CallingConvention = CallingConvention.Cdecl)]
    public static extern QueryType QuerySetGetType(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuerySetSetLabel(FFI.QuerySetHandle querySet, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuerySetSetLabel2(FFI.QuerySetHandle querySet, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuerySetAddRef(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuerySetRelease(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueSetLabel(FFI.QueueHandle queue, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueSetLabel2(FFI.QueueHandle queue, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueSubmit", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueSubmit(FFI.QueueHandle queue, nuint commandCount, FFI.CommandBufferHandle* commands);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueWriteBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueWriteBuffer(FFI.QueueHandle queue, FFI.BufferHandle buffer, ulong bufferOffset, void* data, nuint size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueWriteTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueWriteTexture(FFI.QueueHandle queue, FFI.ImageCopyTextureFFI* destination, void* data, nuint dataSize, TextureDataLayout* dataLayout, Extent3D* writeSize);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueAddRef(FFI.QueueHandle queue);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueRelease(FFI.QueueHandle queue);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleSetLabel(FFI.RenderBundleHandle renderBundle, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleSetLabel2(FFI.RenderBundleHandle renderBundle, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleAddRef(FFI.RenderBundleHandle renderBundle);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleRelease(FFI.RenderBundleHandle renderBundle);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDraw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDraw(FFI.RenderBundleEncoderHandle renderBundleEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDrawIndexed", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDrawIndexed(FFI.RenderBundleEncoderHandle renderBundleEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDrawIndexedIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDrawIndexedIndirect(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDrawIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDrawIndirect(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderFinish", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.RenderBundleHandle RenderBundleEncoderFinish(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.RenderBundleDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderInsertDebugMarker(FFI.RenderBundleEncoderHandle renderBundleEncoder, byte* markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderInsertDebugMarker2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderInsertDebugMarker2(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderPopDebugGroup(FFI.RenderBundleEncoderHandle renderBundleEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderPushDebugGroup(FFI.RenderBundleEncoderHandle renderBundleEncoder, byte* groupLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderPushDebugGroup2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderPushDebugGroup2(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetBindGroup(FFI.RenderBundleEncoderHandle renderBundleEncoder, uint groupIndex, FFI.BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetIndexBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetIndexBuffer(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.BufferHandle buffer, IndexFormat format, ulong offset, ulong size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetLabel(FFI.RenderBundleEncoderHandle renderBundleEncoder, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetLabel2(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetPipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetPipeline(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.RenderPipelineHandle pipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetVertexBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetVertexBuffer(FFI.RenderBundleEncoderHandle renderBundleEncoder, uint slot, FFI.BufferHandle buffer, ulong offset, ulong size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderAddRef(FFI.RenderBundleEncoderHandle renderBundleEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderRelease(FFI.RenderBundleEncoderHandle renderBundleEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderBeginOcclusionQuery", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderBeginOcclusionQuery(FFI.RenderPassEncoderHandle renderPassEncoder, uint queryIndex);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDraw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDraw(FFI.RenderPassEncoderHandle renderPassEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDrawIndexed", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDrawIndexed(FFI.RenderPassEncoderHandle renderPassEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDrawIndexedIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDrawIndexedIndirect(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDrawIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDrawIndirect(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderEnd", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderEnd(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderEndOcclusionQuery", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderEndOcclusionQuery(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderExecuteBundles", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderExecuteBundles(FFI.RenderPassEncoderHandle renderPassEncoder, nuint bundleCount, FFI.RenderBundleHandle* bundles);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderInsertDebugMarker(FFI.RenderPassEncoderHandle renderPassEncoder, byte* markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderInsertDebugMarker2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderInsertDebugMarker2(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderMultiDrawIndexedIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderMultiDrawIndexedIndirect(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset, uint maxDrawCount, FFI.BufferHandle drawCountBuffer, ulong drawCountBufferOffset);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderMultiDrawIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderMultiDrawIndirect(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset, uint maxDrawCount, FFI.BufferHandle drawCountBuffer, ulong drawCountBufferOffset);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderPopDebugGroup(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderPushDebugGroup(FFI.RenderPassEncoderHandle renderPassEncoder, byte* groupLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderPushDebugGroup2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderPushDebugGroup2(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetBindGroup(FFI.RenderPassEncoderHandle renderPassEncoder, uint groupIndex, FFI.BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetBlendConstant", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetBlendConstant(FFI.RenderPassEncoderHandle renderPassEncoder, Color* color);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetIndexBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetIndexBuffer(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.BufferHandle buffer, IndexFormat format, ulong offset, ulong size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetLabel(FFI.RenderPassEncoderHandle renderPassEncoder, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetLabel2(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetPipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetPipeline(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.RenderPipelineHandle pipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetScissorRect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetScissorRect(FFI.RenderPassEncoderHandle renderPassEncoder, uint x, uint y, uint width, uint height);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetStencilReference", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetStencilReference(FFI.RenderPassEncoderHandle renderPassEncoder, uint reference);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetVertexBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetVertexBuffer(FFI.RenderPassEncoderHandle renderPassEncoder, uint slot, FFI.BufferHandle buffer, ulong offset, ulong size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetViewport", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetViewport(FFI.RenderPassEncoderHandle renderPassEncoder, float x, float y, float width, float height, float minDepth, float maxDepth);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderAddRef(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderRelease(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineGetBindGroupLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.BindGroupLayoutHandle RenderPipelineGetBindGroupLayout(FFI.RenderPipelineHandle renderPipeline, uint groupIndex);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPipelineSetLabel(FFI.RenderPipelineHandle renderPipeline, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPipelineSetLabel2(FFI.RenderPipelineHandle renderPipeline, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPipelineAddRef(FFI.RenderPipelineHandle renderPipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPipelineRelease(FFI.RenderPipelineHandle renderPipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSamplerSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SamplerSetLabel(FFI.SamplerHandle sampler, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSamplerSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SamplerSetLabel2(FFI.SamplerHandle sampler, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSamplerAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SamplerAddRef(FFI.SamplerHandle sampler);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSamplerRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SamplerRelease(FFI.SamplerHandle sampler);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleGetCompilationInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ShaderModuleGetCompilationInfo(FFI.ShaderModuleHandle shaderModule, delegate* unmanaged[Cdecl]<CompilationInfoRequestStatus, FFI.CompilationInfoFFI*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ShaderModuleSetLabel(FFI.ShaderModuleHandle shaderModule, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ShaderModuleSetLabel2(FFI.ShaderModuleHandle shaderModule, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ShaderModuleAddRef(FFI.ShaderModuleHandle shaderModule);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ShaderModuleRelease(FFI.ShaderModuleHandle shaderModule);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceConfigure", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceConfigure(FFI.SurfaceHandle surface, FFI.SurfaceConfigurationFFI* config);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceGetCapabilities", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status SurfaceGetCapabilities(FFI.SurfaceHandle surface, FFI.AdapterHandle adapter, FFI.SurfaceCapabilitiesFFI* capabilities);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceGetCurrentTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceGetCurrentTexture(FFI.SurfaceHandle surface, FFI.SurfaceTextureFFI* surfaceTexture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceGetPreferredFormat", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureFormat SurfaceGetPreferredFormat(FFI.SurfaceHandle surface, FFI.AdapterHandle adapter);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfacePresent", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfacePresent(FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceSetLabel(FFI.SurfaceHandle surface, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceSetLabel2(FFI.SurfaceHandle surface, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceUnconfigure", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceUnconfigure(FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceAddRef(FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceRelease(FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureCreateView", CallingConvention = CallingConvention.Cdecl)]
    public static extern FFI.TextureViewHandle TextureCreateView(FFI.TextureHandle texture, FFI.TextureViewDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureDestroy(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetDepthOrArrayLayers", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetDepthOrArrayLayers(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetDimension", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureDimension TextureGetDimension(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetFormat", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureFormat TextureGetFormat(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetHeight", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetHeight(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetMipLevelCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetMipLevelCount(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetSampleCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetSampleCount(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetUsage", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureUsage TextureGetUsage(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetWidth", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetWidth(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureSetLabel(FFI.TextureHandle texture, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureSetLabel2(FFI.TextureHandle texture, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureAddRef(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureRelease(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureViewSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureViewSetLabel(FFI.TextureViewHandle textureView, byte* label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureViewSetLabel2", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureViewSetLabel2(FFI.TextureViewHandle textureView, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureViewAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureViewAddRef(FFI.TextureViewHandle textureView);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureViewRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureViewRelease(FFI.TextureViewHandle textureView);
}
