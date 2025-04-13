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

    /// <summary>
    /// Free members of a
    /// <see cref="AdapterInfoFFI" />
    /// structure.
    /// After calling this function, using the members will lead to undefined behavior.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterInfoFreeMembers")]
    public static extern void AdapterInfoFreeMembers(AdapterInfoFFI value);
    /// <summary>
    /// Create a new instance of the WebGPU API. This is the first step in using the API.
    /// The instance is used to create adapters, which are used to create devices.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCreateInstance")]
    public static extern InstanceHandle CreateInstance(InstanceDescriptor* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuGetInstanceCapabilities")]
    public static extern Status GetInstanceCapabilities(InstanceCapabilities* capabilities);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSupportedWGSLLanguageFeaturesFreeMembers")]
    public static extern void SupportedWGSLLanguageFeaturesFreeMembers(SupportedWGSLLanguageFeaturesFFI value);
    /// <summary>
    /// Free members of a
    /// <see cref="SupportedFeaturesFFI" />
    /// structure.
    /// After calling this function, using the members will lead to undefined behavior.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSupportedFeaturesFreeMembers")]
    public static extern void SupportedFeaturesFreeMembers(SupportedFeaturesFFI value);
    /// <summary>
    /// Free members of a
    /// <see cref="SurfaceCapabilitiesFFI" />
    /// structure.
    /// After calling this function, using the members will lead to undefined behavior.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceCapabilitiesFreeMembers")]
    public static extern void SurfaceCapabilitiesFreeMembers(SurfaceCapabilitiesFFI value);
    /// <summary>
    /// Get the features supported by the adapter.
    /// </summary>
    /// <param name="info">The features to fill in.</param>
    /// <returns>the status of the call.</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetFeatures")]
    public static extern void AdapterGetFeatures(AdapterHandle adapter, SupportedFeaturesFFI* features);
    /// <summary>
    /// Get info about the adapter itself.
    /// </summary>
    /// <param name="info">The info to fill in.</param>
    /// <returns>the status of the call.</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetInfo")]
    public static extern Status AdapterGetInfo(AdapterHandle adapter, AdapterInfoFFI* info);
    /// <summary>
    /// The best limits which can be used to create devices on this adapter.
    /// </summary>
    /// <param name="limits">The limits to fill in.</param>
    /// <returns>the status of the call.</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterGetLimits")]
    public static extern Status AdapterGetLimits(AdapterHandle adapter, SupportedLimits* limits);
    /// <summary>
    /// Check if and additional functionality is supported by the adapter.
    /// </summary>
    /// <param name="feature">The feature to check.</param>
    /// <returns>true if the feature is supported.</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterHasFeature")]
    public static extern WebGPUBool AdapterHasFeature(AdapterHandle adapter, FeatureName feature);
    /// <summary>
    /// Requests a device from the adapter.
    /// This is a one-time action: if a device is returned successfully,
    /// the adapter then enters a "consumed" state
    /// </summary>
    /// <param name="descriptor">The device descriptor to use.</param>
    /// <param name="callbackInfo">The callback to call when the device is ready</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterRequestDevice")]
    public static extern Future AdapterRequestDevice(AdapterHandle adapter, DeviceDescriptorFFI* options, RequestDeviceCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Increments the reference count of the <see cref="AdapterHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterAddRef")]
    public static extern void AdapterAddRef(AdapterHandle adapter);
    /// <summary>
    /// Decrements the reference count of the <see cref="AdapterHandle"/>. When the reference count reaches zero, the <see cref="AdapterHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="AdapterHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuAdapterRelease")]
    public static extern void AdapterRelease(AdapterHandle adapter);
    /// <summary>
    /// Set the label of the bind group.
    /// </summary>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupSetLabel")]
    public static extern void BindGroupSetLabel(BindGroupHandle bindGroup, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="BindGroupHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupAddRef")]
    public static extern void BindGroupAddRef(BindGroupHandle bindGroup);
    /// <summary>
    /// Decrements the reference count of the <see cref="BindGroupHandle"/>. When the reference count reaches zero, the <see cref="BindGroupHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="BindGroupHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupRelease")]
    public static extern void BindGroupRelease(BindGroupHandle bindGroup);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupLayoutSetLabel")]
    public static extern void BindGroupLayoutSetLabel(BindGroupLayoutHandle bindGroupLayout, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="BindGroupLayoutHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupLayoutAddRef")]
    public static extern void BindGroupLayoutAddRef(BindGroupLayoutHandle bindGroupLayout);
    /// <summary>
    /// Decrements the reference count of the <see cref="BindGroupLayoutHandle"/>. When the reference count reaches zero, the <see cref="BindGroupLayoutHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="BindGroupLayoutHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBindGroupLayoutRelease")]
    public static extern void BindGroupLayoutRelease(BindGroupLayoutHandle bindGroupLayout);
    /// <summary>
    /// Destroys the  <see cref="Buffer"/>.
    /// Note: It is valid to destroy a buffer multiple times.
    /// Note: Since no further operations can be enqueued using this buffer, implementations can
    /// free resource allocations, including mapped memory that was just unmapped.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferDestroy")]
    public static extern void BufferDestroy(BufferHandle buffer);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetConstMappedRange")]
    public static extern void* BufferGetConstMappedRange(BufferHandle buffer, nuint offset, nuint size);
    /// <summary>
    /// An enumerated value representing the mapped state of the Buffer.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetMapState")]
    public static extern BufferMapState BufferGetMapState(BufferHandle buffer);
    /// <summary>
    /// Returns an ArrayBuffer with the contents of the  <see cref="Buffer"/> in the given mapped range.
    /// </summary>
    /// <param name="offset">Offset in bytes into the buffer to return buffer contents from.</param>
    /// <param name="size">Size in bytes of the ArrayBuffer to return.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetMappedRange")]
    public static extern void* BufferGetMappedRange(BufferHandle buffer, nuint offset, nuint size);
    /// <summary>
    /// Returns the size of the buffer in bytes.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetSize")]
    public static extern ulong BufferGetSize(BufferHandle buffer);
    /// <summary>
    /// Returns the allowed usages of the Buffer
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferGetUsage")]
    public static extern BufferUsage BufferGetUsage(BufferHandle buffer);
    /// <summary>
    /// Maps the given range of the  <see cref="Buffer"/> and resolves the returned Promise when the
    ///  <see cref="Buffer"/>'s content is ready to be accessed with  <see cref="Buffer.GetMappedRange"/>.
    /// The resolution of the returned Promise **only** indicates that the buffer has been mapped.
    /// It does not guarantee the completion of any other operations visible to the content timeline,
    /// and in particular does not imply that any other Promise returned from
    ///  <see cref="Queue.OnSubmittedWorkDone"/> or  <see cref="Buffer.MapAsync"/> on other  <see cref="Buffer"/>s
    /// have resolved.
    /// The resolution of the Promise returned from  <see cref="Queue.OnSubmittedWorkDone"/>
    /// **does** imply the completion of
    ///  <see cref="Buffer.MapAsync"/> calls made prior to that call,
    /// on  <see cref="Buffer"/>s last used exclusively on that queue.
    /// </summary>
    /// <param name="mode">Whether the buffer should be mapped for reading or writing.</param>
    /// <param name="offset">Offset in bytes into the buffer to the start of the range to map.</param>
    /// <param name="size">Size in bytes of the range to map.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferMapAsync")]
    public static extern Future BufferMapAsync(BufferHandle buffer, MapMode mode, nuint offset, nuint size, BufferMapCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Sets a label on the Buffer.
    /// </summary>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferSetLabel")]
    public static extern void BufferSetLabel(BufferHandle buffer, StringViewFFI label);
    /// <summary>
    /// Unmaps the mapped range of the  <see cref="Buffer"/> and makes its contents available for use by the
    /// GPU again.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferUnmap")]
    public static extern void BufferUnmap(BufferHandle buffer);
    /// <summary>
    /// Increments the reference count of the <see cref="BufferHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferAddRef")]
    public static extern void BufferAddRef(BufferHandle buffer);
    /// <summary>
    /// Decrements the reference count of the <see cref="BufferHandle"/>. When the reference count reaches zero, the <see cref="BufferHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="BufferHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuBufferRelease")]
    public static extern void BufferRelease(BufferHandle buffer);
    /// <summary>
    /// Set debug label of this command buffer.
    /// </summary>
    /// <param name="label">The new label.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandBufferSetLabel")]
    public static extern void CommandBufferSetLabel(CommandBufferHandle commandBuffer, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="CommandBufferHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandBufferAddRef")]
    public static extern void CommandBufferAddRef(CommandBufferHandle commandBuffer);
    /// <summary>
    /// Decrements the reference count of the <see cref="CommandBufferHandle"/>. When the reference count reaches zero, the <see cref="CommandBufferHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="CommandBufferHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandBufferRelease")]
    public static extern void CommandBufferRelease(CommandBufferHandle commandBuffer);
    /// <summary>
    /// Begins encoding a compute pass described by descriptor.
    /// </summary>
    /// <param name="descriptor">The descriptor for the compute pass.</param>
    /// <returns>A ComputePassEncoder which encodes the compute pass.</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderBeginComputePass")]
    public static extern ComputePassEncoderHandle CommandEncoderBeginComputePass(CommandEncoderHandle commandEncoder, ComputePassDescriptorFFI* descriptor);
    /// <summary>
    /// Begins encoding a render pass described by <paramref name="descriptor"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="RenderPassEncoder"/> to create.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderBeginRenderPass")]
    public static extern RenderPassEncoderHandle CommandEncoderBeginRenderPass(CommandEncoderHandle commandEncoder, RenderPassDescriptorFFI* descriptor);
    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that fills a sub-region of a
    ///  <see cref="Buffer"/> with zeros.
    /// </summary>
    /// <param name="buffer">The  <see cref="Buffer"/> to clear.</param>
    /// <param name="offset">Offset in bytes into <paramref name="buffer"/> where the sub-region to clear begins.</param>
    /// <param name="size">Size in bytes of the sub-region to clear. Defaults to the size of the buffer minus <paramref name="offset"/>.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderClearBuffer")]
    public static extern void CommandEncoderClearBuffer(CommandEncoderHandle commandEncoder, BufferHandle buffer, ulong offset, ulong size);
    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that copies data from a sub-region of a
    ///  <see cref="Buffer"/> to a sub-region of another  <see cref="Buffer"/>.
    /// </summary>
    /// <param name="source">The  <see cref="Buffer"/> to copy from.</param>
    /// <param name="sourceOffset">Offset in bytes into <paramref name="source"/> to begin copying from.</param>
    /// <param name="destination">The  <see cref="Buffer"/> to copy to.</param>
    /// <param name="destinationOffset">Offset in bytes into <paramref name="destination"/> to place the copied data.</param>
    /// <param name="size">Bytes to copy.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyBufferToBuffer")]
    public static extern void CommandEncoderCopyBufferToBuffer(CommandEncoderHandle commandEncoder, BufferHandle source, ulong sourceOffset, BufferHandle destination, ulong destinationOffset, ulong size);
    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that copies data from a sub-region of a
    ///  <see cref="Buffer"/> to a sub-region of one or multiple continuous texture subresources.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source buffer.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination texture subresource.
    /// <paramref name="copySize"/>:
    /// </param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyBufferToTexture")]
    public static extern void CommandEncoderCopyBufferToTexture(CommandEncoderHandle commandEncoder, ImageCopyBufferFFI* source, ImageCopyTextureFFI* destination, Extent3D* copySize);
    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that copies data from a sub-region of one or
    /// multiple continuous texture subresources to a sub-region of a  <see cref="Buffer"/>.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source texture subresources.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination buffer.
    /// <paramref name="copySize"/>:
    /// </param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyTextureToBuffer")]
    public static extern void CommandEncoderCopyTextureToBuffer(CommandEncoderHandle commandEncoder, ImageCopyTextureFFI* source, ImageCopyBufferFFI* destination, Extent3D* copySize);
    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that copies data from a sub-region of one
    /// or multiple contiguous texture subresources to another sub-region of one or
    /// multiple continuous texture subresources.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source texture subresources.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination texture subresources.
    /// <paramref name="copySize"/>:
    /// </param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderCopyTextureToTexture")]
    public static extern void CommandEncoderCopyTextureToTexture(CommandEncoderHandle commandEncoder, ImageCopyTextureFFI* source, ImageCopyTextureFFI* destination, Extent3D* copySize);
    /// <summary>
    /// Completes recording of the commands sequence and returns a corresponding  <see cref="CommandBuffer"/>.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderFinish")]
    public static extern CommandBufferHandle CommandEncoderFinish(CommandEncoderHandle commandEncoder, CommandBufferDescriptorFFI* descriptor);
    /// <summary>
    /// Marks a point in a stream of commands with a label.
    /// </summary>
    /// <param name="markerLabel">The label to insert.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderInsertDebugMarker")]
    public static extern void CommandEncoderInsertDebugMarker(CommandEncoderHandle commandEncoder, StringViewFFI markerLabel);
    /// <summary>
    /// Ends the labeled debug group most recently started by <see cref="CommandEncoderHandle.PushDebugGroup">pushDebugGroup()</see>.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderPopDebugGroup")]
    public static extern void CommandEncoderPopDebugGroup(CommandEncoderHandle commandEncoder);
    /// <summary>
    /// Begins a labeled debug group containing subsequent commands.
    /// </summary>
    /// <param name="groupLabel">The label for the command group.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderPushDebugGroup")]
    public static extern void CommandEncoderPushDebugGroup(CommandEncoderHandle commandEncoder, StringViewFFI groupLabel);
    /// <summary>
    /// Resolves query results from a  <see cref="QuerySet"/> out into a range of a  <see cref="Buffer"/>.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderResolveQuerySet")]
    public static extern void CommandEncoderResolveQuerySet(CommandEncoderHandle commandEncoder, QuerySetHandle querySet, uint firstQuery, uint queryCount, BufferHandle destination, ulong destinationOffset);
    /// <summary>
    /// Set debug label of this command encoder.
    /// </summary>
    /// <param name="label">The new label.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderSetLabel")]
    public static extern void CommandEncoderSetLabel(CommandEncoderHandle commandEncoder, StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderWriteTimestamp")]
    [Obsolete("", false)]
    public static extern void CommandEncoderWriteTimestamp(CommandEncoderHandle commandEncoder, QuerySetHandle querySet, uint queryIndex);
    /// <summary>
    /// Increments the reference count of the <see cref="CommandEncoderHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderAddRef")]
    public static extern void CommandEncoderAddRef(CommandEncoderHandle commandEncoder);
    /// <summary>
    /// Decrements the reference count of the <see cref="CommandEncoderHandle"/>. When the reference count reaches zero, the <see cref="CommandEncoderHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="CommandEncoderHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuCommandEncoderRelease")]
    public static extern void CommandEncoderRelease(CommandEncoderHandle commandEncoder);
    /// <summary>
    /// Dispatch work to be performed with the current  <see cref="ComputePipeline"/>.
    /// See #computing-operations for the detailed specification.
    /// </summary>
    /// <param name="workgroupCountX">X dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountY">Y dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountZ">Z dimension of the grid of workgroups to dispatch.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderDispatchWorkgroups")]
    public static extern void ComputePassEncoderDispatchWorkgroups(ComputePassEncoderHandle computePassEncoder, uint workgroupCountX, uint workgroupCountY, uint workgroupCountZ);
    /// <summary>
    /// Dispatch work to be performed with the current  <see cref="ComputePipeline"/> using parameters read
    /// from a  <see cref="Buffer"/>.
    /// See #computing-operations for the detailed specification.
    /// packed block of **three 32-bit unsigned integer values (12 bytes total)**,
    /// given in the same order as the arguments for  <see cref="ComputePassEncoder.DispatchWorkgroups"/>.
    /// For example:
    /// </summary>
    /// <param name="indirectBuffer">Buffer containing the indirect dispatch parameters.</param>
    /// <param name="indirectOffset">Offset in bytes into <paramref name="indirectBuffer"/> where the dispatch data begins.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderDispatchWorkgroupsIndirect")]
    public static extern void ComputePassEncoderDispatchWorkgroupsIndirect(ComputePassEncoderHandle computePassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the compute pass commands sequence.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderEnd")]
    public static extern void ComputePassEncoderEnd(ComputePassEncoderHandle computePassEncoder);
    /// <summary>
    /// Marks a point in a stream of commands with a label.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderInsertDebugMarker")]
    public static extern void ComputePassEncoderInsertDebugMarker(ComputePassEncoderHandle computePassEncoder, StringViewFFI markerLabel);
    /// <summary>
    /// Ends the labeled debug group most recently started by <see cref="PushDebugGroup" />.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderPopDebugGroup")]
    public static extern void ComputePassEncoderPopDebugGroup(ComputePassEncoderHandle computePassEncoder);
    /// <summary>
    /// Begins a labeled debug group containing subsequent commands.
    /// </summary>
    /// <param name="groupLabel">The label to use for the debug group.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderPushDebugGroup")]
    public static extern void ComputePassEncoderPushDebugGroup(ComputePassEncoderHandle computePassEncoder, StringViewFFI groupLabel);
    /// <summary>
    /// Sets the current GPUBindGroup for the given index.
    /// </summary>
    /// <param name="index">The index to set the bind group at.</param>
    /// <param name="bindGroup">Bind group to use for subsequent render or compute commands.</param>
    /// <param name="dynamicOffsetCount">The number of dynamic offsets in the dynamicOffsets sequence.</param>
    /// <param name="dynamicOffsets">
    /// a sequence containing buffer offsets in bytes for each
    /// entry in bindGroup marked as Buffer.HasDynamicOffset, ordered by
    /// BindGroupLayoutEntry.Binding.
    /// </param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetBindGroup")]
    public static extern void ComputePassEncoderSetBindGroup(ComputePassEncoderHandle computePassEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    /// <summary>
    /// Set debug label of this command encoder.
    /// </summary>
    /// <param name="label">The new label.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetLabel")]
    public static extern void ComputePassEncoderSetLabel(ComputePassEncoderHandle computePassEncoder, StringViewFFI label);
    /// <summary>
    /// Sets the current  <see cref="ComputePipeline"/>.
    /// </summary>
    /// <param name="pipeline">The compute pipeline to use for subsequent dispatch commands.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderSetPipeline")]
    public static extern void ComputePassEncoderSetPipeline(ComputePassEncoderHandle computePassEncoder, ComputePipelineHandle pipeline);
    /// <summary>
    /// Increments the reference count of the <see cref="ComputePassEncoderHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderAddRef")]
    public static extern void ComputePassEncoderAddRef(ComputePassEncoderHandle computePassEncoder);
    /// <summary>
    /// Decrements the reference count of the <see cref="ComputePassEncoderHandle"/>. When the reference count reaches zero, the <see cref="ComputePassEncoderHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="ComputePassEncoderHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePassEncoderRelease")]
    public static extern void ComputePassEncoderRelease(ComputePassEncoderHandle computePassEncoder);
    /// <summary>
    /// Gets the bind group layout for the given group index.
    /// 
    /// If this pipeline was created with a default layout,
    /// then bind groups created with the returned BindGroupLayout can only be used with this pipeline.
    /// This method will raise a validation error if there is no bind group layout at index.
    /// </summary>
    /// <param name="groupIndex">Index into the pipeline layout's bindGroupLayouts sequence.</param>
    /// <returns>The bind group layout for the given group index.</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineGetBindGroupLayout")]
    public static extern BindGroupLayoutHandle ComputePipelineGetBindGroupLayout(ComputePipelineHandle computePipeline, uint groupIndex);
    /// <summary>
    /// Set debug label of this compute pipeline.
    /// </summary>
    /// <param name="label">The new label.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineSetLabel")]
    public static extern void ComputePipelineSetLabel(ComputePipelineHandle computePipeline, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="ComputePipelineHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineAddRef")]
    public static extern void ComputePipelineAddRef(ComputePipelineHandle computePipeline);
    /// <summary>
    /// Decrements the reference count of the <see cref="ComputePipelineHandle"/>. When the reference count reaches zero, the <see cref="ComputePipelineHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="ComputePipelineHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuComputePipelineRelease")]
    public static extern void ComputePipelineRelease(ComputePipelineHandle computePipeline);
    /// <summary>
    /// Creates a BindGroup.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the BindGroup</param>
    /// <returns>A new BindGroup</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateBindGroup")]
    public static extern BindGroupHandle DeviceCreateBindGroup(DeviceHandle device, BindGroupDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a BindGroupLayout.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the BindGroupLayout</param>
    /// <returns>A new BindGroupLayout</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateBindGroupLayout")]
    public static extern BindGroupLayoutHandle DeviceCreateBindGroupLayout(DeviceHandle device, BindGroupLayoutDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a Buffer.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the Buffer</param>
    /// <returns>A new Buffer</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateBuffer")]
    public static extern BufferHandle DeviceCreateBuffer(DeviceHandle device, BufferDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a CommandEncoder.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the CommandEncoder</param>
    /// <returns>A new CommandEncoder</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateCommandEncoder")]
    public static extern CommandEncoderHandle DeviceCreateCommandEncoder(DeviceHandle device, CommandEncoderDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a ComputePipeline using immediate pipeline creation.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the ComputePipeline</param>
    /// <returns>A new ComputePipeline</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateComputePipeline")]
    public static extern ComputePipelineHandle DeviceCreateComputePipeline(DeviceHandle device, ComputePipelineDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a GPUComputePipeline using async pipeline creation.
    /// The returned future resolves when the created pipeline is ready to be used without additional delay.
    /// </summary>
    /// <remarks">Use of this method is preferred whenever possible, as it prevents blocking the queue timeline work on pipeline compilation.</remarks>
    /// <param name="descriptor">The descriptor to use for the ComputePipeline</param>
    /// <param name="callbackInfo">The callbackInfo to use for the ComputePipeline</param>
    /// <returns>A future resolving when the pipeline is ready</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateComputePipelineAsync")]
    public static extern Future DeviceCreateComputePipelineAsync(DeviceHandle device, ComputePipelineDescriptorFFI* descriptor, CreateComputePipelineAsyncCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Creates a PipelineLayout.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreatePipelineLayout")]
    public static extern PipelineLayoutHandle DeviceCreatePipelineLayout(DeviceHandle device, PipelineLayoutDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a QuerySet.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the QuerySet</param>
    /// <returns>A new QuerySet</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateQuerySet")]
    public static extern QuerySetHandle DeviceCreateQuerySet(DeviceHandle device, QuerySetDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a RenderBundleEncoder.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the RenderBundleEncoder</param>
    /// <returns>A new RenderBundleEncoder</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderBundleEncoder")]
    public static extern RenderBundleEncoderHandle DeviceCreateRenderBundleEncoder(DeviceHandle device, RenderBundleEncoderDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a GPURenderPipeline using immediate pipeline creation.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the RenderPipeline</param>
    /// <returns>A new RenderPipeline</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderPipeline")]
    public static extern RenderPipelineHandle DeviceCreateRenderPipeline(DeviceHandle device, RenderPipelineDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a GPURenderPipeline using async pipeline creation.
    /// The returned future resolves when the created pipeline is ready to be used without additional delay.
    /// </summary>
    /// <remarks">Use of this method is preferred whenever possible, as it prevents blocking the queue timeline work on pipeline compilation.</remarks>
    /// <param name="descriptor">The descriptor to use for the RenderPipeline</param>
    /// <param name="callbackInfo">The callbackInfo to use for the RenderPipeline</param>
    /// <returns>A future resolving when the pipeline is ready</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateRenderPipelineAsync")]
    public static extern Future DeviceCreateRenderPipelineAsync(DeviceHandle device, RenderPipelineDescriptorFFI* descriptor, CreateRenderPipelineAsyncCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Creates a Sampler.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the Sampler</param>
    /// <returns>A new Sampler</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateSampler")]
    public static extern SamplerHandle DeviceCreateSampler(DeviceHandle device, SamplerDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a ShaderModule.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the ShaderModule</param>
    /// <returns>A new ShaderModule</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateShaderModule")]
    public static extern ShaderModuleHandle DeviceCreateShaderModule(DeviceHandle device, ShaderModuleDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a Texture.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the Texture</param>
    /// <returns>A new Texture</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceCreateTexture")]
    public static extern TextureHandle DeviceCreateTexture(DeviceHandle device, TextureDescriptorFFI* descriptor);
    /// <summary>
    /// Destroys the device, preventing further operations on it. Outstanding asynchronous operations will fail.
    /// </summary>
    /// <remarks">It is valid to destroy a device multiple times.</remarks>
    /// <returns>A future resolving when the device is destroyed</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceDestroy")]
    public static extern void DeviceDestroy(DeviceHandle device);
    /// <summary>
    /// Information about the physical adapter which created the device that this GPUDevice refers to.
    /// 
    /// For a given GPUDevice, the GPUAdapterInfo values exposed are constant over time.
    /// </summary>
    /// <param name="adapterInfo">The adapterInfo to insert the adapter info into</param>
    /// <returns>the status of the operation</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetAdapterInfo")]
    public static extern Status DeviceGetAdapterInfo(DeviceHandle device, AdapterInfoFFI* adapterInfo);
    /// <summary>
    /// Get the features supported by the device
    /// </summary>
    /// <param name="features">an pointer to a SupportedFeaturesFFI to insert the supported features into</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetFeatures")]
    public static extern void DeviceGetFeatures(DeviceHandle device, SupportedFeaturesFFI* features);
    /// <summary>
    /// Get the limits which can be used on this device.
    /// No better limits can be used, even if the underlying adapter can support them.
    /// </summary>
    /// <param name="limits">an pointer to a SupportedLimits to insert the limits into</param>
    /// <returns>Return status of the operation</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetLimits")]
    public static extern Status DeviceGetLimits(DeviceHandle device, SupportedLimits* limits);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetLostFuture")]
    public static extern Future DeviceGetLostFuture(DeviceHandle device);
    /// <summary>
    /// Get the primary Queue for this device.
    /// </summary>
    /// <param name="queue">Get the queue to insert command into</param>
    /// <returns>the queue</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceGetQueue")]
    public static extern QueueHandle DeviceGetQueue(DeviceHandle device);
    /// <summary>
    /// Check if the feature is supported
    /// </summary>
    /// <param name="feature">The feature to check</param>
    /// <returns>true if the feature is supported false otherwise</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceHasFeature")]
    public static extern WebGPUBool DeviceHasFeature(DeviceHandle device, FeatureName feature);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDevicePopErrorScope")]
    public static extern Future DevicePopErrorScope(DeviceHandle device, PopErrorScopeCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Pushes a new error scope onto the errorScopeStack for this device
    /// </summary>
    /// <param name="filter">Which class of errors this error scope observes</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDevicePushErrorScope")]
    public static extern void DevicePushErrorScope(DeviceHandle device, ErrorFilter filter);
    /// <summary>
    /// Set debug label of this device
    /// </summary>
    /// <param name="label">The label to set</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceSetLabel")]
    public static extern void DeviceSetLabel(DeviceHandle device, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="DeviceHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceAddRef")]
    public static extern void DeviceAddRef(DeviceHandle device);
    /// <summary>
    /// Decrements the reference count of the <see cref="DeviceHandle"/>. When the reference count reaches zero, the <see cref="DeviceHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="DeviceHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuDeviceRelease")]
    public static extern void DeviceRelease(DeviceHandle device);
    /// <summary>
    /// Creates a new surface targeting a given window/canvas/surface/etc..
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceCreateSurface")]
    public static extern SurfaceHandle InstanceCreateSurface(InstanceHandle instance, SurfaceDescriptorFFI* descriptor);
    /// <summary>
    /// Returns set of supported WGSL language extensions supported by this instance.
    /// </summary>
    /// <param name="features">A pointer to struct to fill with supported extension</param>
    /// <returns>The status of the operation</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceGetWGSLLanguageFeatures")]
    public static extern Status InstanceGetWGSLLanguageFeatures(InstanceHandle instance, SupportedWGSLLanguageFeaturesFFI* features);
    /// <summary>
    /// check if a WGSL language extensions is supported by this instance.
    /// </summary>
    /// <returns>true if the feature is supported, false otherwise.</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceHasWGSLLanguageFeature")]
    public static extern WebGPUBool InstanceHasWGSLLanguageFeature(InstanceHandle instance, WGSLLanguageFeatureName feature);
    /// <summary>
    /// Processes asynchronous events on this `Instance`, calling any callbacks for asynchronous operations created with <see cref="CallbackMode.AllowProcessEvents" />.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceProcessEvents")]
    public static extern void InstanceProcessEvents(InstanceHandle instance);
    /// <summary>
    /// Retrieves an Adapter which matches the given <see cref="RequestAdapterOptionsFFI" />.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceRequestAdapter")]
    public static extern Future InstanceRequestAdapter(InstanceHandle instance, RequestAdapterOptionsFFI* options, RequestAdapterCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Wait for at least one Future in `futures` to complete, and call callbacks of the respective completed asynchronous operations.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceWaitAny")]
    public static extern WaitStatus InstanceWaitAny(InstanceHandle instance, nuint futureCount, FutureWaitInfo* futures, ulong timeoutNS);
    /// <summary>
    /// Increments the reference count of the <see cref="InstanceHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceAddRef")]
    public static extern void InstanceAddRef(InstanceHandle instance);
    /// <summary>
    /// Decrements the reference count of the <see cref="InstanceHandle"/>. When the reference count reaches zero, the <see cref="InstanceHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="InstanceHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuInstanceRelease")]
    public static extern void InstanceRelease(InstanceHandle instance);
    /// <summary>
    /// Sets the label of the pipeline layout.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuPipelineLayoutSetLabel")]
    public static extern void PipelineLayoutSetLabel(PipelineLayoutHandle pipelineLayout, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="PipelineLayoutHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuPipelineLayoutAddRef")]
    public static extern void PipelineLayoutAddRef(PipelineLayoutHandle pipelineLayout);
    /// <summary>
    /// Decrements the reference count of the <see cref="PipelineLayoutHandle"/>. When the reference count reaches zero, the <see cref="PipelineLayoutHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="PipelineLayoutHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuPipelineLayoutRelease")]
    public static extern void PipelineLayoutRelease(PipelineLayoutHandle pipelineLayout);
    /// <summary>
    /// Destroys the  <see cref="QuerySet"/>.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetDestroy")]
    public static extern void QuerySetDestroy(QuerySetHandle querySet);
    /// <summary>
    /// Gets the number of queries managed by this QuerySet.
    /// </summary>
    /// <returns>number of queries managed by this QuerySet.</returns>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetGetCount")]
    public static extern uint QuerySetGetCount(QuerySetHandle querySet);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetGetType")]
    public static extern QueryType QuerySetGetType(QuerySetHandle querySet);
    /// <summary>
    /// Sets a label on the QuerySet.
    /// </summary>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetSetLabel")]
    public static extern void QuerySetSetLabel(QuerySetHandle querySet, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="QuerySetHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetAddRef")]
    public static extern void QuerySetAddRef(QuerySetHandle querySet);
    /// <summary>
    /// Decrements the reference count of the <see cref="QuerySetHandle"/>. When the reference count reaches zero, the <see cref="QuerySetHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="QuerySetHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQuerySetRelease")]
    public static extern void QuerySetRelease(QuerySetHandle querySet);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueOnSubmittedWorkDone")]
    public static extern Future QueueOnSubmittedWorkDone(QueueHandle queue, QueueWorkDoneCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Sets a label on the queue.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueSetLabel")]
    public static extern void QueueSetLabel(QueueHandle queue, StringViewFFI label);
    /// <summary>
    /// Schedules the execution of the command buffers by the GPU on this queue.
    /// Submitted command buffers cannot be used again.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueSubmit")]
    public static extern void QueueSubmit(QueueHandle queue, nuint commandCount, CommandBufferHandle* commands);
    /// <summary>
    /// Issues a write operation of the provided data into a  <see cref="Buffer"/>.
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
    public static extern void QueueWriteBuffer(QueueHandle queue, BufferHandle buffer, ulong bufferOffset, void* data, nuint size);
    /// <summary>
    /// Issues a write operation of the provided data into a  <see cref="Texture"/>.
    /// </summary>
    /// <param name="destination">The texture subresource and origin to write to.</param>
    /// <param name="data">Data to write into <paramref name="destination"/>.</param>
    /// <param name="dataLayout">Layout of the content in <paramref name="data"/>.</param>
    /// <param name="size">Extents of the content to write from <paramref name="data"/> to <paramref name="destination"/>.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueWriteTexture")]
    public static extern void QueueWriteTexture(QueueHandle queue, ImageCopyTextureFFI* destination, void* data, nuint dataSize, TextureDataLayout* dataLayout, Extent3D* writeSize);
    /// <summary>
    /// Increments the reference count of the <see cref="QueueHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueAddRef")]
    public static extern void QueueAddRef(QueueHandle queue);
    /// <summary>
    /// Decrements the reference count of the <see cref="QueueHandle"/>. When the reference count reaches zero, the <see cref="QueueHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="QueueHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuQueueRelease")]
    public static extern void QueueRelease(QueueHandle queue);
    /// <summary>
    /// Sets the debug label of the RenderBundleHandle.
    /// </summary>
    /// <param name="label">The new debug label to set.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleSetLabel")]
    public static extern void RenderBundleSetLabel(RenderBundleHandle renderBundle, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="RenderBundleHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleAddRef")]
    public static extern void RenderBundleAddRef(RenderBundleHandle renderBundle);
    /// <summary>
    /// Decrements the reference count of the <see cref="RenderBundleHandle"/>. When the reference count reaches zero, the <see cref="RenderBundleHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="RenderBundleHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleRelease")]
    public static extern void RenderBundleRelease(RenderBundleHandle renderBundle);
    /// <summary>
    /// Draws primitives from the active vertex buffer(s).
    /// 
    /// The active vertex buffers can be set with <see cref="RenderBundleEncoderHandle.SetVertexBuffer"></see>.
    /// Does not use an Index Buffer.
    /// If you need this see <see cref="RenderBundleEncoderHandle.DrawIndexed"></see>.
    /// 
    /// Errors if vertices Range is outside of the range of the vertices range of any set vertex buffer.
    /// </summary>
    /// <param name="firstVertex">The index of the first vertex to draw.</param>
    /// <param name="firstInstance">The index of the first instance to draw.</param>
    /// <param name="instanceCount">The number of instances to draw.</param>
    /// <param name="vertexCount">The number of vertices to draw.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDraw")]
    public static extern void RenderBundleEncoderDraw(RenderBundleEncoderHandle renderBundleEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);
    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffer(s).
    /// 
    /// The active index buffer can be set with <see cref="RenderBundleEncoderHandle.SetIndexBuffer" />.
    /// The active vertex buffer(s) can be set with <see cref="RenderBundleEncoderHandle.SetVertexBuffer" />.
    /// 
    /// Errors if indices Range is outside of the range of the indices range of any set index buffer.
    /// </summary>
    /// <param name="indexCount">The number of indices to draw.</param>
    /// <param name="instanceCount">The number of instances to draw.</param>
    /// <param name="firstIndex">The index of the first index to draw.</param>
    /// <param name="baseVertex">The value added to the vertex index before indexing into the vertex buffer.</param>
    /// <param name="firstInstance">The index of the first instance to draw.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDrawIndexed")]
    public static extern void RenderBundleEncoderDrawIndexed(RenderBundleEncoderHandle renderBundleEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);
    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffers, based on the contents of the indirectBuffer.
    /// 
    /// The active index buffer can be set with RenderBundleEncoder.SetIndexBuffer, while the active vertex buffers can be set with RenderBundleEncoder.SetVertexBuffer.
    /// </summary>
    /// <param name="indirectBuffer">Buffer containing the indirect drawIndexed parameters.</param>
    /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDrawIndexedIndirect")]
    public static extern void RenderBundleEncoderDrawIndexedIndirect(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Draws primitives from the active vertex buffer(s) based on the contents of the indirectBuffer.
    /// 
    /// The active vertex buffers can be set with <see cref="RenderBundleEncoderHandle.SetVertexBuffer" />.
    /// </summary>
    /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
    /// <param name="indirectBuffer">Buffer containing the indirect drawIndexed parameters.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderDrawIndirect")]
    public static extern void RenderBundleEncoderDrawIndirect(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the render bundle commands sequence.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderFinish")]
    public static extern RenderBundleHandle RenderBundleEncoderFinish(RenderBundleEncoderHandle renderBundleEncoder, RenderBundleDescriptorFFI* descriptor);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderInsertDebugMarker")]
    public static extern void RenderBundleEncoderInsertDebugMarker(RenderBundleEncoderHandle renderBundleEncoder, StringViewFFI markerLabel);
    /// <summary>
    /// Stops command recording and creates debug group.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderPopDebugGroup")]
    public static extern void RenderBundleEncoderPopDebugGroup(RenderBundleEncoderHandle renderBundleEncoder);
    /// <summary>
    /// Start record commands and group it into debug marker group.
    /// </summary>
    /// <param name="groupLabel">The label of the debug marker group.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderPushDebugGroup")]
    public static extern void RenderBundleEncoderPushDebugGroup(RenderBundleEncoderHandle renderBundleEncoder, StringViewFFI groupLabel);
    /// <summary>
    /// Sets the active bind group for a given bind group index.
    /// The bind group layout in the active pipeline when any Draw() function is called must match the layout of this bind group.
    /// 
    /// If the bind group have dynamic offsets, provide them in the binding order.
    /// </summary>
    /// <param name="groupIndex">The index to set the bind group at.</param>
    /// <param name="group">Bind group to use for subsequent render or compute commands.</param>
    /// <param name="dynamicOffsetCount">The number of offsets in dynamicOffsets.</param>
    /// <param name="dynamicOffsets">A square containing buffer offsets in bytes for each entry in bindGroup marked as buffer.HasDynamicOffset, ordered by BindGroupLayoutEntry.Binding.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetBindGroup")]
    public static extern void RenderBundleEncoderSetBindGroup(RenderBundleEncoderHandle renderBundleEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    /// <summary>
    /// Sets the active index buffer.
    /// 
    /// Subsequent calls to DrawIndexed on this RenderBundleEncoderHandle will use buffer as the source index buffer.
    /// </summary>
    /// <param name="buffer">The index buffer to use.</param>
    /// <param name="format">The format of the index buffer.</param>
    /// <param name="offset">The offset in bytes from the start of the buffer to the first index.</param>
    /// <param name="size">The size in bytes of the index buffer.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetIndexBuffer")]
    public static extern void RenderBundleEncoderSetIndexBuffer(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle buffer, IndexFormat format, ulong offset, ulong size);
    /// <summary>
    /// Sets the debug label of the RenderBundleEncoderHandle.
    /// </summary>
    /// <param name="label">The new debug label to set.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetLabel")]
    public static extern void RenderBundleEncoderSetLabel(RenderBundleEncoderHandle renderBundleEncoder, StringViewFFI label);
    /// <summary>
    /// Sets the current RenderPipeline.
    /// </summary>
    /// <param name="pipeline">The render pipeline to use for subsequent drawing commands.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetPipeline")]
    public static extern void RenderBundleEncoderSetPipeline(RenderBundleEncoderHandle renderBundleEncoder, RenderPipelineHandle pipeline);
    /// <summary>
    /// Assign a vertex buffer to a slot.
    /// 
    /// Subsequent calls to draw and draw_indexed on this RenderBundleEncoderHandle will use buffer as one of the source vertex buffers.
    /// 
    /// The slot refers to the index of the matching descriptor in VertexState.Buffers.
    /// </summary>
    /// <param name="slot">The vertex buffer slot to set the vertex buffer for.</param>
    /// <param name="buffer">Buffer containing vertex data to use for subsequent drawing commands.</param>
    /// <param name="offset">Offset in bytes into buffer where the vertex data begins.</param>
    /// <param name="size">Size in bytes of the vertex data in buffer. Defaults to the size of the buffer minus the offset.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderSetVertexBuffer")]
    public static extern void RenderBundleEncoderSetVertexBuffer(RenderBundleEncoderHandle renderBundleEncoder, uint slot, BufferHandle buffer, ulong offset, ulong size);
    /// <summary>
    /// Increments the reference count of the <see cref="RenderBundleEncoderHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderAddRef")]
    public static extern void RenderBundleEncoderAddRef(RenderBundleEncoderHandle renderBundleEncoder);
    /// <summary>
    /// Decrements the reference count of the <see cref="RenderBundleEncoderHandle"/>. When the reference count reaches zero, the <see cref="RenderBundleEncoderHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="RenderBundleEncoderHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderBundleEncoderRelease")]
    public static extern void RenderBundleEncoderRelease(RenderBundleEncoderHandle renderBundleEncoder);
    /// <param name="queryIndex">The index of the query in the query set.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderBeginOcclusionQuery")]
    public static extern void RenderPassEncoderBeginOcclusionQuery(RenderPassEncoderHandle renderPassEncoder, uint queryIndex);
    /// <summary>
    /// Draws primitives from the active vertex buffer(s).
    /// 
    /// The active vertex buffer(s) can be set with <see cref="SetVertexBuffer" />. Does not use an Index Buffer. If you need this see <see cref="DrawIndexed" />.
    /// 
    /// Errors if vertices Range is outside of the range of the vertices range of any set vertex buffer.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDraw")]
    public static extern void RenderPassEncoderDraw(RenderPassEncoderHandle renderPassEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);
    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffers.
    /// 
    /// The active index buffer can be set with <see cref="SetIndexBuffer" /> The active vertex buffers can be set with <see cref="SetVertexBuffer" />.
    /// 
    /// Errors if indices Range is outside of the range of the indices range of any set index buffer.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDrawIndexed")]
    public static extern void RenderPassEncoderDrawIndexed(RenderPassEncoderHandle renderPassEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);
    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffers, based on the contents of the indirectBuffer.
    /// 
    /// This is like calling <see cref="DrawIndexed" /> but the contents of the call are specified in the indirectBuffer.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDrawIndexedIndirect")]
    public static extern void RenderPassEncoderDrawIndexedIndirect(RenderPassEncoderHandle renderPassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderDrawIndirect")]
    public static extern void RenderPassEncoderDrawIndirect(RenderPassEncoderHandle renderPassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the render pass commands sequence.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderEnd")]
    public static extern void RenderPassEncoderEnd(RenderPassEncoderHandle renderPassEncoder);
    /// <summary>
    /// End the occlusion query on this render pass. It can be started with <see cref="BeginOcclusionQuery" />. Occlusion queries may not be nested.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderEndOcclusionQuery")]
    public static extern void RenderPassEncoderEndOcclusionQuery(RenderPassEncoderHandle renderPassEncoder);
    /// <summary>
    /// Executes the commands previously recorded into the given  <see cref="RenderBundle"/>s as part of
    /// this render pass.
    /// When a  <see cref="RenderBundle"/> is executed, it does not inherit the render pass's pipeline, bind
    /// groups, or vertex and index buffers. After a  <see cref="RenderBundle"/> has executed, the render
    /// pass's pipeline, bind group, and vertex/index buffer state is cleared
    /// (to the initial, empty values).
    /// Note: The state is cleared, not restored to the previous state.
    /// This occurs even if zero  <see cref="RenderBundle">GPURenderBundles</see> are executed.
    /// </summary>
    /// <param name="bundles">List of render bundles to execute.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderExecuteBundles")]
    public static extern void RenderPassEncoderExecuteBundles(RenderPassEncoderHandle renderPassEncoder, nuint bundleCount, RenderBundleHandle* bundles);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderInsertDebugMarker")]
    public static extern void RenderPassEncoderInsertDebugMarker(RenderPassEncoderHandle renderPassEncoder, StringViewFFI markerLabel);
    /// <summary>
    /// Stops command recording and creates debug group.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderPopDebugGroup")]
    public static extern void RenderPassEncoderPopDebugGroup(RenderPassEncoderHandle renderPassEncoder);
    /// <summary>
    /// Start record commands and group it into debug marker group.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderPushDebugGroup")]
    public static extern void RenderPassEncoderPushDebugGroup(RenderPassEncoderHandle renderPassEncoder, StringViewFFI groupLabel);
    /// <summary>
    /// Sets the active bind group for a given bind group index. The bind group layout in the active pipeline when any Draw*() method is called must match the layout of this bind group.
    /// 
    /// If the bind group have dynamic offsets, provide them in binding order. These offsets have to be aligned to Limits.MinUniformBufferOffsetAlignment or Limits.MinStorageBufferOffsetAlignment appropriately.
    /// 
    /// Subsequent draw calls' shader executions will be able to access data in these bind groups.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetBindGroup")]
    public static extern void RenderPassEncoderSetBindGroup(RenderPassEncoderHandle renderPassEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    /// <summary>
    /// Sets the constant blend color and alpha values used with  <see cref="BlendFactor.Constant"/>
    /// and  <see cref="BlendFactor.One-minus-constant"/>  <see cref="BlendFactor"/>s.
    /// </summary>
    /// <param name="color">The color to use when blending.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetBlendConstant")]
    public static extern void RenderPassEncoderSetBlendConstant(RenderPassEncoderHandle renderPassEncoder, Color* color);
    /// <summary>
    /// Sets the active index buffer.
    /// 
    /// Subsequent calls to <see cref="DrawIndexed" /> on this RenderPassEncoderHandle will use buffer as the source index buffer.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetIndexBuffer")]
    public static extern void RenderPassEncoderSetIndexBuffer(RenderPassEncoderHandle renderPassEncoder, BufferHandle buffer, IndexFormat format, ulong offset, ulong size);
    /// <summary>
    /// Sets the debug label of the RenderPassEncoderHandle.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetLabel")]
    public static extern void RenderPassEncoderSetLabel(RenderPassEncoderHandle renderPassEncoder, StringViewFFI label);
    /// <summary>
    /// Sets the active render pipeline.
    /// 
    /// Subsequent draw calls will exhibit the behavior defined by pipeline.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetPipeline")]
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
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetScissorRect")]
    public static extern void RenderPassEncoderSetScissorRect(RenderPassEncoderHandle renderPassEncoder, uint x, uint y, uint width, uint height);
    /// <summary>
    /// Sets the {{RenderState/stencilReference}} value used during stencil tests with
    /// the  <see cref="StencilOperation.Replace"/>  <see cref="StencilOperation"/>.
    /// </summary>
    /// <param name="reference">The new stencil reference value.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetStencilReference")]
    public static extern void RenderPassEncoderSetStencilReference(RenderPassEncoderHandle renderPassEncoder, uint reference);
    /// <summary>
    /// Assign a vertex buffer to a slot.
    /// 
    /// Subsequent calls to draw and draw_indexed on this RenderPass will use buffer as one of the source vertex buffers.
    /// 
    /// The slot refers to the index of the matching descriptor in VertexState.Buffers.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetVertexBuffer")]
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
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderSetViewport")]
    public static extern void RenderPassEncoderSetViewport(RenderPassEncoderHandle renderPassEncoder, float x, float y, float width, float height, float minDepth, float maxDepth);
    /// <summary>
    /// Increments the reference count of the <see cref="RenderPassEncoderHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderAddRef")]
    public static extern void RenderPassEncoderAddRef(RenderPassEncoderHandle renderPassEncoder);
    /// <summary>
    /// Decrements the reference count of the <see cref="RenderPassEncoderHandle"/>. When the reference count reaches zero, the <see cref="RenderPassEncoderHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="RenderPassEncoderHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPassEncoderRelease")]
    public static extern void RenderPassEncoderRelease(RenderPassEncoderHandle renderPassEncoder);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineGetBindGroupLayout")]
    public static extern BindGroupLayoutHandle RenderPipelineGetBindGroupLayout(RenderPipelineHandle renderPipeline, uint groupIndex);
    /// <summary>
    /// Set the debug label of this RenderPipelineHandle.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineSetLabel")]
    public static extern void RenderPipelineSetLabel(RenderPipelineHandle renderPipeline, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="RenderPipelineHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineAddRef")]
    public static extern void RenderPipelineAddRef(RenderPipelineHandle renderPipeline);
    /// <summary>
    /// Decrements the reference count of the <see cref="RenderPipelineHandle"/>. When the reference count reaches zero, the <see cref="RenderPipelineHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="RenderPipelineHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuRenderPipelineRelease")]
    public static extern void RenderPipelineRelease(RenderPipelineHandle renderPipeline);
    /// <summary>
    /// Set the label of the sampler.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSamplerSetLabel")]
    public static extern void SamplerSetLabel(SamplerHandle sampler, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="SamplerHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSamplerAddRef")]
    public static extern void SamplerAddRef(SamplerHandle sampler);
    /// <summary>
    /// Decrements the reference count of the <see cref="SamplerHandle"/>. When the reference count reaches zero, the <see cref="SamplerHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="SamplerHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSamplerRelease")]
    public static extern void SamplerRelease(SamplerHandle sampler);
    /// <summary>
    /// Returns any messages generated during the <see cref="ShaderModule" />'s compilation.
    /// The locations, order, and contents of messages are implementation-defined
    /// In particular, messages may not be ordered by <see cref="CompilationMessage.LineNum" />.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleGetCompilationInfo")]
    public static extern Future ShaderModuleGetCompilationInfo(ShaderModuleHandle shaderModule, CompilationInfoCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Sets the debug label of the shader module.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleSetLabel")]
    public static extern void ShaderModuleSetLabel(ShaderModuleHandle shaderModule, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="ShaderModuleHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleAddRef")]
    public static extern void ShaderModuleAddRef(ShaderModuleHandle shaderModule);
    /// <summary>
    /// Decrements the reference count of the <see cref="ShaderModuleHandle"/>. When the reference count reaches zero, the <see cref="ShaderModuleHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="ShaderModuleHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuShaderModuleRelease")]
    public static extern void ShaderModuleRelease(ShaderModuleHandle shaderModule);
    /// <summary>
    /// Configures the surface.
    /// </summary>
    /// <param name="config">The configuration to use.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceConfigure")]
    public static extern void SurfaceConfigure(SurfaceHandle surface, SurfaceConfigurationFFI* config);
    /// <summary>
    /// Returns the capabilities of the surface when used with the given adapter.
    /// 
    /// Returns specified values (see SurfaceCapabilities) if surface is incompatible with the adapter.
    /// </summary>
    /// <param name="adapter">The adapter to use.</param>
    /// <param name="capabilities">The capabilities of the surface.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceGetCapabilities")]
    public static extern Status SurfaceGetCapabilities(SurfaceHandle surface, AdapterHandle adapter, SurfaceCapabilitiesFFI* capabilities);
    /// <summary>
    /// Gets the current texture of the surface.
    /// </summary>
    /// <param name="surfaceTexture">The current texture of the surface.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceGetCurrentTexture")]
    public static extern void SurfaceGetCurrentTexture(SurfaceHandle surface, SurfaceTextureFFI* surfaceTexture);
    /// <summary>
    /// Presents the surface.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfacePresent")]
    public static extern void SurfacePresent(SurfaceHandle surface);
    /// <summary>
    /// Sets the label of the surface.
    /// </summary>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceSetLabel")]
    public static extern void SurfaceSetLabel(SurfaceHandle surface, StringViewFFI label);
    /// <summary>
    /// Unconfigures the surface.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceUnconfigure")]
    public static extern void SurfaceUnconfigure(SurfaceHandle surface);
    /// <summary>
    /// Increments the reference count of the <see cref="SurfaceHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceAddRef")]
    public static extern void SurfaceAddRef(SurfaceHandle surface);
    /// <summary>
    /// Decrements the reference count of the <see cref="SurfaceHandle"/>. When the reference count reaches zero, the <see cref="SurfaceHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="SurfaceHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuSurfaceRelease")]
    public static extern void SurfaceRelease(SurfaceHandle surface);
    /// <summary>
    /// Creates a  <see cref="TextureView"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="TextureView"/> to create.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureCreateView")]
    public static extern TextureViewHandle TextureCreateView(TextureHandle texture, TextureViewDescriptorFFI* descriptor);
    /// <summary>
    /// Destroys the  <see cref="Texture"/>.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureDestroy")]
    public static extern void TextureDestroy(TextureHandle texture);
    /// <summary>
    /// Returns the depth or layer count of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Size.DepthOrArrayLayers" /> that was specified when creating the texture.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetDepthOrArrayLayers")]
    public static extern uint TextureGetDepthOrArrayLayers(TextureHandle texture);
    /// <summary>
    /// Returns the dimension of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Dimension" /> that was specified when creating the texture.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetDimension")]
    public static extern TextureDimension TextureGetDimension(TextureHandle texture);
    /// <summary>
    /// Returns the format of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Format" /> that was specified when creating the texture.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetFormat")]
    public static extern TextureFormat TextureGetFormat(TextureHandle texture);
    /// <summary>
    /// Returns the height of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Size.Height" /> that was specified when creating the texture.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetHeight")]
    public static extern uint TextureGetHeight(TextureHandle texture);
    /// <summary>
    /// Returns the number of mip levels in the texture.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetMipLevelCount")]
    public static extern uint TextureGetMipLevelCount(TextureHandle texture);
    /// <summary>
    /// Returns the number of samples in the texture.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetSampleCount")]
    public static extern uint TextureGetSampleCount(TextureHandle texture);
    /// <summary>
    /// Returns the allowed usages of this Texture.
    /// 
    /// This is always equal to the usage that was specified when creating the texture.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetUsage")]
    public static extern TextureUsage TextureGetUsage(TextureHandle texture);
    /// <summary>
    /// Returns the width of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Size.Width" /> that was specified when creating the texture.
    /// </summary>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureGetWidth")]
    public static extern uint TextureGetWidth(TextureHandle texture);
    /// <summary>
    /// Sets the debug label of texture.
    /// </summary>
    /// <param name="label">The new label.</param>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureSetLabel")]
    public static extern void TextureSetLabel(TextureHandle texture, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="TextureHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureAddRef")]
    public static extern void TextureAddRef(TextureHandle texture);
    /// <summary>
    /// Decrements the reference count of the <see cref="TextureHandle"/>. When the reference count reaches zero, the <see cref="TextureHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="TextureHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureRelease")]
    public static extern void TextureRelease(TextureHandle texture);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewSetLabel")]
    public static extern void TextureViewSetLabel(TextureViewHandle textureView, StringViewFFI label);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewAddRef")]
    public static extern void TextureViewAddRef(TextureViewHandle textureView);
    [DllImport("webgpu_dawn", CallingConvention = CallingConvention.Cdecl, EntryPoint = "wgpuTextureViewRelease")]
    public static extern void TextureViewRelease(TextureViewHandle textureView);
}
