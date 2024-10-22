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

    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterInfoFreeMembers")]
    public static extern void AdapterInfoFreeMembers(FFI.AdapterInfoFFI value);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterPropertiesMemoryHeapsFreeMembers")]
    public static extern void AdapterPropertiesMemoryHeapsFreeMembers(FFI.AdapterPropertiesMemoryHeapsFFI value);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCreateInstance")]
    public static extern FFI.InstanceHandle CreateInstance(InstanceDescriptor* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDrmFormatCapabilitiesFreeMembers")]
    public static extern void DrmFormatCapabilitiesFreeMembers(FFI.DrmFormatCapabilitiesFFI value);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuGetInstanceFeatures")]
    public static extern Status GetInstanceFeatures(InstanceFeatures* features);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedBufferMemoryEndAccessStateFreeMembers")]
    public static extern void SharedBufferMemoryEndAccessStateFreeMembers(FFI.SharedBufferMemoryEndAccessStateFFI value);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryEndAccessStateFreeMembers")]
    public static extern void SharedTextureMemoryEndAccessStateFreeMembers(FFI.SharedTextureMemoryEndAccessStateFFI value);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceCapabilitiesFreeMembers")]
    public static extern void SurfaceCapabilitiesFreeMembers(FFI.SurfaceCapabilitiesFFI value);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterCreateDevice")]
    public static extern FFI.DeviceHandle AdapterCreateDevice(FFI.AdapterHandle adapter, FFI.DeviceDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterEnumerateFeatures")]
    public static extern nuint AdapterEnumerateFeatures(FFI.AdapterHandle adapter, FeatureName* features);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetFormatCapabilities")]
    public static extern Status AdapterGetFormatCapabilities(FFI.AdapterHandle adapter, TextureFormat format, FormatCapabilities* capabilities);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetInfo")]
    public static extern Status AdapterGetInfo(FFI.AdapterHandle adapter, FFI.AdapterInfoFFI* info);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetInstance")]
    public static extern FFI.InstanceHandle AdapterGetInstance(FFI.AdapterHandle adapter);
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
    public static extern void AdapterRequestDevice(FFI.AdapterHandle adapter, FFI.DeviceDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<RequestDeviceStatus, FFI.DeviceHandle, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterRequestDevice2")]
    public static extern Future AdapterRequestDevice2(FFI.AdapterHandle adapter, FFI.DeviceDescriptorFFI* options, FFI.RequestDeviceCallbackInfo2FFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterRequestDeviceF")]
    public static extern Future AdapterRequestDeviceF(FFI.AdapterHandle adapter, FFI.DeviceDescriptorFFI* options, FFI.RequestDeviceCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterAddRef")]
    public static extern void AdapterAddRef(FFI.AdapterHandle adapter);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterRelease")]
    public static extern void AdapterRelease(FFI.AdapterHandle adapter);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupSetLabel")]
    public static extern void BindGroupSetLabel(FFI.BindGroupHandle bindGroup, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupSetLabel2")]
    public static extern void BindGroupSetLabel2(FFI.BindGroupHandle bindGroup, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupAddRef")]
    public static extern void BindGroupAddRef(FFI.BindGroupHandle bindGroup);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupRelease")]
    public static extern void BindGroupRelease(FFI.BindGroupHandle bindGroup);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupLayoutSetLabel")]
    public static extern void BindGroupLayoutSetLabel(FFI.BindGroupLayoutHandle bindGroupLayout, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupLayoutSetLabel2")]
    public static extern void BindGroupLayoutSetLabel2(FFI.BindGroupLayoutHandle bindGroupLayout, FFI.StringViewFFI label);
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
    public static extern void BufferMapAsync(FFI.BufferHandle buffer, MapMode mode, nuint offset, nuint size, delegate* unmanaged[Cdecl]<BufferMapAsyncStatus, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferMapAsync2")]
    public static extern Future BufferMapAsync2(FFI.BufferHandle buffer, MapMode mode, nuint offset, nuint size, FFI.BufferMapCallbackInfo2FFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferMapAsyncF")]
    public static extern Future BufferMapAsyncF(FFI.BufferHandle buffer, MapMode mode, nuint offset, nuint size, FFI.BufferMapCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferSetLabel")]
    public static extern void BufferSetLabel(FFI.BufferHandle buffer, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferSetLabel2")]
    public static extern void BufferSetLabel2(FFI.BufferHandle buffer, FFI.StringViewFFI label);
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
    public static extern void CommandBufferSetLabel(FFI.CommandBufferHandle commandBuffer, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandBufferSetLabel2")]
    public static extern void CommandBufferSetLabel2(FFI.CommandBufferHandle commandBuffer, FFI.StringViewFFI label);
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
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderInjectValidationError")]
    public static extern void CommandEncoderInjectValidationError(FFI.CommandEncoderHandle commandEncoder, byte* message);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderInjectValidationError2")]
    public static extern void CommandEncoderInjectValidationError2(FFI.CommandEncoderHandle commandEncoder, FFI.StringViewFFI message);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderInsertDebugMarker")]
    public static extern void CommandEncoderInsertDebugMarker(FFI.CommandEncoderHandle commandEncoder, byte* markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderInsertDebugMarker2")]
    public static extern void CommandEncoderInsertDebugMarker2(FFI.CommandEncoderHandle commandEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderPopDebugGroup")]
    public static extern void CommandEncoderPopDebugGroup(FFI.CommandEncoderHandle commandEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderPushDebugGroup")]
    public static extern void CommandEncoderPushDebugGroup(FFI.CommandEncoderHandle commandEncoder, byte* groupLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderPushDebugGroup2")]
    public static extern void CommandEncoderPushDebugGroup2(FFI.CommandEncoderHandle commandEncoder, FFI.StringViewFFI groupLabel);
    /// <summary>
    /// Resolves query results from a  <see cref="WebGpuSharp.QuerySet"/> out into a range of a  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderResolveQuerySet")]
    public static extern void CommandEncoderResolveQuerySet(FFI.CommandEncoderHandle commandEncoder, FFI.QuerySetHandle querySet, uint firstQuery, uint queryCount, FFI.BufferHandle destination, ulong destinationOffset);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderSetLabel")]
    public static extern void CommandEncoderSetLabel(FFI.CommandEncoderHandle commandEncoder, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderSetLabel2")]
    public static extern void CommandEncoderSetLabel2(FFI.CommandEncoderHandle commandEncoder, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderWriteBuffer")]
    public static extern void CommandEncoderWriteBuffer(FFI.CommandEncoderHandle commandEncoder, FFI.BufferHandle buffer, ulong bufferOffset, byte* data, ulong size);
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
    public static extern void ComputePassEncoderInsertDebugMarker(FFI.ComputePassEncoderHandle computePassEncoder, byte* markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderInsertDebugMarker2")]
    public static extern void ComputePassEncoderInsertDebugMarker2(FFI.ComputePassEncoderHandle computePassEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderPopDebugGroup")]
    public static extern void ComputePassEncoderPopDebugGroup(FFI.ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderPushDebugGroup")]
    public static extern void ComputePassEncoderPushDebugGroup(FFI.ComputePassEncoderHandle computePassEncoder, byte* groupLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderPushDebugGroup2")]
    public static extern void ComputePassEncoderPushDebugGroup2(FFI.ComputePassEncoderHandle computePassEncoder, FFI.StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetBindGroup")]
    public static extern void ComputePassEncoderSetBindGroup(FFI.ComputePassEncoderHandle computePassEncoder, uint groupIndex, FFI.BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetLabel")]
    public static extern void ComputePassEncoderSetLabel(FFI.ComputePassEncoderHandle computePassEncoder, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetLabel2")]
    public static extern void ComputePassEncoderSetLabel2(FFI.ComputePassEncoderHandle computePassEncoder, FFI.StringViewFFI label);
    /// <summary>
    /// Sets the current  <see cref="WebGpuSharp.ComputePipeline"/>.
    /// </summary>
    /// <param name="pipeline">The compute pipeline to use for subsequent dispatch commands.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetPipeline")]
    public static extern void ComputePassEncoderSetPipeline(FFI.ComputePassEncoderHandle computePassEncoder, FFI.ComputePipelineHandle pipeline);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderWriteTimestamp")]
    public static extern void ComputePassEncoderWriteTimestamp(FFI.ComputePassEncoderHandle computePassEncoder, FFI.QuerySetHandle querySet, uint queryIndex);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderAddRef")]
    public static extern void ComputePassEncoderAddRef(FFI.ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderRelease")]
    public static extern void ComputePassEncoderRelease(FFI.ComputePassEncoderHandle computePassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineGetBindGroupLayout")]
    public static extern FFI.BindGroupLayoutHandle ComputePipelineGetBindGroupLayout(FFI.ComputePipelineHandle computePipeline, uint groupIndex);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineSetLabel")]
    public static extern void ComputePipelineSetLabel(FFI.ComputePipelineHandle computePipeline, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineSetLabel2")]
    public static extern void ComputePipelineSetLabel2(FFI.ComputePipelineHandle computePipeline, FFI.StringViewFFI label);
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
    public static extern void DeviceCreateComputePipelineAsync(FFI.DeviceHandle device, FFI.ComputePipelineDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, FFI.ComputePipelineHandle, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateComputePipelineAsync2")]
    public static extern Future DeviceCreateComputePipelineAsync2(FFI.DeviceHandle device, FFI.ComputePipelineDescriptorFFI* descriptor, FFI.CreateComputePipelineAsyncCallbackInfo2FFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateComputePipelineAsyncF")]
    public static extern Future DeviceCreateComputePipelineAsyncF(FFI.DeviceHandle device, FFI.ComputePipelineDescriptorFFI* descriptor, FFI.CreateComputePipelineAsyncCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateErrorBuffer")]
    public static extern FFI.BufferHandle DeviceCreateErrorBuffer(FFI.DeviceHandle device, FFI.BufferDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateErrorExternalTexture")]
    public static extern FFI.ExternalTextureHandle DeviceCreateErrorExternalTexture(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateErrorShaderModule")]
    public static extern FFI.ShaderModuleHandle DeviceCreateErrorShaderModule(FFI.DeviceHandle device, FFI.ShaderModuleDescriptorFFI* descriptor, byte* errorMessage);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateErrorShaderModule2")]
    public static extern FFI.ShaderModuleHandle DeviceCreateErrorShaderModule2(FFI.DeviceHandle device, FFI.ShaderModuleDescriptorFFI* descriptor, FFI.StringViewFFI errorMessage);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateErrorTexture")]
    public static extern FFI.TextureHandle DeviceCreateErrorTexture(FFI.DeviceHandle device, FFI.TextureDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateExternalTexture")]
    public static extern FFI.ExternalTextureHandle DeviceCreateExternalTexture(FFI.DeviceHandle device, FFI.ExternalTextureDescriptorFFI* externalTextureDescriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreatePipelineLayout")]
    public static extern FFI.PipelineLayoutHandle DeviceCreatePipelineLayout(FFI.DeviceHandle device, FFI.PipelineLayoutDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateQuerySet")]
    public static extern FFI.QuerySetHandle DeviceCreateQuerySet(FFI.DeviceHandle device, FFI.QuerySetDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderBundleEncoder")]
    public static extern FFI.RenderBundleEncoderHandle DeviceCreateRenderBundleEncoder(FFI.DeviceHandle device, FFI.RenderBundleEncoderDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderPipeline")]
    public static extern FFI.RenderPipelineHandle DeviceCreateRenderPipeline(FFI.DeviceHandle device, FFI.RenderPipelineDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderPipelineAsync")]
    public static extern void DeviceCreateRenderPipelineAsync(FFI.DeviceHandle device, FFI.RenderPipelineDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, FFI.RenderPipelineHandle, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderPipelineAsync2")]
    public static extern Future DeviceCreateRenderPipelineAsync2(FFI.DeviceHandle device, FFI.RenderPipelineDescriptorFFI* descriptor, FFI.CreateRenderPipelineAsyncCallbackInfo2FFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderPipelineAsyncF")]
    public static extern Future DeviceCreateRenderPipelineAsyncF(FFI.DeviceHandle device, FFI.RenderPipelineDescriptorFFI* descriptor, FFI.CreateRenderPipelineAsyncCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateSampler")]
    public static extern FFI.SamplerHandle DeviceCreateSampler(FFI.DeviceHandle device, FFI.SamplerDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateShaderModule")]
    public static extern FFI.ShaderModuleHandle DeviceCreateShaderModule(FFI.DeviceHandle device, FFI.ShaderModuleDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateSwapChain")]
    public static extern FFI.SwapChainHandle DeviceCreateSwapChain(FFI.DeviceHandle device, FFI.SurfaceHandle surface, FFI.SwapChainDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateTexture")]
    public static extern FFI.TextureHandle DeviceCreateTexture(FFI.DeviceHandle device, FFI.TextureDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceDestroy")]
    public static extern void DeviceDestroy(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceEnumerateFeatures")]
    public static extern nuint DeviceEnumerateFeatures(FFI.DeviceHandle device, FeatureName* features);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceForceLoss")]
    public static extern void DeviceForceLoss(FFI.DeviceHandle device, DeviceLostReason type, byte* message);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceForceLoss2")]
    public static extern void DeviceForceLoss2(FFI.DeviceHandle device, DeviceLostReason type, FFI.StringViewFFI message);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetAHardwareBufferProperties")]
    public static extern Status DeviceGetAHardwareBufferProperties(FFI.DeviceHandle device, void* handle, AHardwareBufferProperties* properties);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetAdapter")]
    public static extern FFI.AdapterHandle DeviceGetAdapter(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetLimits")]
    public static extern Status DeviceGetLimits(FFI.DeviceHandle device, SupportedLimits* limits);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetQueue")]
    public static extern FFI.QueueHandle DeviceGetQueue(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetSupportedSurfaceUsage")]
    public static extern TextureUsage DeviceGetSupportedSurfaceUsage(FFI.DeviceHandle device, FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceHasFeature")]
    public static extern WebGPUBool DeviceHasFeature(FFI.DeviceHandle device, FeatureName feature);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceImportSharedBufferMemory")]
    public static extern FFI.SharedBufferMemoryHandle DeviceImportSharedBufferMemory(FFI.DeviceHandle device, FFI.SharedBufferMemoryDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceImportSharedFence")]
    public static extern FFI.SharedFenceHandle DeviceImportSharedFence(FFI.DeviceHandle device, FFI.SharedFenceDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceImportSharedTextureMemory")]
    public static extern FFI.SharedTextureMemoryHandle DeviceImportSharedTextureMemory(FFI.DeviceHandle device, FFI.SharedTextureMemoryDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceInjectError")]
    public static extern void DeviceInjectError(FFI.DeviceHandle device, ErrorType type, byte* message);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceInjectError2")]
    public static extern void DeviceInjectError2(FFI.DeviceHandle device, ErrorType type, FFI.StringViewFFI message);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDevicePopErrorScope")]
    public static extern void DevicePopErrorScope(FFI.DeviceHandle device, delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> oldCallback, void* userdata);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDevicePopErrorScope2")]
    public static extern Future DevicePopErrorScope2(FFI.DeviceHandle device, FFI.PopErrorScopeCallbackInfo2FFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDevicePopErrorScopeF")]
    public static extern Future DevicePopErrorScopeF(FFI.DeviceHandle device, FFI.PopErrorScopeCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDevicePushErrorScope")]
    public static extern void DevicePushErrorScope(FFI.DeviceHandle device, ErrorFilter filter);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceSetDeviceLostCallback")]
    public static extern void DeviceSetDeviceLostCallback(FFI.DeviceHandle device, delegate* unmanaged[Cdecl]<DeviceLostReason, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceSetLabel")]
    public static extern void DeviceSetLabel(FFI.DeviceHandle device, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceSetLabel2")]
    public static extern void DeviceSetLabel2(FFI.DeviceHandle device, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceSetLoggingCallback")]
    public static extern void DeviceSetLoggingCallback(FFI.DeviceHandle device, delegate* unmanaged[Cdecl]<LoggingType, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceSetUncapturedErrorCallback")]
    public static extern void DeviceSetUncapturedErrorCallback(FFI.DeviceHandle device, delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceTick")]
    public static extern void DeviceTick(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceValidateTextureDescriptor")]
    public static extern void DeviceValidateTextureDescriptor(FFI.DeviceHandle device, FFI.TextureDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceAddRef")]
    public static extern void DeviceAddRef(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceRelease")]
    public static extern void DeviceRelease(FFI.DeviceHandle device);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureDestroy")]
    public static extern void ExternalTextureDestroy(FFI.ExternalTextureHandle externalTexture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureExpire")]
    public static extern void ExternalTextureExpire(FFI.ExternalTextureHandle externalTexture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureRefresh")]
    public static extern void ExternalTextureRefresh(FFI.ExternalTextureHandle externalTexture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureSetLabel")]
    public static extern void ExternalTextureSetLabel(FFI.ExternalTextureHandle externalTexture, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureSetLabel2")]
    public static extern void ExternalTextureSetLabel2(FFI.ExternalTextureHandle externalTexture, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureAddRef")]
    public static extern void ExternalTextureAddRef(FFI.ExternalTextureHandle externalTexture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuExternalTextureRelease")]
    public static extern void ExternalTextureRelease(FFI.ExternalTextureHandle externalTexture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceCreateSurface")]
    public static extern FFI.SurfaceHandle InstanceCreateSurface(FFI.InstanceHandle instance, FFI.SurfaceDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceEnumerateWGSLLanguageFeatures")]
    public static extern nuint InstanceEnumerateWGSLLanguageFeatures(FFI.InstanceHandle instance, WGSLFeatureName* features);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceHasWGSLLanguageFeature")]
    public static extern WebGPUBool InstanceHasWGSLLanguageFeature(FFI.InstanceHandle instance, WGSLFeatureName feature);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceProcessEvents")]
    public static extern void InstanceProcessEvents(FFI.InstanceHandle instance);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceRequestAdapter")]
    public static extern void InstanceRequestAdapter(FFI.InstanceHandle instance, FFI.RequestAdapterOptionsFFI* options, delegate* unmanaged[Cdecl]<RequestAdapterStatus, FFI.AdapterHandle, byte*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceRequestAdapter2")]
    public static extern Future InstanceRequestAdapter2(FFI.InstanceHandle instance, FFI.RequestAdapterOptionsFFI* options, FFI.RequestAdapterCallbackInfo2FFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceRequestAdapterF")]
    public static extern Future InstanceRequestAdapterF(FFI.InstanceHandle instance, FFI.RequestAdapterOptionsFFI* options, FFI.RequestAdapterCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceWaitAny")]
    public static extern WaitStatus InstanceWaitAny(FFI.InstanceHandle instance, nuint futureCount, FutureWaitInfo* futures, ulong timeoutNS);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceAddRef")]
    public static extern void InstanceAddRef(FFI.InstanceHandle instance);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceRelease")]
    public static extern void InstanceRelease(FFI.InstanceHandle instance);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuPipelineLayoutSetLabel")]
    public static extern void PipelineLayoutSetLabel(FFI.PipelineLayoutHandle pipelineLayout, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuPipelineLayoutSetLabel2")]
    public static extern void PipelineLayoutSetLabel2(FFI.PipelineLayoutHandle pipelineLayout, FFI.StringViewFFI label);
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
    public static extern void QuerySetSetLabel(FFI.QuerySetHandle querySet, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetSetLabel2")]
    public static extern void QuerySetSetLabel2(FFI.QuerySetHandle querySet, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetAddRef")]
    public static extern void QuerySetAddRef(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetRelease")]
    public static extern void QuerySetRelease(FFI.QuerySetHandle querySet);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueCopyExternalTextureForBrowser")]
    public static extern void QueueCopyExternalTextureForBrowser(FFI.QueueHandle queue, FFI.ImageCopyExternalTextureFFI* source, FFI.ImageCopyTextureFFI* destination, Extent3D* copySize, FFI.CopyTextureForBrowserOptionsFFI* options);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueCopyTextureForBrowser")]
    public static extern void QueueCopyTextureForBrowser(FFI.QueueHandle queue, FFI.ImageCopyTextureFFI* source, FFI.ImageCopyTextureFFI* destination, Extent3D* copySize, FFI.CopyTextureForBrowserOptionsFFI* options);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueOnSubmittedWorkDone")]
    public static extern void QueueOnSubmittedWorkDone(FFI.QueueHandle queue, delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueOnSubmittedWorkDone2")]
    public static extern Future QueueOnSubmittedWorkDone2(FFI.QueueHandle queue, FFI.QueueWorkDoneCallbackInfo2FFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueOnSubmittedWorkDoneF")]
    public static extern Future QueueOnSubmittedWorkDoneF(FFI.QueueHandle queue, FFI.QueueWorkDoneCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueSetLabel")]
    public static extern void QueueSetLabel(FFI.QueueHandle queue, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueSetLabel2")]
    public static extern void QueueSetLabel2(FFI.QueueHandle queue, FFI.StringViewFFI label);
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
    public static extern void RenderBundleSetLabel(FFI.RenderBundleHandle renderBundle, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleSetLabel2")]
    public static extern void RenderBundleSetLabel2(FFI.RenderBundleHandle renderBundle, FFI.StringViewFFI label);
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
    public static extern void RenderBundleEncoderInsertDebugMarker(FFI.RenderBundleEncoderHandle renderBundleEncoder, byte* markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderInsertDebugMarker2")]
    public static extern void RenderBundleEncoderInsertDebugMarker2(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderPopDebugGroup")]
    public static extern void RenderBundleEncoderPopDebugGroup(FFI.RenderBundleEncoderHandle renderBundleEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderPushDebugGroup")]
    public static extern void RenderBundleEncoderPushDebugGroup(FFI.RenderBundleEncoderHandle renderBundleEncoder, byte* groupLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderPushDebugGroup2")]
    public static extern void RenderBundleEncoderPushDebugGroup2(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.StringViewFFI groupLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetBindGroup")]
    public static extern void RenderBundleEncoderSetBindGroup(FFI.RenderBundleEncoderHandle renderBundleEncoder, uint groupIndex, FFI.BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetIndexBuffer")]
    public static extern void RenderBundleEncoderSetIndexBuffer(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.BufferHandle buffer, IndexFormat format, ulong offset, ulong size);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetLabel")]
    public static extern void RenderBundleEncoderSetLabel(FFI.RenderBundleEncoderHandle renderBundleEncoder, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetLabel2")]
    public static extern void RenderBundleEncoderSetLabel2(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetPipeline")]
    public static extern void RenderBundleEncoderSetPipeline(FFI.RenderBundleEncoderHandle renderBundleEncoder, FFI.RenderPipelineHandle pipeline);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetVertexBuffer")]
    public static extern void RenderBundleEncoderSetVertexBuffer(FFI.RenderBundleEncoderHandle renderBundleEncoder, uint slot, FFI.BufferHandle buffer, ulong offset, ulong size);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderAddRef")]
    public static extern void RenderBundleEncoderAddRef(FFI.RenderBundleEncoderHandle renderBundleEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderRelease")]
    public static extern void RenderBundleEncoderRelease(FFI.RenderBundleEncoderHandle renderBundleEncoder);
    /// <summary>
    /// </summary>
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
    public static extern void RenderPassEncoderInsertDebugMarker(FFI.RenderPassEncoderHandle renderPassEncoder, byte* markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderInsertDebugMarker2")]
    public static extern void RenderPassEncoderInsertDebugMarker2(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.StringViewFFI markerLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderMultiDrawIndexedIndirect")]
    public static extern void RenderPassEncoderMultiDrawIndexedIndirect(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset, uint maxDrawCount, FFI.BufferHandle drawCountBuffer, ulong drawCountBufferOffset);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderMultiDrawIndirect")]
    public static extern void RenderPassEncoderMultiDrawIndirect(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.BufferHandle indirectBuffer, ulong indirectOffset, uint maxDrawCount, FFI.BufferHandle drawCountBuffer, ulong drawCountBufferOffset);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderPixelLocalStorageBarrier")]
    public static extern void RenderPassEncoderPixelLocalStorageBarrier(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderPopDebugGroup")]
    public static extern void RenderPassEncoderPopDebugGroup(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderPushDebugGroup")]
    public static extern void RenderPassEncoderPushDebugGroup(FFI.RenderPassEncoderHandle renderPassEncoder, byte* groupLabel);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderPushDebugGroup2")]
    public static extern void RenderPassEncoderPushDebugGroup2(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.StringViewFFI groupLabel);
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
    public static extern void RenderPassEncoderSetLabel(FFI.RenderPassEncoderHandle renderPassEncoder, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetLabel2")]
    public static extern void RenderPassEncoderSetLabel2(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.StringViewFFI label);
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
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderWriteTimestamp")]
    public static extern void RenderPassEncoderWriteTimestamp(FFI.RenderPassEncoderHandle renderPassEncoder, FFI.QuerySetHandle querySet, uint queryIndex);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderAddRef")]
    public static extern void RenderPassEncoderAddRef(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderRelease")]
    public static extern void RenderPassEncoderRelease(FFI.RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineGetBindGroupLayout")]
    public static extern FFI.BindGroupLayoutHandle RenderPipelineGetBindGroupLayout(FFI.RenderPipelineHandle renderPipeline, uint groupIndex);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineSetLabel")]
    public static extern void RenderPipelineSetLabel(FFI.RenderPipelineHandle renderPipeline, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineSetLabel2")]
    public static extern void RenderPipelineSetLabel2(FFI.RenderPipelineHandle renderPipeline, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineAddRef")]
    public static extern void RenderPipelineAddRef(FFI.RenderPipelineHandle renderPipeline);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineRelease")]
    public static extern void RenderPipelineRelease(FFI.RenderPipelineHandle renderPipeline);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSamplerSetLabel")]
    public static extern void SamplerSetLabel(FFI.SamplerHandle sampler, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSamplerSetLabel2")]
    public static extern void SamplerSetLabel2(FFI.SamplerHandle sampler, FFI.StringViewFFI label);
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
    public static extern void ShaderModuleGetCompilationInfo(FFI.ShaderModuleHandle shaderModule, delegate* unmanaged[Cdecl]<CompilationInfoRequestStatus, FFI.CompilationInfoFFI*, void*, void> callback, void* userdata);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleGetCompilationInfo2")]
    public static extern Future ShaderModuleGetCompilationInfo2(FFI.ShaderModuleHandle shaderModule, FFI.CompilationInfoCallbackInfo2FFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleGetCompilationInfoF")]
    public static extern Future ShaderModuleGetCompilationInfoF(FFI.ShaderModuleHandle shaderModule, FFI.CompilationInfoCallbackInfoFFI callbackInfo);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleSetLabel")]
    public static extern void ShaderModuleSetLabel(FFI.ShaderModuleHandle shaderModule, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleSetLabel2")]
    public static extern void ShaderModuleSetLabel2(FFI.ShaderModuleHandle shaderModule, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleAddRef")]
    public static extern void ShaderModuleAddRef(FFI.ShaderModuleHandle shaderModule);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleRelease")]
    public static extern void ShaderModuleRelease(FFI.ShaderModuleHandle shaderModule);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedBufferMemoryBeginAccess")]
    public static extern Status SharedBufferMemoryBeginAccess(FFI.SharedBufferMemoryHandle sharedBufferMemory, FFI.BufferHandle buffer, FFI.SharedBufferMemoryBeginAccessDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedBufferMemoryCreateBuffer")]
    public static extern FFI.BufferHandle SharedBufferMemoryCreateBuffer(FFI.SharedBufferMemoryHandle sharedBufferMemory, FFI.BufferDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedBufferMemoryEndAccess")]
    public static extern Status SharedBufferMemoryEndAccess(FFI.SharedBufferMemoryHandle sharedBufferMemory, FFI.BufferHandle buffer, FFI.SharedBufferMemoryEndAccessStateFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedBufferMemoryGetProperties")]
    public static extern Status SharedBufferMemoryGetProperties(FFI.SharedBufferMemoryHandle sharedBufferMemory, SharedBufferMemoryProperties* properties);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedBufferMemoryIsDeviceLost")]
    public static extern WebGPUBool SharedBufferMemoryIsDeviceLost(FFI.SharedBufferMemoryHandle sharedBufferMemory);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedBufferMemorySetLabel")]
    public static extern void SharedBufferMemorySetLabel(FFI.SharedBufferMemoryHandle sharedBufferMemory, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedBufferMemorySetLabel2")]
    public static extern void SharedBufferMemorySetLabel2(FFI.SharedBufferMemoryHandle sharedBufferMemory, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedBufferMemoryAddRef")]
    public static extern void SharedBufferMemoryAddRef(FFI.SharedBufferMemoryHandle sharedBufferMemory);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedBufferMemoryRelease")]
    public static extern void SharedBufferMemoryRelease(FFI.SharedBufferMemoryHandle sharedBufferMemory);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedFenceExportInfo")]
    public static extern void SharedFenceExportInfo(FFI.SharedFenceHandle sharedFence, SharedFenceExportInfo* info);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedFenceAddRef")]
    public static extern void SharedFenceAddRef(FFI.SharedFenceHandle sharedFence);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedFenceRelease")]
    public static extern void SharedFenceRelease(FFI.SharedFenceHandle sharedFence);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryBeginAccess")]
    public static extern Status SharedTextureMemoryBeginAccess(FFI.SharedTextureMemoryHandle sharedTextureMemory, FFI.TextureHandle texture, FFI.SharedTextureMemoryBeginAccessDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryCreateTexture")]
    public static extern FFI.TextureHandle SharedTextureMemoryCreateTexture(FFI.SharedTextureMemoryHandle sharedTextureMemory, FFI.TextureDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryEndAccess")]
    public static extern Status SharedTextureMemoryEndAccess(FFI.SharedTextureMemoryHandle sharedTextureMemory, FFI.TextureHandle texture, FFI.SharedTextureMemoryEndAccessStateFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryGetProperties")]
    public static extern Status SharedTextureMemoryGetProperties(FFI.SharedTextureMemoryHandle sharedTextureMemory, SharedTextureMemoryProperties* properties);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryIsDeviceLost")]
    public static extern WebGPUBool SharedTextureMemoryIsDeviceLost(FFI.SharedTextureMemoryHandle sharedTextureMemory);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemorySetLabel")]
    public static extern void SharedTextureMemorySetLabel(FFI.SharedTextureMemoryHandle sharedTextureMemory, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemorySetLabel2")]
    public static extern void SharedTextureMemorySetLabel2(FFI.SharedTextureMemoryHandle sharedTextureMemory, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryAddRef")]
    public static extern void SharedTextureMemoryAddRef(FFI.SharedTextureMemoryHandle sharedTextureMemory);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSharedTextureMemoryRelease")]
    public static extern void SharedTextureMemoryRelease(FFI.SharedTextureMemoryHandle sharedTextureMemory);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceConfigure")]
    public static extern void SurfaceConfigure(FFI.SurfaceHandle surface, FFI.SurfaceConfigurationFFI* config);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceGetCapabilities")]
    public static extern Status SurfaceGetCapabilities(FFI.SurfaceHandle surface, FFI.AdapterHandle adapter, FFI.SurfaceCapabilitiesFFI* capabilities);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceGetCurrentTexture")]
    public static extern void SurfaceGetCurrentTexture(FFI.SurfaceHandle surface, FFI.SurfaceTextureFFI* surfaceTexture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceGetPreferredFormat")]
    public static extern TextureFormat SurfaceGetPreferredFormat(FFI.SurfaceHandle surface, FFI.AdapterHandle adapter);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfacePresent")]
    public static extern void SurfacePresent(FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceSetLabel")]
    public static extern void SurfaceSetLabel(FFI.SurfaceHandle surface, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceSetLabel2")]
    public static extern void SurfaceSetLabel2(FFI.SurfaceHandle surface, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceUnconfigure")]
    public static extern void SurfaceUnconfigure(FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceAddRef")]
    public static extern void SurfaceAddRef(FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceRelease")]
    public static extern void SurfaceRelease(FFI.SurfaceHandle surface);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSwapChainGetCurrentTexture")]
    public static extern FFI.TextureHandle SwapChainGetCurrentTexture(FFI.SwapChainHandle swapChain);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSwapChainGetCurrentTextureView")]
    public static extern FFI.TextureViewHandle SwapChainGetCurrentTextureView(FFI.SwapChainHandle swapChain);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSwapChainPresent")]
    public static extern void SwapChainPresent(FFI.SwapChainHandle swapChain);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSwapChainAddRef")]
    public static extern void SwapChainAddRef(FFI.SwapChainHandle swapChain);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSwapChainRelease")]
    public static extern void SwapChainRelease(FFI.SwapChainHandle swapChain);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureCreateErrorView")]
    public static extern FFI.TextureViewHandle TextureCreateErrorView(FFI.TextureHandle texture, FFI.TextureViewDescriptorFFI* descriptor);
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
    public static extern void TextureSetLabel(FFI.TextureHandle texture, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureSetLabel2")]
    public static extern void TextureSetLabel2(FFI.TextureHandle texture, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureAddRef")]
    public static extern void TextureAddRef(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureRelease")]
    public static extern void TextureRelease(FFI.TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewSetLabel")]
    public static extern void TextureViewSetLabel(FFI.TextureViewHandle textureView, byte* label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewSetLabel2")]
    public static extern void TextureViewSetLabel2(FFI.TextureViewHandle textureView, FFI.StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewAddRef")]
    public static extern void TextureViewAddRef(FFI.TextureViewHandle textureView);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewRelease")]
    public static extern void TextureViewRelease(FFI.TextureViewHandle textureView);
}
