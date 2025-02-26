using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe static partial class WebGPU_FFI
{
    public const uint ARRAY_LAYER_COUNT_UNDEFINED = uint.MaxValue;
    public const uint COPY_STRIDE_UNDEFINED = uint.MaxValue;
    public const uint DEPTH_SLICE_UNDEFINED = uint.MaxValue;
    public const uint LIMIT_U32_UNDEFINED = uint.MaxValue;
    public const ulong LIMIT_U64_UNDEFINED = ulong.MaxValue;
    public const uint MIP_LEVEL_COUNT_UNDEFINED = uint.MaxValue;
    public const uint QUERY_SET_INDEX_UNDEFINED = uint.MaxValue;
    public static readonly nuint STRLEN = nuint.MaxValue;
    public static readonly nuint WHOLE_MAP_SIZE = nuint.MaxValue;
    public const ulong WHOLE_SIZE = ulong.MaxValue;

    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterInfoFreeMembers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterInfoFreeMembers(AdapterInfoFFI value);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCreateInstance", CallingConvention = CallingConvention.Cdecl)]
    public static extern InstanceHandle CreateInstance(InstanceDescriptor* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuGetInstanceCapabilities", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status GetInstanceCapabilities(InstanceCapabilities* capabilities);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSupportedWGSLLanguageFeaturesFreeMembers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SupportedWGSLLanguageFeaturesFreeMembers(SupportedWGSLLanguageFeaturesFFI value);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSupportedFeaturesFreeMembers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SupportedFeaturesFreeMembers(SupportedFeaturesFFI value);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceCapabilitiesFreeMembers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceCapabilitiesFreeMembers(SurfaceCapabilitiesFFI value);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterGetFeatures", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterGetFeatures(AdapterHandle adapter, SupportedFeaturesFFI* features);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterGetInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status AdapterGetInfo(AdapterHandle adapter, AdapterInfoFFI* info);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterGetLimits", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status AdapterGetLimits(AdapterHandle adapter, SupportedLimits* limits);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterHasFeature", CallingConvention = CallingConvention.Cdecl)]
    public static extern WebGPUBool AdapterHasFeature(AdapterHandle adapter, FeatureName feature);
    /// <summary>
    /// Requests a device from the adapter.
    /// This is a one-time action: if a device is returned successfully,
    /// the adapter becomes {{adapter/state/"consumed"}}.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="WebGpuSharp.Device"/> to request.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterRequestDevice", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future AdapterRequestDevice(AdapterHandle adapter, DeviceDescriptorFFI* options, RequestDeviceCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterAddRef(AdapterHandle adapter);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterRelease(AdapterHandle adapter);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupSetLabel(BindGroupHandle bindGroup, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupAddRef(BindGroupHandle bindGroup);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupRelease(BindGroupHandle bindGroup);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupLayoutSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupLayoutSetLabel(BindGroupLayoutHandle bindGroupLayout, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupLayoutAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupLayoutAddRef(BindGroupLayoutHandle bindGroupLayout);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupLayoutRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupLayoutRelease(BindGroupLayoutHandle bindGroupLayout);
    /// <summary>
    /// Destroys the  <see cref="WebGpuSharp.Buffer"/>.
    /// Note: It is valid to destroy a buffer multiple times.
    /// Note: Since no further operations can be enqueued using this buffer, implementations can
    /// free resource allocations, including mapped memory that was just unmapped.
    /// </summary>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferDestroy(BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetConstMappedRange", CallingConvention = CallingConvention.Cdecl)]
    public static extern void* BufferGetConstMappedRange(BufferHandle buffer, nuint offset, nuint size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetMapState", CallingConvention = CallingConvention.Cdecl)]
    public static extern BufferMapState BufferGetMapState(BufferHandle buffer);
    /// <summary>
    /// Returns an ArrayBuffer with the contents of the  <see cref="WebGpuSharp.Buffer"/> in the given mapped range.
    /// </summary>
    /// <param name="offset">Offset in bytes into the buffer to return buffer contents from.</param>
    /// <param name="size">Size in bytes of the ArrayBuffer to return.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetMappedRange", CallingConvention = CallingConvention.Cdecl)]
    public static extern void* BufferGetMappedRange(BufferHandle buffer, nuint offset, nuint size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetSize", CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong BufferGetSize(BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetUsage", CallingConvention = CallingConvention.Cdecl)]
    public static extern BufferUsage BufferGetUsage(BufferHandle buffer);
    /// <summary>
    /// Maps the given range of the  <see cref="WebGpuSharp.Buffer"/> and resolves the returned Promise when the
    ///  <see cref="WebGpuSharp.Buffer"/>'s content is ready to be accessed with  <see cref="WebGpuSharp.Buffer.GetMappedRange"/>.
    /// The resolution of the returned Promise **only** indicates that the buffer has been mapped.
    /// It does not guarantee the completion of any other operations visible to the content timeline,
    /// and in particular does not imply that any other Promise returned from
    ///  <see cref="WebGpuSharp.Queue.OnSubmittedWorkDone"/> or  <see cref="WebGpuSharp.Buffer.MapAsync"/> on other  <see cref="WebGpuSharp.Buffer"/>s
    /// have resolved.
    /// The resolution of the Promise returned from  <see cref="WebGpuSharp.Queue.OnSubmittedWorkDone"/>
    /// **does** imply the completion of
    ///  <see cref="WebGpuSharp.Buffer.MapAsync"/> calls made prior to that call,
    /// on  <see cref="WebGpuSharp.Buffer"/>s last used exclusively on that queue.
    /// </summary>
    /// <param name="mode">Whether the buffer should be mapped for reading or writing.</param>
    /// <param name="offset">Offset in bytes into the buffer to the start of the range to map.</param>
    /// <param name="size">Size in bytes of the range to map.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferMapAsync", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future BufferMapAsync(BufferHandle buffer, MapMode mode, nuint offset, nuint size, BufferMapCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferSetLabel(BufferHandle buffer, StringViewFFI label);
    /// <summary>
    /// Unmaps the mapped range of the  <see cref="WebGpuSharp.Buffer"/> and makes its contents available for use by the
    /// GPU again.
    /// </summary>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferUnmap", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferUnmap(BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferAddRef(BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferRelease(BufferHandle buffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandBufferSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandBufferSetLabel(CommandBufferHandle commandBuffer, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandBufferAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandBufferAddRef(CommandBufferHandle commandBuffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandBufferRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandBufferRelease(CommandBufferHandle commandBuffer);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderBeginComputePass", CallingConvention = CallingConvention.Cdecl)]
    public static extern ComputePassEncoderHandle CommandEncoderBeginComputePass(CommandEncoderHandle commandEncoder, ComputePassDescriptorFFI* descriptor);
    /// <summary>
    /// Begins encoding a render pass described by <paramref name="descriptor"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="WebGpuSharp.RenderPassEncoder"/> to create.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderBeginRenderPass", CallingConvention = CallingConvention.Cdecl)]
    public static extern RenderPassEncoderHandle CommandEncoderBeginRenderPass(CommandEncoderHandle commandEncoder, RenderPassDescriptorFFI* descriptor);
    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that fills a sub-region of a
    ///  <see cref="WebGpuSharp.Buffer"/> with zeros.
    /// </summary>
    /// <param name="buffer">The  <see cref="WebGpuSharp.Buffer"/> to clear.</param>
    /// <param name="offset">Offset in bytes into <paramref name="buffer"/> where the sub-region to clear begins.</param>
    /// <param name="size">Size in bytes of the sub-region to clear. Defaults to the size of the buffer minus <paramref name="offset"/>.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderClearBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderClearBuffer(CommandEncoderHandle commandEncoder, BufferHandle buffer, ulong offset, ulong size);
    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that copies data from a sub-region of a
    ///  <see cref="WebGpuSharp.Buffer"/> to a sub-region of another  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    /// <param name="source">The  <see cref="WebGpuSharp.Buffer"/> to copy from.</param>
    /// <param name="sourceOffset">Offset in bytes into <paramref name="source"/> to begin copying from.</param>
    /// <param name="destination">The  <see cref="WebGpuSharp.Buffer"/> to copy to.</param>
    /// <param name="destinationOffset">Offset in bytes into <paramref name="destination"/> to place the copied data.</param>
    /// <param name="size">Bytes to copy.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyBufferToBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderCopyBufferToBuffer(CommandEncoderHandle commandEncoder, BufferHandle source, ulong sourceOffset, BufferHandle destination, ulong destinationOffset, ulong size);
    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that copies data from a sub-region of a
    ///  <see cref="WebGpuSharp.Buffer"/> to a sub-region of one or multiple continuous texture subresources.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source buffer.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination texture subresource.
    /// <paramref name="copySize"/>:
    /// </param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyBufferToTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderCopyBufferToTexture(CommandEncoderHandle commandEncoder, ImageCopyBufferFFI* source, ImageCopyTextureFFI* destination, Extent3D* copySize);
    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that copies data from a sub-region of one or
    /// multiple continuous texture subresources to a sub-region of a  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source texture subresources.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination buffer.
    /// <paramref name="copySize"/>:
    /// </param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyTextureToBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderCopyTextureToBuffer(CommandEncoderHandle commandEncoder, ImageCopyTextureFFI* source, ImageCopyBufferFFI* destination, Extent3D* copySize);
    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that copies data from a sub-region of one
    /// or multiple contiguous texture subresources to another sub-region of one or
    /// multiple continuous texture subresources.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source texture subresources.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination texture subresources.
    /// <paramref name="copySize"/>:
    /// </param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyTextureToTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderCopyTextureToTexture(CommandEncoderHandle commandEncoder, ImageCopyTextureFFI* source, ImageCopyTextureFFI* destination, Extent3D* copySize);
    /// <summary>
    /// Completes recording of the commands sequence and returns a corresponding  <see cref="WebGpuSharp.CommandBuffer"/>.
    /// </summary>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderFinish", CallingConvention = CallingConvention.Cdecl)]
    public static extern CommandBufferHandle CommandEncoderFinish(CommandEncoderHandle commandEncoder, CommandBufferDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderInsertDebugMarker(CommandEncoderHandle commandEncoder, StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderPopDebugGroup(CommandEncoderHandle commandEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderPushDebugGroup(CommandEncoderHandle commandEncoder, StringViewFFI groupLabel);
    /// <summary>
    /// Resolves query results from a  <see cref="WebGpuSharp.QuerySet"/> out into a range of a  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderResolveQuerySet", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderResolveQuerySet(CommandEncoderHandle commandEncoder, QuerySetHandle querySet, uint firstQuery, uint queryCount, BufferHandle destination, ulong destinationOffset);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderSetLabel(CommandEncoderHandle commandEncoder, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderWriteTimestamp", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderWriteTimestamp(CommandEncoderHandle commandEncoder, QuerySetHandle querySet, uint queryIndex);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderAddRef(CommandEncoderHandle commandEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderRelease(CommandEncoderHandle commandEncoder);
    /// <summary>
    /// Dispatch work to be performed with the current  <see cref="WebGpuSharp.ComputePipeline"/>.
    /// See #computing-operations for the detailed specification.
    /// </summary>
    /// <param name="workgroupCountX">X dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountY">Y dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountZ">Z dimension of the grid of workgroups to dispatch.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderDispatchWorkgroups", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderDispatchWorkgroups(ComputePassEncoderHandle computePassEncoder, uint workgroupCountX, uint workgroupCountY, uint workgroupCountZ);
    /// <summary>
    /// Dispatch work to be performed with the current  <see cref="WebGpuSharp.ComputePipeline"/> using parameters read
    /// from a  <see cref="WebGpuSharp.Buffer"/>.
    /// See #computing-operations for the detailed specification.
    /// packed block of **three 32-bit unsigned integer values (12 bytes total)**,
    /// given in the same order as the arguments for  <see cref="WebGpuSharp.ComputePassEncoder.DispatchWorkgroups"/>.
    /// For example:
    /// </summary>
    /// <param name="indirectBuffer">Buffer containing the indirect dispatch parameters.</param>
    /// <param name="indirectOffset">Offset in bytes into <paramref name="indirectBuffer"/> where the dispatch data begins.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderDispatchWorkgroupsIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderDispatchWorkgroupsIndirect(ComputePassEncoderHandle computePassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the compute pass commands sequence.
    /// </summary>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderEnd", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderEnd(ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderInsertDebugMarker(ComputePassEncoderHandle computePassEncoder, StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderPopDebugGroup(ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderPushDebugGroup(ComputePassEncoderHandle computePassEncoder, StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderSetBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderSetBindGroup(ComputePassEncoderHandle computePassEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderSetLabel(ComputePassEncoderHandle computePassEncoder, StringViewFFI label);
    /// <summary>
    /// Sets the current  <see cref="WebGpuSharp.ComputePipeline"/>.
    /// </summary>
    /// <param name="pipeline">The compute pipeline to use for subsequent dispatch commands.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderSetPipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderSetPipeline(ComputePassEncoderHandle computePassEncoder, ComputePipelineHandle pipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderAddRef(ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderRelease(ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineGetBindGroupLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern BindGroupLayoutHandle ComputePipelineGetBindGroupLayout(ComputePipelineHandle computePipeline, uint groupIndex);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePipelineSetLabel(ComputePipelineHandle computePipeline, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePipelineAddRef(ComputePipelineHandle computePipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePipelineRelease(ComputePipelineHandle computePipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern BindGroupHandle DeviceCreateBindGroup(DeviceHandle device, BindGroupDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateBindGroupLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern BindGroupLayoutHandle DeviceCreateBindGroupLayout(DeviceHandle device, BindGroupLayoutDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern BufferHandle DeviceCreateBuffer(DeviceHandle device, BufferDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateCommandEncoder", CallingConvention = CallingConvention.Cdecl)]
    public static extern CommandEncoderHandle DeviceCreateCommandEncoder(DeviceHandle device, CommandEncoderDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateComputePipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern ComputePipelineHandle DeviceCreateComputePipeline(DeviceHandle device, ComputePipelineDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateComputePipelineAsync", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future DeviceCreateComputePipelineAsync(DeviceHandle device, ComputePipelineDescriptorFFI* descriptor, CreateComputePipelineAsyncCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreatePipelineLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern PipelineLayoutHandle DeviceCreatePipelineLayout(DeviceHandle device, PipelineLayoutDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateQuerySet", CallingConvention = CallingConvention.Cdecl)]
    public static extern QuerySetHandle DeviceCreateQuerySet(DeviceHandle device, QuerySetDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateRenderBundleEncoder", CallingConvention = CallingConvention.Cdecl)]
    public static extern RenderBundleEncoderHandle DeviceCreateRenderBundleEncoder(DeviceHandle device, RenderBundleEncoderDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateRenderPipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern RenderPipelineHandle DeviceCreateRenderPipeline(DeviceHandle device, RenderPipelineDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateRenderPipelineAsync", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future DeviceCreateRenderPipelineAsync(DeviceHandle device, RenderPipelineDescriptorFFI* descriptor, CreateRenderPipelineAsyncCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateSampler", CallingConvention = CallingConvention.Cdecl)]
    public static extern SamplerHandle DeviceCreateSampler(DeviceHandle device, SamplerDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateShaderModule", CallingConvention = CallingConvention.Cdecl)]
    public static extern ShaderModuleHandle DeviceCreateShaderModule(DeviceHandle device, ShaderModuleDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureHandle DeviceCreateTexture(DeviceHandle device, TextureDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceDestroy(DeviceHandle device);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetAdapterInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status DeviceGetAdapterInfo(DeviceHandle device, AdapterInfoFFI* adapterInfo);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetFeatures", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceGetFeatures(DeviceHandle device, SupportedFeaturesFFI* features);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetLimits", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status DeviceGetLimits(DeviceHandle device, SupportedLimits* limits);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetLostFuture", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future DeviceGetLostFuture(DeviceHandle device);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetQueue", CallingConvention = CallingConvention.Cdecl)]
    public static extern QueueHandle DeviceGetQueue(DeviceHandle device);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceHasFeature", CallingConvention = CallingConvention.Cdecl)]
    public static extern WebGPUBool DeviceHasFeature(DeviceHandle device, FeatureName feature);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDevicePopErrorScope", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future DevicePopErrorScope(DeviceHandle device, PopErrorScopeCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDevicePushErrorScope", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DevicePushErrorScope(DeviceHandle device, ErrorFilter filter);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceSetLabel(DeviceHandle device, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceAddRef(DeviceHandle device);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceRelease(DeviceHandle device);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceCreateSurface", CallingConvention = CallingConvention.Cdecl)]
    public static extern SurfaceHandle InstanceCreateSurface(InstanceHandle instance, SurfaceDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceGetWGSLLanguageFeatures", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status InstanceGetWGSLLanguageFeatures(InstanceHandle instance, SupportedWGSLLanguageFeaturesFFI* features);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceHasWGSLLanguageFeature", CallingConvention = CallingConvention.Cdecl)]
    public static extern WebGPUBool InstanceHasWGSLLanguageFeature(InstanceHandle instance, WGSLLanguageFeatureName feature);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceProcessEvents", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InstanceProcessEvents(InstanceHandle instance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceRequestAdapter", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future InstanceRequestAdapter(InstanceHandle instance, RequestAdapterOptionsFFI* options, RequestAdapterCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceWaitAny", CallingConvention = CallingConvention.Cdecl)]
    public static extern WaitStatus InstanceWaitAny(InstanceHandle instance, nuint futureCount, FutureWaitInfo* futures, ulong timeoutNS);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InstanceAddRef(InstanceHandle instance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InstanceRelease(InstanceHandle instance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuPipelineLayoutSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void PipelineLayoutSetLabel(PipelineLayoutHandle pipelineLayout, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuPipelineLayoutAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void PipelineLayoutAddRef(PipelineLayoutHandle pipelineLayout);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuPipelineLayoutRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void PipelineLayoutRelease(PipelineLayoutHandle pipelineLayout);
    /// <summary>
    /// Destroys the  <see cref="WebGpuSharp.QuerySet"/>.
    /// </summary>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuerySetDestroy(QuerySetHandle querySet);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetGetCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint QuerySetGetCount(QuerySetHandle querySet);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetGetType", CallingConvention = CallingConvention.Cdecl)]
    public static extern QueryType QuerySetGetType(QuerySetHandle querySet);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuerySetSetLabel(QuerySetHandle querySet, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuerySetAddRef(QuerySetHandle querySet);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuerySetRelease(QuerySetHandle querySet);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueOnSubmittedWorkDone", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future QueueOnSubmittedWorkDone(QueueHandle queue, QueueWorkDoneCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueSetLabel(QueueHandle queue, StringViewFFI label);
    /// <summary>
    /// Schedules the execution of the command buffers by the GPU on this queue.
    /// Submitted command buffers cannot be used again.
    /// </summary>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueSubmit", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueSubmit(QueueHandle queue, nuint commandCount, CommandBufferHandle* commands);
    /// <summary>
    /// Issues a write operation of the provided data into a  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    /// <param name="buffer">The buffer to write to.</param>
    /// <param name="bufferOffset">Offset in bytes into <paramref name="buffer"/> to begin writing at.</param>
    /// <param name="data">Data to write into <paramref name="buffer"/>.</param>
    /// <param name="dataOffset">
    /// Offset in into <paramref name="data"/> to begin writing from. Given in elements if
    /// <paramref name="data"/> is a `TypedArray` and bytes otherwise.
    /// </param>
    /// <param name="size">
    /// Size of content to write from <paramref name="data"/> to <paramref name="buffer"/>. Given in elements if
    /// <paramref name="data"/> is a `TypedArray` and bytes otherwise.
    /// </param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueWriteBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueWriteBuffer(QueueHandle queue, BufferHandle buffer, ulong bufferOffset, void* data, nuint size);
    /// <summary>
    /// Issues a write operation of the provided data into a  <see cref="WebGpuSharp.Texture"/>.
    /// </summary>
    /// <param name="destination">The texture subresource and origin to write to.</param>
    /// <param name="data">Data to write into <paramref name="destination"/>.</param>
    /// <param name="dataLayout">Layout of the content in <paramref name="data"/>.</param>
    /// <param name="size">Extents of the content to write from <paramref name="data"/> to <paramref name="destination"/>.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueWriteTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueWriteTexture(QueueHandle queue, ImageCopyTextureFFI* destination, void* data, nuint dataSize, TextureDataLayout* dataLayout, Extent3D* writeSize);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueAddRef(QueueHandle queue);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueRelease(QueueHandle queue);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleSetLabel(RenderBundleHandle renderBundle, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleAddRef(RenderBundleHandle renderBundle);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleRelease(RenderBundleHandle renderBundle);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDraw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDraw(RenderBundleEncoderHandle renderBundleEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDrawIndexed", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDrawIndexed(RenderBundleEncoderHandle renderBundleEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDrawIndexedIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDrawIndexedIndirect(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDrawIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDrawIndirect(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the render bundle commands sequence.
    /// </summary>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderFinish", CallingConvention = CallingConvention.Cdecl)]
    public static extern RenderBundleHandle RenderBundleEncoderFinish(RenderBundleEncoderHandle renderBundleEncoder, RenderBundleDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderInsertDebugMarker(RenderBundleEncoderHandle renderBundleEncoder, StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderPopDebugGroup(RenderBundleEncoderHandle renderBundleEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderPushDebugGroup(RenderBundleEncoderHandle renderBundleEncoder, StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetBindGroup(RenderBundleEncoderHandle renderBundleEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetIndexBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetIndexBuffer(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle buffer, IndexFormat format, ulong offset, ulong size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetLabel(RenderBundleEncoderHandle renderBundleEncoder, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetPipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetPipeline(RenderBundleEncoderHandle renderBundleEncoder, RenderPipelineHandle pipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetVertexBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetVertexBuffer(RenderBundleEncoderHandle renderBundleEncoder, uint slot, BufferHandle buffer, ulong offset, ulong size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderAddRef(RenderBundleEncoderHandle renderBundleEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderRelease(RenderBundleEncoderHandle renderBundleEncoder);
    /// <param name="queryIndex">The index of the query in the query set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderBeginOcclusionQuery", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderBeginOcclusionQuery(RenderPassEncoderHandle renderPassEncoder, uint queryIndex);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDraw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDraw(RenderPassEncoderHandle renderPassEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDrawIndexed", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDrawIndexed(RenderPassEncoderHandle renderPassEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDrawIndexedIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDrawIndexedIndirect(RenderPassEncoderHandle renderPassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDrawIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDrawIndirect(RenderPassEncoderHandle renderPassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the render pass commands sequence.
    /// </summary>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderEnd", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderEnd(RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderEndOcclusionQuery", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderEndOcclusionQuery(RenderPassEncoderHandle renderPassEncoder);
    /// <summary>
    /// Executes the commands previously recorded into the given  <see cref="WebGpuSharp.RenderBundle"/>s as part of
    /// this render pass.
    /// When a  <see cref="WebGpuSharp.RenderBundle"/> is executed, it does not inherit the render pass's pipeline, bind
    /// groups, or vertex and index buffers. After a  <see cref="WebGpuSharp.RenderBundle"/> has executed, the render
    /// pass's pipeline, bind group, and vertex/index buffer state is cleared
    /// (to the initial, empty values).
    /// Note: The state is cleared, not restored to the previous state.
    /// This occurs even if zero  <see cref="WebGpuSharp.RenderBundle">GPURenderBundles</see> are executed.
    /// </summary>
    /// <param name="bundles">List of render bundles to execute.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderExecuteBundles", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderExecuteBundles(RenderPassEncoderHandle renderPassEncoder, nuint bundleCount, RenderBundleHandle* bundles);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderInsertDebugMarker(RenderPassEncoderHandle renderPassEncoder, StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderPopDebugGroup(RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderPushDebugGroup(RenderPassEncoderHandle renderPassEncoder, StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetBindGroup(RenderPassEncoderHandle renderPassEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    /// <summary>
    /// Sets the constant blend color and alpha values used with  <see cref="BlendFactor.Constant"/>
    /// and  <see cref="BlendFactor.One-minus-constant"/>  <see cref="BlendFactor"/>s.
    /// </summary>
    /// <param name="color">The color to use when blending.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetBlendConstant", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetBlendConstant(RenderPassEncoderHandle renderPassEncoder, Color* color);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetIndexBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetIndexBuffer(RenderPassEncoderHandle renderPassEncoder, BufferHandle buffer, IndexFormat format, ulong offset, ulong size);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetLabel(RenderPassEncoderHandle renderPassEncoder, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetPipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetPipeline(RenderPassEncoderHandle renderPassEncoder, RenderPipelineHandle pipeline);
    /// <summary>
    /// Sets the scissor rectangle used during the rasterization stage.
    /// After transformation into viewport coordinates any fragments which fall outside the scissor
    /// rectangle will be discarded.
    /// </summary>
    /// <param name="x">Minimum X value of the scissor rectangle in pixels.</param>
    /// <param name="y">Minimum Y value of the scissor rectangle in pixels.</param>
    /// <param name="width">Width of the scissor rectangle in pixels.</param>
    /// <param name="height">Height of the scissor rectangle in pixels.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetScissorRect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetScissorRect(RenderPassEncoderHandle renderPassEncoder, uint x, uint y, uint width, uint height);
    /// <summary>
    /// Sets the {{RenderState/stencilReference}} value used during stencil tests with
    /// the  <see cref="StencilOperation.Replace"/>  <see cref="StencilOperation"/>.
    /// </summary>
    /// <param name="reference">The new stencil reference value.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetStencilReference", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetStencilReference(RenderPassEncoderHandle renderPassEncoder, uint reference);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetVertexBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetVertexBuffer(RenderPassEncoderHandle renderPassEncoder, uint slot, BufferHandle buffer, ulong offset, ulong size);
    /// <summary>
    /// Sets the viewport used during the rasterization stage to linearly map from
    /// normalized device coordinates to viewport coordinates.
    /// </summary>
    /// <param name="x">Minimum X value of the viewport in pixels.</param>
    /// <param name="y">Minimum Y value of the viewport in pixels.</param>
    /// <param name="width">Width of the viewport in pixels.</param>
    /// <param name="height">Height of the viewport in pixels.</param>
    /// <param name="minDepth">Minimum depth value of the viewport.</param>
    /// <param name="maxDepth">Maximum depth value of the viewport.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetViewport", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetViewport(RenderPassEncoderHandle renderPassEncoder, float x, float y, float width, float height, float minDepth, float maxDepth);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderAddRef(RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderRelease(RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineGetBindGroupLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern BindGroupLayoutHandle RenderPipelineGetBindGroupLayout(RenderPipelineHandle renderPipeline, uint groupIndex);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPipelineSetLabel(RenderPipelineHandle renderPipeline, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPipelineAddRef(RenderPipelineHandle renderPipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPipelineRelease(RenderPipelineHandle renderPipeline);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSamplerSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SamplerSetLabel(SamplerHandle sampler, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSamplerAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SamplerAddRef(SamplerHandle sampler);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSamplerRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SamplerRelease(SamplerHandle sampler);
    /// <summary>
    /// Returns any messages generated during the  <see cref="WebGpuSharp.ShaderModule"/>'s compilation.
    /// The locations, order, and contents of messages are implementation-defined
    /// In particular, messages may not be ordered by  <see cref="WebGpuSharp.CompilationMessage.LineNum"/>.
    /// </summary>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleGetCompilationInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future ShaderModuleGetCompilationInfo(ShaderModuleHandle shaderModule, CompilationInfoCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ShaderModuleSetLabel(ShaderModuleHandle shaderModule, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ShaderModuleAddRef(ShaderModuleHandle shaderModule);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ShaderModuleRelease(ShaderModuleHandle shaderModule);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceConfigure", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceConfigure(SurfaceHandle surface, SurfaceConfigurationFFI* config);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceGetCapabilities", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status SurfaceGetCapabilities(SurfaceHandle surface, AdapterHandle adapter, SurfaceCapabilitiesFFI* capabilities);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceGetCurrentTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceGetCurrentTexture(SurfaceHandle surface, SurfaceTextureFFI* surfaceTexture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfacePresent", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfacePresent(SurfaceHandle surface);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceSetLabel(SurfaceHandle surface, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceUnconfigure", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceUnconfigure(SurfaceHandle surface);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceAddRef(SurfaceHandle surface);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceRelease(SurfaceHandle surface);
    /// <summary>
    /// Creates a  <see cref="WebGpuSharp.TextureView"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="WebGpuSharp.TextureView"/> to create.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureCreateView", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureViewHandle TextureCreateView(TextureHandle texture, TextureViewDescriptorFFI* descriptor);
    /// <summary>
    /// Destroys the  <see cref="WebGpuSharp.Texture"/>.
    /// </summary>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureDestroy(TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetDepthOrArrayLayers", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetDepthOrArrayLayers(TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetDimension", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureDimension TextureGetDimension(TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetFormat", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureFormat TextureGetFormat(TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetHeight", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetHeight(TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetMipLevelCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetMipLevelCount(TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetSampleCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetSampleCount(TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetUsage", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureUsage TextureGetUsage(TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetWidth", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetWidth(TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureSetLabel(TextureHandle texture, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureAddRef(TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureRelease(TextureHandle texture);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureViewSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureViewSetLabel(TextureViewHandle textureView, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureViewAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureViewAddRef(TextureViewHandle textureView);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureViewRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureViewRelease(TextureViewHandle textureView);
}
