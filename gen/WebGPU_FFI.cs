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
    public static readonly nuint STRLEN = nuint.MaxValue;
    public static readonly nuint WHOLE_MAP_SIZE = nuint.MaxValue;
    public const ulong WHOLE_SIZE = ulong.MaxValue;

    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterInfoFreeMembers")]
    public static extern void AdapterInfoFreeMembers(FFI.AdapterInfoFFI value);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCreateInstance")]
    public static extern FFI.InstanceHandle CreateInstance(InstanceDescriptor* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuGetInstanceCapabilities")]
    public static extern Status GetInstanceCapabilities(InstanceCapabilities* capabilities);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSupportedWGSLLanguageFeaturesFreeMembers")]
    public static extern void SupportedWGSLLanguageFeaturesFreeMembers(FFI.SupportedWGSLLanguageFeaturesFFI value);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSupportedFeaturesFreeMembers")]
    public static extern void SupportedFeaturesFreeMembers(FFI.SupportedFeaturesFFI value);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceCapabilitiesFreeMembers")]
    public static extern void SurfaceCapabilitiesFreeMembers(FFI.SurfaceCapabilitiesFFI value);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetFeatures")]
    public static extern void AdapterGetFeatures(FFI.AdapterHandle adapter, FFI.SupportedFeaturesFFI* features);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetInfo")]
    public static extern Status AdapterGetInfo(FFI.AdapterHandle adapter, FFI.AdapterInfoFFI* info);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetLimits")]
    public static extern Status AdapterGetLimits(FFI.AdapterHandle adapter, SupportedLimits* limits);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterHasFeature")]
    public static extern WebGPUBool AdapterHasFeature(FFI.AdapterHandle adapter, FeatureName feature);
    /// <summary>
    /// Requests a device from the adapter.
    /// This is a one-time action: if a device is returned successfully,
    /// the adapter becomes {{adapter/state/"consumed"}}.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="WebGpuSharp.Device"/> to request.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterRequestDevice")]
    public static extern Future AdapterRequestDevice(FFI.AdapterHandle adapter, FFI.DeviceDescriptorFFI* options, FFI.RequestDeviceCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterAddRef")]
    public static extern void AdapterAddRef(FFI.AdapterHandle adapter);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterRelease")]
    public static extern void AdapterRelease(FFI.AdapterHandle adapter);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupSetLabel")]
    public static extern void BindGroupSetLabel(FFI.BindGroupHandle bindGroup, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupAddRef")]
    public static extern void BindGroupAddRef(FFI.BindGroupHandle bindGroup);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupRelease")]
    public static extern void BindGroupRelease(FFI.BindGroupHandle bindGroup);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupLayoutSetLabel")]
    public static extern void BindGroupLayoutSetLabel(FFI.BindGroupLayoutHandle bindGroupLayout, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupLayoutAddRef")]
    public static extern void BindGroupLayoutAddRef(FFI.BindGroupLayoutHandle bindGroupLayout);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupLayoutRelease")]
    public static extern void BindGroupLayoutRelease(FFI.BindGroupLayoutHandle bindGroupLayout);
    /// <summary>
    /// Destroys the  <see cref="WebGpuSharp.Buffer"/>.
    /// Note: It is valid to destroy a buffer multiple times.
    /// Note: Since no further operations can be enqueued using this buffer, implementations can
    /// free resource allocations, including mapped memory that was just unmapped.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferDestroy")]
    public static extern void BufferDestroy(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetConstMappedRange")]
    public static extern void* BufferGetConstMappedRange(FFI.BufferHandle buffer, nuint offset, nuint size);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetMapState")]
    public static extern BufferMapState BufferGetMapState(FFI.BufferHandle buffer);
    /// <summary>
    /// Returns an ArrayBuffer with the contents of the  <see cref="WebGpuSharp.Buffer"/> in the given mapped range.
    /// </summary>
    /// <param name="offset">Offset in bytes into the buffer to return buffer contents from.</param>
    /// <param name="size">Size in bytes of the ArrayBuffer to return.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetMappedRange")]
    public static extern void* BufferGetMappedRange(FFI.BufferHandle buffer, nuint offset, nuint size);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetSize")]
    public static extern ulong BufferGetSize(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetUsage")]
    public static extern BufferUsage BufferGetUsage(FFI.BufferHandle buffer);
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
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferMapAsync")]
    public static extern Future BufferMapAsync(FFI.BufferHandle buffer, MapMode mode, nuint offset, nuint size, FFI.BufferMapCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferSetLabel")]
    public static extern void BufferSetLabel(FFI.BufferHandle buffer, FFI.StringViewFFI label);
    /// <summary>
    /// Unmaps the mapped range of the  <see cref="WebGpuSharp.Buffer"/> and makes its contents available for use by the
    /// GPU again.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferUnmap")]
    public static extern void BufferUnmap(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferAddRef")]
    public static extern void BufferAddRef(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferRelease")]
    public static extern void BufferRelease(FFI.BufferHandle buffer);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandBufferSetLabel")]
    public static extern void CommandBufferSetLabel(FFI.CommandBufferHandle commandBuffer, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandBufferAddRef")]
    public static extern void CommandBufferAddRef(FFI.CommandBufferHandle commandBuffer);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandBufferRelease")]
    public static extern void CommandBufferRelease(FFI.CommandBufferHandle commandBuffer);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderBeginComputePass")]
    public static extern FFI.ComputePassEncoderHandle CommandEncoderBeginComputePass(FFI.CommandEncoderHandle commandEncoder, FFI.ComputePassDescriptorFFI* descriptor);
    /// <summary>
    /// Begins encoding a render pass described by <paramref name="descriptor"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="WebGpuSharp.RenderPassEncoder"/> to create.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderBeginRenderPass")]
    public static extern FFI.RenderPassEncoderHandle CommandEncoderBeginRenderPass(FFI.CommandEncoderHandle commandEncoder, FFI.RenderPassDescriptorFFI* descriptor);
    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that fills a sub-region of a
    ///  <see cref="WebGpuSharp.Buffer"/> with zeros.
    /// </summary>
    /// <param name="buffer">The  <see cref="WebGpuSharp.Buffer"/> to clear.</param>
    /// <param name="offset">Offset in bytes into <paramref name="buffer"/> where the sub-region to clear begins.</param>
    /// <param name="size">Size in bytes of the sub-region to clear. Defaults to the size of the buffer minus <paramref name="offset"/>.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderClearBuffer")]
    public static extern void CommandEncoderClearBuffer(FFI.CommandEncoderHandle commandEncoder, FFI.BufferHandle buffer, ulong offset, ulong size);
    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that copies data from a sub-region of a
    ///  <see cref="WebGpuSharp.Buffer"/> to a sub-region of another  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    /// <param name="source">The  <see cref="WebGpuSharp.Buffer"/> to copy from.</param>
    /// <param name="sourceOffset">Offset in bytes into <paramref name="source"/> to begin copying from.</param>
    /// <param name="destination">The  <see cref="WebGpuSharp.Buffer"/> to copy to.</param>
    /// <param name="destinationOffset">Offset in bytes into <paramref name="destination"/> to place the copied data.</param>
    /// <param name="size">Bytes to copy.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyBufferToBuffer")]
    public static extern void CommandEncoderCopyBufferToBuffer(FFI.CommandEncoderHandle commandEncoder, FFI.BufferHandle source, ulong sourceOffset, FFI.BufferHandle destination, ulong destinationOffset, ulong size);
    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that copies data from a sub-region of a
    ///  <see cref="WebGpuSharp.Buffer"/> to a sub-region of one or multiple continuous texture subresources.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source buffer.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination texture subresource.
    /// <paramref name="copySize"/>:
    /// </param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyBufferToTexture")]
    public static extern void CommandEncoderCopyBufferToTexture(FFI.CommandEncoderHandle commandEncoder, FFI.ImageCopyBufferFFI* source, FFI.ImageCopyTextureFFI* destination, Extent3D* copySize);
    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that copies data from a sub-region of one or
    /// multiple continuous texture subresources to a sub-region of a  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source texture subresources.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination buffer.
    /// <paramref name="copySize"/>:
    /// </param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyTextureToBuffer")]
    public static extern void CommandEncoderCopyTextureToBuffer(FFI.CommandEncoderHandle commandEncoder, FFI.ImageCopyTextureFFI* source, FFI.ImageCopyBufferFFI* destination, Extent3D* copySize);
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
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyTextureToTexture")]
    public static extern void CommandEncoderCopyTextureToTexture(FFI.CommandEncoderHandle commandEncoder, FFI.ImageCopyTextureFFI* source, FFI.ImageCopyTextureFFI* destination, Extent3D* copySize);
    /// <summary>
    /// Completes recording of the commands sequence and returns a corresponding  <see cref="WebGpuSharp.CommandBuffer"/>.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderFinish")]
    public static extern FFI.CommandBufferHandle CommandEncoderFinish(FFI.CommandEncoderHandle commandEncoder, FFI.CommandBufferDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderInsertDebugMarker")]
    public static extern void CommandEncoderInsertDebugMarker(FFI.CommandEncoderHandle commandEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderPopDebugGroup")]
    public static extern void CommandEncoderPopDebugGroup(FFI.CommandEncoderHandle commandEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderPushDebugGroup")]
    public static extern void CommandEncoderPushDebugGroup(FFI.CommandEncoderHandle commandEncoder, FFI.StringViewFFI groupLabel);
    /// <summary>
    /// Resolves query results from a  <see cref="WebGpuSharp.QuerySet"/> out into a range of a  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderResolveQuerySet")]
    public static extern void CommandEncoderResolveQuerySet(FFI.CommandEncoderHandle commandEncoder, FFI.QuerySetHandle querySet, uint firstQuery, uint queryCount, FFI.BufferHandle destination, ulong destinationOffset);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderSetLabel")]
    public static extern void CommandEncoderSetLabel(FFI.CommandEncoderHandle commandEncoder, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderWriteTimestamp")]
    public static extern void CommandEncoderWriteTimestamp(FFI.CommandEncoderHandle commandEncoder, FFI.QuerySetHandle querySet, uint queryIndex);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderAddRef")]
    public static extern void CommandEncoderAddRef(FFI.CommandEncoderHandle commandEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderRelease")]
    public static extern void CommandEncoderRelease(FFI.CommandEncoderHandle commandEncoder);
    /// <summary>
    /// Dispatch work to be performed with the current  <see cref="WebGpuSharp.ComputePipeline"/>.
    /// See #computing-operations for the detailed specification.
    /// </summary>
    /// <param name="workgroupCountX">X dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountY">Y dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountZ">Z dimension of the grid of workgroups to dispatch.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderDispatchWorkgroups")]
    public static extern void ComputePassEncoderDispatchWorkgroups(FFI.ComputePassEncoderHandle computePassEncoder, uint workgroupCountX, uint workgroupCountY, uint workgroupCountZ);
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
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderDispatchWorkgroupsIndirect")]
    public static extern void ComputePassEncoderDispatchWorkgroupsIndirect(FFI.ComputePassEncoderHandle computePassEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the compute pass commands sequence.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderEnd")]
    public static extern void ComputePassEncoderEnd(FFI.ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderInsertDebugMarker")]
    public static extern void ComputePassEncoderInsertDebugMarker(FFI.ComputePassEncoderHandle computePassEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderPopDebugGroup")]
    public static extern void ComputePassEncoderPopDebugGroup(FFI.ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderPushDebugGroup")]
    public static extern void ComputePassEncoderPushDebugGroup(FFI.ComputePassEncoderHandle computePassEncoder, FFI.StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetBindGroup")]
    public static extern void ComputePassEncoderSetBindGroup(FFI.ComputePassEncoderHandle computePassEncoder, uint groupIndex, FFI.BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetLabel")]
    public static extern void ComputePassEncoderSetLabel(FFI.ComputePassEncoderHandle computePassEncoder, FFI.StringViewFFI label);
    /// <summary>
    /// Sets the current  <see cref="WebGpuSharp.ComputePipeline"/>.
    /// </summary>
    /// <param name="pipeline">The compute pipeline to use for subsequent dispatch commands.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetPipeline")]
    public static extern void ComputePassEncoderSetPipeline(FFI.ComputePassEncoderHandle computePassEncoder, FFI.ComputePipelineHandle pipeline);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderAddRef")]
    public static extern void ComputePassEncoderAddRef(FFI.ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderRelease")]
    public static extern void ComputePassEncoderRelease(FFI.ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineGetBindGroupLayout")]
    public static extern FFI.BindGroupLayoutHandle ComputePipelineGetBindGroupLayout(FFI.ComputePipelineHandle computePipeline, uint groupIndex);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineSetLabel")]
    public static extern void ComputePipelineSetLabel(FFI.ComputePipelineHandle computePipeline, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineAddRef")]
    public static extern void ComputePipelineAddRef(FFI.ComputePipelineHandle computePipeline);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineRelease")]
    public static extern void ComputePipelineRelease(FFI.ComputePipelineHandle computePipeline);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateBindGroup")]
    public static extern FFI.BindGroupHandle DeviceCreateBindGroup(FFI.DeviceHandle device, FFI.BindGroupDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateBindGroupLayout")]
    public static extern FFI.BindGroupLayoutHandle DeviceCreateBindGroupLayout(FFI.DeviceHandle device, FFI.BindGroupLayoutDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateBuffer")]
    public static extern FFI.BufferHandle DeviceCreateBuffer(FFI.DeviceHandle device, FFI.BufferDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateCommandEncoder")]
    public static extern FFI.CommandEncoderHandle DeviceCreateCommandEncoder(FFI.DeviceHandle device, FFI.CommandEncoderDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateComputePipeline")]
    public static extern FFI.ComputePipelineHandle DeviceCreateComputePipeline(FFI.DeviceHandle device, FFI.ComputePipelineDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateComputePipelineAsync")]
    public static extern Future DeviceCreateComputePipelineAsync(FFI.DeviceHandle device, FFI.ComputePipelineDescriptorFFI* descriptor, FFI.CreateComputePipelineAsyncCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreatePipelineLayout")]
    public static extern FFI.PipelineLayoutHandle DeviceCreatePipelineLayout(FFI.DeviceHandle device, FFI.PipelineLayoutDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateQuerySet")]
    public static extern FFI.QuerySetHandle DeviceCreateQuerySet(FFI.DeviceHandle device, FFI.QuerySetDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderBundleEncoder")]
    public static extern FFI.RenderBundleEncoderHandle DeviceCreateRenderBundleEncoder(FFI.DeviceHandle device, FFI.RenderBundleEncoderDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderPipeline")]
    public static extern FFI.RenderPipelineHandle DeviceCreateRenderPipeline(FFI.DeviceHandle device, FFI.RenderPipelineDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderPipelineAsync")]
    public static extern Future DeviceCreateRenderPipelineAsync(FFI.DeviceHandle device, FFI.RenderPipelineDescriptorFFI* descriptor, FFI.CreateRenderPipelineAsyncCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateSampler")]
    public static extern FFI.SamplerHandle DeviceCreateSampler(FFI.DeviceHandle device, FFI.SamplerDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateShaderModule")]
    public static extern FFI.ShaderModuleHandle DeviceCreateShaderModule(FFI.DeviceHandle device, FFI.ShaderModuleDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateTexture")]
    public static extern FFI.TextureHandle DeviceCreateTexture(FFI.DeviceHandle device, FFI.TextureDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceDestroy")]
    public static extern void DeviceDestroy(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetAdapterInfo")]
    public static extern Status DeviceGetAdapterInfo(FFI.DeviceHandle device, FFI.AdapterInfoFFI* adapterInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetFeatures")]
    public static extern void DeviceGetFeatures(FFI.DeviceHandle device, FFI.SupportedFeaturesFFI* features);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetLimits")]
    public static extern Status DeviceGetLimits(FFI.DeviceHandle device, SupportedLimits* limits);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetLostFuture")]
    public static extern Future DeviceGetLostFuture(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetQueue")]
    public static extern FFI.QueueHandle DeviceGetQueue(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceHasFeature")]
    public static extern WebGPUBool DeviceHasFeature(FFI.DeviceHandle device, FeatureName feature);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDevicePopErrorScope")]
    public static extern Future DevicePopErrorScope(FFI.DeviceHandle device, FFI.PopErrorScopeCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDevicePushErrorScope")]
    public static extern void DevicePushErrorScope(FFI.DeviceHandle device, ErrorFilter filter);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceSetLabel")]
    public static extern void DeviceSetLabel(FFI.DeviceHandle device, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceAddRef")]
    public static extern void DeviceAddRef(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceRelease")]
    public static extern void DeviceRelease(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceCreateSurface")]
    public static extern FFI.SurfaceHandle InstanceCreateSurface(FFI.InstanceHandle instance, FFI.SurfaceDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceGetWGSLLanguageFeatures")]
    public static extern Status InstanceGetWGSLLanguageFeatures(FFI.InstanceHandle instance, FFI.SupportedWGSLLanguageFeaturesFFI* features);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceHasWGSLLanguageFeature")]
    public static extern WebGPUBool InstanceHasWGSLLanguageFeature(FFI.InstanceHandle instance, WGSLLanguageFeatureName feature);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceProcessEvents")]
    public static extern void InstanceProcessEvents(FFI.InstanceHandle instance);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceRequestAdapter")]
    public static extern Future InstanceRequestAdapter(FFI.InstanceHandle instance, FFI.RequestAdapterOptionsFFI* options, FFI.RequestAdapterCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceWaitAny")]
    public static extern WaitStatus InstanceWaitAny(FFI.InstanceHandle instance, nuint futureCount, FutureWaitInfo* futures, ulong timeoutNS);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceAddRef")]
    public static extern void InstanceAddRef(FFI.InstanceHandle instance);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceRelease")]
    public static extern void InstanceRelease(FFI.InstanceHandle instance);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuPipelineLayoutSetLabel")]
    public static extern void PipelineLayoutSetLabel(FFI.PipelineLayoutHandle pipelineLayout, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuPipelineLayoutAddRef")]
    public static extern void PipelineLayoutAddRef(FFI.PipelineLayoutHandle pipelineLayout);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuPipelineLayoutRelease")]
    public static extern void PipelineLayoutRelease(FFI.PipelineLayoutHandle pipelineLayout);
    /// <summary>
    /// Destroys the  <see cref="WebGpuSharp.QuerySet"/>.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetDestroy")]
    public static extern void QuerySetDestroy(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetGetCount")]
    public static extern uint QuerySetGetCount(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetGetType")]
    public static extern QueryType QuerySetGetType(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetSetLabel")]
    public static extern void QuerySetSetLabel(FFI.QuerySetHandle querySet, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetAddRef")]
    public static extern void QuerySetAddRef(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetRelease")]
    public static extern void QuerySetRelease(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueOnSubmittedWorkDone")]
    public static extern Future QueueOnSubmittedWorkDone(FFI.QueueHandle queue, FFI.QueueWorkDoneCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueSetLabel")]
    public static extern void QueueSetLabel(FFI.QueueHandle queue, FFI.StringViewFFI label);
    /// <summary>
    /// Schedules the execution of the command buffers by the GPU on this queue.
    /// Submitted command buffers cannot be used again.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueSubmit")]
    public static extern void QueueSubmit(FFI.QueueHandle queue, nuint commandCount, FFI.CommandBufferHandle* commands);
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
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueWriteBuffer")]
    public static extern void QueueWriteBuffer(FFI.QueueHandle queue, FFI.BufferHandle buffer, ulong bufferOffset, void* data, nuint size);
    /// <summary>
    /// Issues a write operation of the provided data into a  <see cref="WebGpuSharp.Texture"/>.
    /// </summary>
    /// <param name="destination">The texture subresource and origin to write to.</param>
    /// <param name="data">Data to write into <paramref name="destination"/>.</param>
    /// <param name="dataLayout">Layout of the content in <paramref name="data"/>.</param>
    /// <param name="size">Extents of the content to write from <paramref name="data"/> to <paramref name="destination"/>.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueWriteTexture")]
    public static extern void QueueWriteTexture(FFI.QueueHandle queue, FFI.ImageCopyTextureFFI* destination, void* data, nuint dataSize, TextureDataLayout* dataLayout, Extent3D* writeSize);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueAddRef")]
    public static extern void QueueAddRef(FFI.QueueHandle queue);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueRelease")]
    public static extern void QueueRelease(FFI.QueueHandle queue);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleSetLabel")]
    public static extern void RenderBundleSetLabel(FFI.RenderBundleHandle renderBundle, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleAddRef")]
    public static extern void RenderBundleAddRef(FFI.RenderBundleHandle renderBundle);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleRelease")]
    public static extern void RenderBundleRelease(FFI.RenderBundleHandle renderBundle);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDraw")]
    public static extern void RenderBundleEncoderDraw(FFI.RenderBundleEncoderHandle renderBundleEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDrawIndexed")]
    public static extern void RenderBundleEncoderDrawIndexed(FFI.RenderBundleEncoderHandle renderBundleEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDrawIndexedIndirect")]
    public static extern void RenderBundleEncoderDrawIndexedIndirect(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDrawIndirect")]
    public static extern void RenderBundleEncoderDrawIndirect(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the render bundle commands sequence.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderFinish")]
    public static extern FFI.RenderBundleHandle RenderBundleEncoderFinish(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.RenderBundleDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderInsertDebugMarker")]
    public static extern void RenderBundleEncoderInsertDebugMarker(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderPopDebugGroup")]
    public static extern void RenderBundleEncoderPopDebugGroup(FFI.RenderBundleEncoderHandle renderBundleEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderPushDebugGroup")]
    public static extern void RenderBundleEncoderPushDebugGroup(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetBindGroup")]
    public static extern void RenderBundleEncoderSetBindGroup(FFI.RenderBundleEncoderHandle renderBundleEncoder, uint groupIndex, FFI.BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetIndexBuffer")]
    public static extern void RenderBundleEncoderSetIndexBuffer(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.BufferHandle buffer, IndexFormat format, ulong offset, ulong size);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetLabel")]
    public static extern void RenderBundleEncoderSetLabel(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetPipeline")]
    public static extern void RenderBundleEncoderSetPipeline(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.RenderPipelineHandle pipeline);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetVertexBuffer")]
    public static extern void RenderBundleEncoderSetVertexBuffer(FFI.RenderBundleEncoderHandle renderBundleEncoder, uint slot, FFI.BufferHandle buffer, ulong offset, ulong size);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderAddRef")]
    public static extern void RenderBundleEncoderAddRef(FFI.RenderBundleEncoderHandle renderBundleEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderRelease")]
    public static extern void RenderBundleEncoderRelease(FFI.RenderBundleEncoderHandle renderBundleEncoder);
    /// <param name="queryIndex">The index of the query in the query set.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderBeginOcclusionQuery")]
    public static extern void RenderPassEncoderBeginOcclusionQuery(FFI.RenderPassEncoderHandle renderPassEncoder, uint queryIndex);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDraw")]
    public static extern void RenderPassEncoderDraw(FFI.RenderPassEncoderHandle renderPassEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDrawIndexed")]
    public static extern void RenderPassEncoderDrawIndexed(FFI.RenderPassEncoderHandle renderPassEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDrawIndexedIndirect")]
    public static extern void RenderPassEncoderDrawIndexedIndirect(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDrawIndirect")]
    public static extern void RenderPassEncoderDrawIndirect(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the render pass commands sequence.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderEnd")]
    public static extern void RenderPassEncoderEnd(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderEndOcclusionQuery")]
    public static extern void RenderPassEncoderEndOcclusionQuery(FFI.RenderPassEncoderHandle renderPassEncoder);
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
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderExecuteBundles")]
    public static extern void RenderPassEncoderExecuteBundles(FFI.RenderPassEncoderHandle renderPassEncoder, nuint bundleCount, FFI.RenderBundleHandle* bundles);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderInsertDebugMarker")]
    public static extern void RenderPassEncoderInsertDebugMarker(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderPopDebugGroup")]
    public static extern void RenderPassEncoderPopDebugGroup(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderPushDebugGroup")]
    public static extern void RenderPassEncoderPushDebugGroup(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetBindGroup")]
    public static extern void RenderPassEncoderSetBindGroup(FFI.RenderPassEncoderHandle renderPassEncoder, uint groupIndex, FFI.BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    /// <summary>
    /// Sets the constant blend color and alpha values used with  <see cref="BlendFactor.Constant"/>
    /// and  <see cref="BlendFactor.One-minus-constant"/>  <see cref="BlendFactor"/>s.
    /// </summary>
    /// <param name="color">The color to use when blending.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetBlendConstant")]
    public static extern void RenderPassEncoderSetBlendConstant(FFI.RenderPassEncoderHandle renderPassEncoder, Color* color);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetIndexBuffer")]
    public static extern void RenderPassEncoderSetIndexBuffer(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.BufferHandle buffer, IndexFormat format, ulong offset, ulong size);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetLabel")]
    public static extern void RenderPassEncoderSetLabel(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetPipeline")]
    public static extern void RenderPassEncoderSetPipeline(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.RenderPipelineHandle pipeline);
    /// <summary>
    /// Sets the scissor rectangle used during the rasterization stage.
    /// After transformation into viewport coordinates any fragments which fall outside the scissor
    /// rectangle will be discarded.
    /// </summary>
    /// <param name="x">Minimum X value of the scissor rectangle in pixels.</param>
    /// <param name="y">Minimum Y value of the scissor rectangle in pixels.</param>
    /// <param name="width">Width of the scissor rectangle in pixels.</param>
    /// <param name="height">Height of the scissor rectangle in pixels.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetScissorRect")]
    public static extern void RenderPassEncoderSetScissorRect(FFI.RenderPassEncoderHandle renderPassEncoder, uint x, uint y, uint width, uint height);
    /// <summary>
    /// Sets the {{RenderState/stencilReference}} value used during stencil tests with
    /// the  <see cref="StencilOperation.Replace"/>  <see cref="StencilOperation"/>.
    /// </summary>
    /// <param name="reference">The new stencil reference value.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetStencilReference")]
    public static extern void RenderPassEncoderSetStencilReference(FFI.RenderPassEncoderHandle renderPassEncoder, uint reference);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetVertexBuffer")]
    public static extern void RenderPassEncoderSetVertexBuffer(FFI.RenderPassEncoderHandle renderPassEncoder, uint slot, FFI.BufferHandle buffer, ulong offset, ulong size);
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
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetViewport")]
    public static extern void RenderPassEncoderSetViewport(FFI.RenderPassEncoderHandle renderPassEncoder, float x, float y, float width, float height, float minDepth, float maxDepth);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderAddRef")]
    public static extern void RenderPassEncoderAddRef(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderRelease")]
    public static extern void RenderPassEncoderRelease(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineGetBindGroupLayout")]
    public static extern FFI.BindGroupLayoutHandle RenderPipelineGetBindGroupLayout(FFI.RenderPipelineHandle renderPipeline, uint groupIndex);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineSetLabel")]
    public static extern void RenderPipelineSetLabel(FFI.RenderPipelineHandle renderPipeline, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineAddRef")]
    public static extern void RenderPipelineAddRef(FFI.RenderPipelineHandle renderPipeline);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineRelease")]
    public static extern void RenderPipelineRelease(FFI.RenderPipelineHandle renderPipeline);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSamplerSetLabel")]
    public static extern void SamplerSetLabel(FFI.SamplerHandle sampler, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSamplerAddRef")]
    public static extern void SamplerAddRef(FFI.SamplerHandle sampler);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSamplerRelease")]
    public static extern void SamplerRelease(FFI.SamplerHandle sampler);
    /// <summary>
    /// Returns any messages generated during the  <see cref="WebGpuSharp.ShaderModule"/>'s compilation.
    /// The locations, order, and contents of messages are implementation-defined
    /// In particular, messages may not be ordered by  <see cref="WebGpuSharp.CompilationMessage.LineNum"/>.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleGetCompilationInfo")]
    public static extern Future ShaderModuleGetCompilationInfo(FFI.ShaderModuleHandle shaderModule, FFI.CompilationInfoCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleSetLabel")]
    public static extern void ShaderModuleSetLabel(FFI.ShaderModuleHandle shaderModule, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleAddRef")]
    public static extern void ShaderModuleAddRef(FFI.ShaderModuleHandle shaderModule);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleRelease")]
    public static extern void ShaderModuleRelease(FFI.ShaderModuleHandle shaderModule);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceConfigure")]
    public static extern void SurfaceConfigure(FFI.SurfaceHandle surface, FFI.SurfaceConfigurationFFI* config);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceGetCapabilities")]
    public static extern Status SurfaceGetCapabilities(FFI.SurfaceHandle surface, FFI.AdapterHandle adapter, FFI.SurfaceCapabilitiesFFI* capabilities);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceGetCurrentTexture")]
    public static extern void SurfaceGetCurrentTexture(FFI.SurfaceHandle surface, FFI.SurfaceTextureFFI* surfaceTexture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfacePresent")]
    public static extern void SurfacePresent(FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceSetLabel")]
    public static extern void SurfaceSetLabel(FFI.SurfaceHandle surface, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceUnconfigure")]
    public static extern void SurfaceUnconfigure(FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceAddRef")]
    public static extern void SurfaceAddRef(FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceRelease")]
    public static extern void SurfaceRelease(FFI.SurfaceHandle surface);
    /// <summary>
    /// Creates a  <see cref="WebGpuSharp.TextureView"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="WebGpuSharp.TextureView"/> to create.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureCreateView")]
    public static extern FFI.TextureViewHandle TextureCreateView(FFI.TextureHandle texture, FFI.TextureViewDescriptorFFI* descriptor);
    /// <summary>
    /// Destroys the  <see cref="WebGpuSharp.Texture"/>.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureDestroy")]
    public static extern void TextureDestroy(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetDepthOrArrayLayers")]
    public static extern uint TextureGetDepthOrArrayLayers(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetDimension")]
    public static extern TextureDimension TextureGetDimension(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetFormat")]
    public static extern TextureFormat TextureGetFormat(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetHeight")]
    public static extern uint TextureGetHeight(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetMipLevelCount")]
    public static extern uint TextureGetMipLevelCount(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetSampleCount")]
    public static extern uint TextureGetSampleCount(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetUsage")]
    public static extern TextureUsage TextureGetUsage(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetWidth")]
    public static extern uint TextureGetWidth(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureSetLabel")]
    public static extern void TextureSetLabel(FFI.TextureHandle texture, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureAddRef")]
    public static extern void TextureAddRef(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureRelease")]
    public static extern void TextureRelease(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewSetLabel")]
    public static extern void TextureViewSetLabel(FFI.TextureViewHandle textureView, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewAddRef")]
    public static extern void TextureViewAddRef(FFI.TextureViewHandle textureView);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewRelease")]
    public static extern void TextureViewRelease(FFI.TextureViewHandle textureView);
}
