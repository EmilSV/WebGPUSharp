using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// WebGPU FFI (Foreign Function Interface) functions.
/// This is a low-level interface to the WebGPU API, allowing for direct access to the underlying C API.
/// </summary>
public unsafe static partial class WebGPU_FFI
{
    /// <summary>
    /// The const value use to indicate that
    /// <see cref="TextureViewDescriptorFFI.ArrayLayerCount">ArrayLayerCount</see>
    /// is undefined.
    /// </summary>
    public const uint ARRAY_LAYER_COUNT_UNDEFINED = uint.MaxValue;
    /// <summary>
    /// The const value use to indicate that
    /// <see cref="TexelCopyBufferLayout.BytesPerRow">BytesPerRow</see> and <see cref="TexelCopyBufferLayout.RowsPerImage">RowsPerImage</see>
    /// is undefined.
    /// </summary>
    public const uint COPY_STRIDE_UNDEFINED = uint.MaxValue;
    /// <summary>
    /// The const value use to indicate that the
    /// <see cref="RenderPassDepthStencilAttachmentFFI.DepthClearValue">DepthClearValue</see>
    /// is undefined.
    /// </summary>
    public const double DEPTH_CLEAR_VALUE_UNDEFINED = float.NaN;
    /// <summary>
    /// The const value use to indicate that the
    /// <see cref="RenderPassColorAttachmentFFI.DepthSlice">DepthSlice</see>
    /// is undefined.
    /// </summary>
    public const uint DEPTH_SLICE_UNDEFINED = uint.MaxValue;
    /// <summary>
    /// The const value use to indicate that a
    /// <see cref="uint" /> felid of <see cref="Limits">Limits</see>
    /// is undefined.
    /// </summary>
    public const uint LIMIT_U32_UNDEFINED = uint.MaxValue;
    /// <summary>
    /// The const value use to indicate that a
    /// <see cref="ulong" /> felid of <see cref="Limits">Limits</see>
    /// is undefined.
    /// </summary>
    public const ulong LIMIT_U64_UNDEFINED = ulong.MaxValue;
    /// <summary>
    /// The const value use to indicate that the
    /// <see cref="TextureViewDescriptorFFI.MipLevelCount">MipLevelCount</see>
    /// is undefined.
    /// </summary>
    public const uint MIP_LEVEL_COUNT_UNDEFINED = uint.MaxValue;
    /// <summary>
    /// The const value use to indicate that
    /// <see cref="PassTimestampWritesFFI.BeginningOfPassWriteIndex">BeginningOfPassWriteIndex</see> and <see cref="PassTimestampWritesFFI.EndOfPassWriteIndex">EndOfPassWriteIndex</see>
    /// is undefined.
    /// </summary>
    public const uint QUERY_SET_INDEX_UNDEFINED = uint.MaxValue;
    /// <summary>
    /// A
    /// <see cref="StringViewFFI">StringViewFFI</see> with its <see cref="StringViewFFI.Length">Length</see>
    /// as this value represent a null string for the webgpu FFI.
    /// </summary>
    public static readonly nuint STRLEN = nuint.MaxValue;
    /// <summary>
    /// The const value use to indicate that the size for mapping should use whole rest of the buffer.
    /// </summary>
    public static readonly nuint WHOLE_MAP_SIZE = nuint.MaxValue;
    /// <summary>
    /// The const value use to indicate that the
    /// <see cref="BindGroupEntryFFI.Size">BindGroupEntryFFI.Size</see>
    /// is the whole buffer.
    /// </summary>
    public const ulong WHOLE_SIZE = ulong.MaxValue;

    /// <summary>
    /// Free members of a
    /// <see cref="AdapterInfoFFI" />
    /// structure.
    /// After calling this function, using the members will lead to undefined behavior.
    /// </summary>
    /// <param name="value">The <see cref="AdapterInfoFFI" /> to free.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterInfoFreeMembers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterInfoFreeMembers(AdapterInfoFFI value);
    /// <summary>
    /// Create a new instance of the WebGPU API. This is the first step in using the API.
    /// The instance is used to create adapters, which are used to create devices.
    /// </summary>
    /// <param name="descriptor">The options for the instance.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCreateInstance", CallingConvention = CallingConvention.Cdecl)]
    public static extern InstanceHandle CreateInstance(InstanceDescriptor* descriptor);
    /// <summary>
    /// Query the supported instance capabilities.
    /// </summary>
    /// <param name="capabilities">The supported instance capabilities</param>
    /// <returns>Indicates if there was an OutStructChainError <see href="https://webgpu-native.github.io/webgpu-headers/StructChaining.html" />.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuGetInstanceCapabilities", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status GetInstanceCapabilities(InstanceCapabilities* capabilities);
    /// <summary>
    /// Free members of a
    /// <see cref="SupportedWGSLLanguageFeaturesFFI" />
    /// structure.
    /// After calling this function, using the members will lead to undefined behavior.
    /// </summary>
    /// <param name="value">The <see cref="SupportedWGSLLanguageFeaturesFFI" /> to free.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSupportedWGSLLanguageFeaturesFreeMembers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SupportedWGSLLanguageFeaturesFreeMembers(SupportedWGSLLanguageFeaturesFFI value);
    /// <summary>
    /// Free members of a
    /// <see cref="SupportedFeaturesFFI" />
    /// structure.
    /// After calling this function, using the members will lead to undefined behavior.
    /// </summary>
    /// <param name="value">The <see cref="SupportedFeaturesFFI" /> to free.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSupportedFeaturesFreeMembers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SupportedFeaturesFreeMembers(SupportedFeaturesFFI value);
    /// <summary>
    /// Free members of a
    /// <see cref="SurfaceCapabilitiesFFI" />
    /// structure.
    /// After calling this function, using the members will lead to undefined behavior.
    /// </summary>
    /// <param name="value">The <see cref="SurfaceCapabilitiesFFI" /> to free.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceCapabilitiesFreeMembers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceCapabilitiesFreeMembers(SurfaceCapabilitiesFFI value);
    /// <summary>
    /// Get the features supported by the adapter.
    /// </summary>
    /// <param name="adapter">The adapter to query.</param>
    /// <param name="features">The features to fill in.</param>
    /// <returns>the status of the call.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterGetFeatures", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterGetFeatures(AdapterHandle adapter, SupportedFeaturesFFI* features);
    /// <summary>
    /// Get info about the adapter itself.
    /// </summary>
    /// <param name="adapter">The adapter to query.</param>
    /// <param name="info">The info to fill in.</param>
    /// <returns>the status of the call.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterGetInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status AdapterGetInfo(AdapterHandle adapter, AdapterInfoFFI* info);
    /// <summary>
    /// The best limits which can be used to create devices on this adapter.
    /// </summary>
    /// <param name="adapter">The adapter to query.</param>
    /// <param name="limits">The limits to fill in.</param>
    /// <returns>the status of the call.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterGetLimits", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status AdapterGetLimits(AdapterHandle adapter, Limits* limits);
    /// <summary>
    /// Check if and additional functionality is supported by the adapter.
    /// </summary>
    /// <param name="adapter">The adapter to query.</param>
    /// <param name="feature">The feature to check.</param>
    /// <returns>true if the feature is supported.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterHasFeature", CallingConvention = CallingConvention.Cdecl)]
    public static extern WebGPUBool AdapterHasFeature(AdapterHandle adapter, FeatureName feature);
    /// <summary>
    /// Requests a device from the adapter.
    /// This is a one-time action: if a device is returned successfully,
    /// the adapter then enters a "consumed" state
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="Device"/> to request.</param>
    /// <param name="adapter">The adapter to get device from</param>
    /// <param name="callbackInfo">The callback to call when the device is ready</param>
    /// <param name="options">The device descriptor to use.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterRequestDevice", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="adapter">The adapter to add reference to</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="adapter">The adapter to release</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuAdapterRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AdapterRelease(AdapterHandle adapter);
    /// <summary>
    /// Set the label of the bind group.
    /// </summary>
    /// <param name="bindGroup">The bind group set label of</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="bindGroup">The bind group to increase the reference counter on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="bindGroup">The bind group to decreased the reference counter on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupRelease(BindGroupHandle bindGroup);
    /// <summary>
    /// Set the Debug label for this BindGroupLayoutHandle.
    /// </summary>
    /// <param name="bindGroupLayout">The bind group layout set label of</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupLayoutSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="bindGroupLayout">The bind group layout to increase the reference counter on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupLayoutAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="bindGroupLayout">The bind group layout to decreased the reference counter on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBindGroupLayoutRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindGroupLayoutRelease(BindGroupLayoutHandle bindGroupLayout);
    /// <summary>
    /// Destroys the  <see cref="Buffer"/>.
    /// Note: It is valid to destroy a buffer multiple times.
    /// Note: Since no further operations can be enqueued using this buffer, implementations can
    /// free resource allocations, including mapped memory that was just unmapped.
    /// </summary>
    /// <param name="buffer">The buffer to destroy</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferDestroy(BufferHandle buffer);
    /// <summary>
    /// Returns a const pointer to beginning of the mapped range.
    /// It must not be written; writing to this range causes undefined behavior.
    /// See MappedRangeBehavior for error conditions and guarantees.
    /// This function is safe to call inside spontaneous callbacks (see CallbackReentrancy).
    /// </summary>
    /// <param name="buffer">the buffer to get the range from</param>
    /// <param name="size">
    /// Byte size of the range to get.
    /// If this is
    /// <see cref="WHOLE_MAP_SIZE" />
    /// , it defaults to `buffer.size - offset`.
    /// The returned pointer is valid for exactly this many bytes.
    /// </param>
    /// <param name="offset">Byte offset relative to the beginning of the buffer.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetConstMappedRange", CallingConvention = CallingConvention.Cdecl)]
    public static extern void* BufferGetConstMappedRange(BufferHandle buffer, nuint offset, nuint size);
    /// <summary>
    /// An enumerated value representing the mapped state of the Buffer.
    /// </summary>
    /// <param name="buffer">the buffer to get map state of</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetMapState", CallingConvention = CallingConvention.Cdecl)]
    public static extern BufferMapState BufferGetMapState(BufferHandle buffer);
    /// <summary>
    /// Returns an ArrayBuffer with the contents of the  <see cref="Buffer"/> in the given mapped range.
    /// </summary>
    /// <param name="offset">Offset in bytes into the buffer to return buffer contents from.</param>
    /// <param name="size">Size in bytes of the ArrayBuffer to return.</param>
    /// <param name="buffer">the buffer to get the range from</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetMappedRange", CallingConvention = CallingConvention.Cdecl)]
    public static extern void* BufferGetMappedRange(BufferHandle buffer, nuint offset, nuint size);
    /// <summary>
    /// Returns the size of the buffer in bytes.
    /// </summary>
    /// <param name="buffer">the buffer to get size of</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetSize", CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong BufferGetSize(BufferHandle buffer);
    /// <summary>
    /// Returns the allowed usages of the Buffer
    /// </summary>
    /// <param name="buffer">the buffer to get usage of</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferGetUsage", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="buffer">the buffer to map</param>
    /// <param name="callbackInfo">Callback to be called when the buffer is mapped.</param>
    /// <returns>The future for the callback.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferMapAsync", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future BufferMapAsync(BufferHandle buffer, MapMode mode, nuint offset, nuint size, BufferMapCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Copies a range of data from the buffer mapping into the provided destination pointer.
    /// See MappedRangeBehavior for error conditions and guarantees.
    /// This function is safe to call inside spontaneous callbacks (see CallbackReentrancy).
    /// 
    /// In Wasm, this is more efficient than copying from a mapped range into a `malloc`'d range.
    /// </summary>
    /// <param name="buffer">the buffer to read from</param>
    /// <param name="size">Number of bytes of data to read from the buffer. (Note <see cref="WHOLE_MAP_SIZE" /> is *not* accepted here.)</param>
    /// <param name="data">Destination, to read buffer data into.</param>
    /// <param name="offset">Byte offset relative to the beginning of the buffer.</param>
    /// <returns><see cref="Status.Error" /> if the copy did not occur.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferReadMappedRange", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status BufferReadMappedRange(BufferHandle buffer, nuint offset, void* data, nuint size);
    /// <summary>
    /// Sets a label on the Buffer.
    /// </summary>
    /// <param name="buffer">the buffer to set the label of</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferSetLabel(BufferHandle buffer, StringViewFFI label);
    /// <summary>
    /// Unmaps the mapped range of the  <see cref="Buffer"/> and makes its contents available for use by the
    /// GPU again.
    /// </summary>
    /// <param name="buffer">the buffer to unmap</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferUnmap", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferUnmap(BufferHandle buffer);
    /// <summary>
    /// Copies a range of data from the provided source pointer into the buffer mapping.
    /// See MappedRangeBehavior for error conditions and guarantees.
    /// This function is safe to call inside spontaneous callbacks (see CallbackReentrancy).
    /// In Wasm, this is more efficient than copying from a `malloc`'d range into a mapped range.
    /// </summary>
    /// <param name="buffer">the buffer to write to</param>
    /// <param name="size">Number of bytes of data to write to the buffer. (Note <see cref="WHOLE_MAP_SIZE" /> is *not* accepted here.)</param>
    /// <param name="data">Source, to write buffer data from.</param>
    /// <param name="offset">Byte offset relative to the beginning of the buffer.</param>
    /// <returns><see cref="Status.Error" /> if the copy did not occur.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferWriteMappedRange", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status BufferWriteMappedRange(BufferHandle buffer, nuint offset, void* data, nuint size);
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
    /// <param name="buffer">The buffer to increase the reference counter on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="buffer">The buffer to decreased the reference counter on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuBufferRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BufferRelease(BufferHandle buffer);
    /// <summary>
    /// Set debug label of this command buffer.
    /// </summary>
    /// <param name="commandBuffer">the command buffer to set the label of</param>
    /// <param name="label">The new label.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandBufferSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="commandBuffer">The command buffer to increase the reference counter on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandBufferAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="commandBuffer">The command buffer to decreased the reference counter on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandBufferRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandBufferRelease(CommandBufferHandle commandBuffer);
    /// <summary>
    /// Begins encoding a compute pass described by descriptor.
    /// </summary>
    /// <param name="commandEncoder">The command encoder to begin compute pass on</param>
    /// <param name="descriptor">The descriptor for the compute pass.</param>
    /// <returns>A ComputePassEncoder which encodes the compute pass.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderBeginComputePass", CallingConvention = CallingConvention.Cdecl)]
    public static extern ComputePassEncoderHandle CommandEncoderBeginComputePass(CommandEncoderHandle commandEncoder, ComputePassDescriptorFFI* descriptor);
    /// <summary>
    /// Begins encoding a render pass described by <paramref name="descriptor"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="RenderPassEncoder"/> to create.</param>
    /// <param name="commandEncoder">The command encoder to begin render pass on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderBeginRenderPass", CallingConvention = CallingConvention.Cdecl)]
    public static extern RenderPassEncoderHandle CommandEncoderBeginRenderPass(CommandEncoderHandle commandEncoder, RenderPassDescriptorFFI* descriptor);
    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that fills a sub-region of a
    ///  <see cref="Buffer"/> with zeros.
    /// </summary>
    /// <param name="buffer">The  <see cref="Buffer"/> to clear.</param>
    /// <param name="offset">Offset in bytes into <paramref name="buffer"/> where the sub-region to clear begins.</param>
    /// <param name="size">Size in bytes of the sub-region to clear. Defaults to the size of the buffer minus <paramref name="offset"/>.</param>
    /// <param name="commandEncoder">The command encoder to encode command to clear a buffer</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderClearBuffer", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="commandEncoder">The command encoder to encode command that copies from one buffer another</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyBufferToBuffer", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="commandEncoder">The command encoder to encode command that copies from texture to a buffer</param>
    /// <param name="copySize">specifies the width, height, and depth/array layer count of the copied data.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyBufferToTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderCopyBufferToTexture(CommandEncoderHandle commandEncoder, TexelCopyBufferInfoFFI* source, TexelCopyTextureInfoFFI* destination, Extent3D* copySize);
    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that copies data from a sub-region of one or
    /// multiple continuous texture subresources to a sub-region of a  <see cref="Buffer"/>.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source texture subresources.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination buffer.
    /// <paramref name="copySize"/>:
    /// </param>
    /// <param name="commandEncoder">The command encoder to encode command that copies from buffer to a texture</param>
    /// <param name="copySize">specifies the width, height, and depth/array layer count of the copied data.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyTextureToBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderCopyTextureToBuffer(CommandEncoderHandle commandEncoder, TexelCopyTextureInfoFFI* source, TexelCopyBufferInfoFFI* destination, Extent3D* copySize);
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
    /// <param name="commandEncoder">The command encoder to encode command that copies from one texture another</param>
    /// <param name="copySize">specifies the width, height, and depth/array layer count of the copied data.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderCopyTextureToTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderCopyTextureToTexture(CommandEncoderHandle commandEncoder, TexelCopyTextureInfoFFI* source, TexelCopyTextureInfoFFI* destination, Extent3D* copySize);
    /// <summary>
    /// Completes recording of the commands sequence and returns a corresponding  <see cref="CommandBuffer"/>.
    /// </summary>
    /// <param name="commandEncoder">The command encoder to completes recording of the commands on</param>
    /// <param name="descriptor">The descriptor.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderFinish", CallingConvention = CallingConvention.Cdecl)]
    public static extern CommandBufferHandle CommandEncoderFinish(CommandEncoderHandle commandEncoder, CommandBufferDescriptorFFI* descriptor);
    /// <summary>
    /// Marks a point in a stream of commands with a label.
    /// </summary>
    /// <param name="commandEncoder">The command encoder insert debug marker into</param>
    /// <param name="markerLabel">The label to insert.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderInsertDebugMarker(CommandEncoderHandle commandEncoder, StringViewFFI markerLabel);
    /// <summary>
    /// Ends the labeled debug group most recently started by <see cref="CommandEncoderHandle.PushDebugGroup">pushDebugGroup()</see>.
    /// </summary>
    /// <param name="commandEncoder">The command encoder pop the debug group from</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderPopDebugGroup(CommandEncoderHandle commandEncoder);
    /// <summary>
    /// Begins a labeled debug group containing subsequent commands.
    /// </summary>
    /// <param name="commandEncoder">The command encoder push the debug group on</param>
    /// <param name="groupLabel">The label for the command group.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderPushDebugGroup(CommandEncoderHandle commandEncoder, StringViewFFI groupLabel);
    /// <summary>
    /// Resolves query results from a  <see cref="QuerySet"/> out into a range of a  <see cref="Buffer"/>.
    /// </summary>
    /// <param name="commandEncoder">The command encoder resolve query set from</param>
    /// <param name="destinationOffset">The offset, in bytes, from the start of the buffer to start writing the query values at.</param>
    /// <param name="destination">The buffer to copy the query values to.</param>
    /// <param name="queryCount">The number of queries to be copied over to the buffer, starting from <paramref name="firstQuery" /></param>
    /// <param name="firstQuery">The index number of the first query value to be copied over to the buffer.</param>
    /// <param name="querySet">The query set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderResolveQuerySet", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderResolveQuerySet(CommandEncoderHandle commandEncoder, QuerySetHandle querySet, uint firstQuery, uint queryCount, BufferHandle destination, ulong destinationOffset);
    /// <summary>
    /// Set debug label of this command encoder.
    /// </summary>
    /// <param name="commandEncoder">The command encoder set label from</param>
    /// <param name="label">The new label.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderSetLabel(CommandEncoderHandle commandEncoder, StringViewFFI label);
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderWriteTimestamp", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="commandEncoder">The command encoder to increase the reference counter on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="commandEncoder">The command encoder to decreased the reference counter on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuCommandEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CommandEncoderRelease(CommandEncoderHandle commandEncoder);
    /// <summary>
    /// Dispatch work to be performed with the current  <see cref="ComputePipeline"/>.
    /// See #computing-operations for the detailed specification.
    /// </summary>
    /// <param name="workgroupCountX">X dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountY">Y dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountZ">Z dimension of the grid of workgroups to dispatch.</param>
    /// <param name="computePassEncoder">The compute pass encoder to dispatch work on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderDispatchWorkgroups", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="computePassEncoder">The compute pass encoder to dispatch work on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderDispatchWorkgroupsIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderDispatchWorkgroupsIndirect(ComputePassEncoderHandle computePassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the compute pass commands sequence.
    /// </summary>
    /// <param name="computePassEncoder">The compute pass encoder complete recording on</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderEnd", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderEnd(ComputePassEncoderHandle computePassEncoder);
    /// <summary>
    /// Marks a point in a stream of commands with a label.
    /// </summary>
    /// <param name="computePassEncoder">The compute pass encoder to insert a debug mark into</param>
    /// <param name="markerLabel">The label to insert.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderInsertDebugMarker(ComputePassEncoderHandle computePassEncoder, StringViewFFI markerLabel);
    /// <summary>
    /// Ends the labeled debug group most recently started by <see cref="PushDebugGroup" />.
    /// </summary>
    /// <param name="computePassEncoder">The compute pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderPopDebugGroup(ComputePassEncoderHandle computePassEncoder);
    /// <summary>
    /// Begins a labeled debug group containing subsequent commands.
    /// </summary>
    /// <param name="computePassEncoder">The compute pass encoder</param>
    /// <param name="groupLabel">The label to use for the debug group.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderPushDebugGroup(ComputePassEncoderHandle computePassEncoder, StringViewFFI groupLabel);
    /// <summary>
    /// Sets the current GPUBindGroup for the given index.
    /// </summary>
    /// <param name="computePassEncoder">The compute pass encoder</param>
    /// <param name="dynamicOffsets">
    /// a sequence containing buffer offsets in bytes for each
    /// entry in bindGroup marked as Buffer.HasDynamicOffset, ordered by
    /// BindGroupLayoutEntry.Binding.
    /// </param>
    /// <param name="dynamicOffsetCount">The number of dynamic offsets in the dynamicOffsets sequence.</param>
    /// <param name="group">Bind group to use for subsequent render or compute commands.</param>
    /// <param name="groupIndex">The index to set the bind group at.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderSetBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderSetBindGroup(ComputePassEncoderHandle computePassEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    /// <summary>
    /// Set debug label of this command encoder.
    /// </summary>
    /// <param name="computePassEncoder">The compute pass encoder</param>
    /// <param name="label">The new label.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderSetLabel(ComputePassEncoderHandle computePassEncoder, StringViewFFI label);
    /// <summary>
    /// Sets the current  <see cref="ComputePipeline"/>.
    /// </summary>
    /// <param name="pipeline">The compute pipeline to use for subsequent dispatch commands.</param>
    /// <param name="computePassEncoder">The compute pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderSetPipeline", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="computePassEncoder">The compute pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="computePassEncoder">The compute pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePassEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePassEncoderRelease(ComputePassEncoderHandle computePassEncoder);
    /// <summary>
    /// Gets the bind group layout for the given group index.
    /// 
    /// If this pipeline was created with a default layout,
    /// then bind groups created with the returned BindGroupLayout can only be used with this pipeline.
    /// This method will raise a validation error if there is no bind group layout at index.
    /// </summary>
    /// <param name="computePipeline">The compute pipeline</param>
    /// <param name="groupIndex">Index into the pipeline layout's bindGroupLayouts sequence.</param>
    /// <returns>The bind group layout for the given group index.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineGetBindGroupLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern BindGroupLayoutHandle ComputePipelineGetBindGroupLayout(ComputePipelineHandle computePipeline, uint groupIndex);
    /// <summary>
    /// Set debug label of this compute pipeline.
    /// </summary>
    /// <param name="computePipeline">The compute pipeline</param>
    /// <param name="label">The new label.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="computePipeline">The compute pipeline</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="computePipeline">The compute pipeline</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuComputePipelineRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ComputePipelineRelease(ComputePipelineHandle computePipeline);
    /// <summary>
    /// Creates a BindGroup.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the BindGroup</param>
    /// <returns>A new BindGroup</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern BindGroupHandle DeviceCreateBindGroup(DeviceHandle device, BindGroupDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a BindGroupLayout.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the BindGroupLayout</param>
    /// <returns>A new BindGroupLayout</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateBindGroupLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern BindGroupLayoutHandle DeviceCreateBindGroupLayout(DeviceHandle device, BindGroupLayoutDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a Buffer.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the Buffer</param>
    /// <returns>A new Buffer</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern BufferHandle DeviceCreateBuffer(DeviceHandle device, BufferDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a CommandEncoder.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the CommandEncoder</param>
    /// <returns>A new CommandEncoder</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateCommandEncoder", CallingConvention = CallingConvention.Cdecl)]
    public static extern CommandEncoderHandle DeviceCreateCommandEncoder(DeviceHandle device, CommandEncoderDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a ComputePipeline using immediate pipeline creation.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the ComputePipeline</param>
    /// <returns>A new ComputePipeline</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateComputePipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern ComputePipelineHandle DeviceCreateComputePipeline(DeviceHandle device, ComputePipelineDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a GPUComputePipeline using async pipeline creation.
    /// The returned future resolves when the created pipeline is ready to be used without additional delay.
    /// </summary>
    /// <remarks">Use of this method is preferred whenever possible, as it prevents blocking the queue timeline work on pipeline compilation.</remarks>
    /// <param name="device">The device</param>
    /// <param name="callbackInfo">The callbackInfo to use for the ComputePipeline</param>
    /// <param name="descriptor">The descriptor to use for the ComputePipeline</param>
    /// <returns>A future resolving when the pipeline is ready</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateComputePipelineAsync", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future DeviceCreateComputePipelineAsync(DeviceHandle device, ComputePipelineDescriptorFFI* descriptor, CreateComputePipelineAsyncCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Creates a PipelineLayout.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the PipelineLayout</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreatePipelineLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern PipelineLayoutHandle DeviceCreatePipelineLayout(DeviceHandle device, PipelineLayoutDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a QuerySet.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the QuerySet</param>
    /// <returns>A new QuerySet</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateQuerySet", CallingConvention = CallingConvention.Cdecl)]
    public static extern QuerySetHandle DeviceCreateQuerySet(DeviceHandle device, QuerySetDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a RenderBundleEncoder.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the RenderBundleEncoder</param>
    /// <returns>A new RenderBundleEncoder</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateRenderBundleEncoder", CallingConvention = CallingConvention.Cdecl)]
    public static extern RenderBundleEncoderHandle DeviceCreateRenderBundleEncoder(DeviceHandle device, RenderBundleEncoderDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a GPURenderPipeline using immediate pipeline creation.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the RenderPipeline</param>
    /// <returns>A new RenderPipeline</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateRenderPipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern RenderPipelineHandle DeviceCreateRenderPipeline(DeviceHandle device, RenderPipelineDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a GPURenderPipeline using async pipeline creation.
    /// The returned future resolves when the created pipeline is ready to be used without additional delay.
    /// </summary>
    /// <remarks">Use of this method is preferred whenever possible, as it prevents blocking the queue timeline work on pipeline compilation.</remarks>
    /// <param name="device">The device</param>
    /// <param name="callbackInfo">The callbackInfo to use for the RenderPipeline</param>
    /// <param name="descriptor">The descriptor to use for the RenderPipeline</param>
    /// <returns>A future resolving when the pipeline is ready</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateRenderPipelineAsync", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future DeviceCreateRenderPipelineAsync(DeviceHandle device, RenderPipelineDescriptorFFI* descriptor, CreateRenderPipelineAsyncCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Creates a Sampler.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the Sampler</param>
    /// <returns>A new Sampler</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateSampler", CallingConvention = CallingConvention.Cdecl)]
    public static extern SamplerHandle DeviceCreateSampler(DeviceHandle device, SamplerDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a ShaderModule.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the ShaderModule</param>
    /// <returns>A new ShaderModule</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateShaderModule", CallingConvention = CallingConvention.Cdecl)]
    public static extern ShaderModuleHandle DeviceCreateShaderModule(DeviceHandle device, ShaderModuleDescriptorFFI* descriptor);
    /// <summary>
    /// Creates a Texture.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="descriptor">The descriptor to use for the Texture</param>
    /// <returns>A new Texture</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceCreateTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureHandle DeviceCreateTexture(DeviceHandle device, TextureDescriptorFFI* descriptor);
    /// <summary>
    /// Destroys the device, preventing further operations on it. Outstanding asynchronous operations will fail.
    /// </summary>
    /// <remarks">It is valid to destroy a device multiple times.</remarks>
    /// <param name="device">The device</param>
    /// <returns>A future resolving when the device is destroyed</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceDestroy(DeviceHandle device);
    /// <summary>
    /// Information about the physical adapter which created the device that this GPUDevice refers to.
    /// 
    /// For a given GPUDevice, the GPUAdapterInfo values exposed are constant over time.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="adapterInfo">The adapterInfo to insert the adapter info into</param>
    /// <returns>the status of the operation</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetAdapterInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status DeviceGetAdapterInfo(DeviceHandle device, AdapterInfoFFI* adapterInfo);
    /// <summary>
    /// Get the features supported by the device
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="features">an pointer to a SupportedFeaturesFFI to insert the supported features into</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetFeatures", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceGetFeatures(DeviceHandle device, SupportedFeaturesFFI* features);
    /// <summary>
    /// Get the limits which can be used on this device.
    /// No better limits can be used, even if the underlying adapter can support them.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="limits">an pointer to a SupportedLimits to insert the limits into</param>
    /// <returns>Return status of the operation</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetLimits", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status DeviceGetLimits(DeviceHandle device, Limits* limits);
    /// <summary>
    /// Get the future which resolves when the device is lost
    /// </summary>
    /// <param name="device">The device</param>
    /// <returns>The <see cref="Future" /> for the device-lost event of the device.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetLostFuture", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future DeviceGetLostFuture(DeviceHandle device);
    /// <summary>
    /// Get the primary Queue for this device.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="queue">Get the queue to insert command into</param>
    /// <returns>the queue</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceGetQueue", CallingConvention = CallingConvention.Cdecl)]
    public static extern QueueHandle DeviceGetQueue(DeviceHandle device);
    /// <summary>
    /// Check if the feature is supported
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="feature">The feature to check</param>
    /// <returns>true if the feature is supported false otherwise</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceHasFeature", CallingConvention = CallingConvention.Cdecl)]
    public static extern WebGPUBool DeviceHasFeature(DeviceHandle device, FeatureName feature);
    /// <summary>
    /// Pops a error scope off the errorScopeStack for this device and resolves to any error observed by the error scope, or null if none.
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="callbackInfo">The callback to call when the error scope is popped.</param>
    /// <returns>a future resolving when the error from the error scope is ready to be observed</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDevicePopErrorScope", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future DevicePopErrorScope(DeviceHandle device, PopErrorScopeCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Pushes a new error scope onto the errorScopeStack for this device
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="filter">Which class of errors this error scope observes</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDevicePushErrorScope", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DevicePushErrorScope(DeviceHandle device, ErrorFilter filter);
    /// <summary>
    /// Set debug label of this device
    /// </summary>
    /// <param name="device">The device</param>
    /// <param name="label">The label to set</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="device">The device</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="device">The device</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuDeviceRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeviceRelease(DeviceHandle device);
    /// <summary>
    /// Creates a new surface targeting a given window/canvas/surface/etc..
    /// </summary>
    /// <param name="instance">The instance</param>
    /// <param name="descriptor">The descriptor to use for the surface</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceCreateSurface", CallingConvention = CallingConvention.Cdecl)]
    public static extern SurfaceHandle InstanceCreateSurface(InstanceHandle instance, SurfaceDescriptorFFI* descriptor);
    /// <summary>
    /// Returns set of supported WGSL language extensions supported by this instance.
    /// </summary>
    /// <param name="instance">The instance</param>
    /// <param name="features">A pointer to struct to fill with supported extension</param>
    /// <returns>The status of the operation</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceGetWGSLLanguageFeatures", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status InstanceGetWGSLLanguageFeatures(InstanceHandle instance, SupportedWGSLLanguageFeaturesFFI* features);
    /// <summary>
    /// check if a WGSL language extensions is supported by this instance.
    /// </summary>
    /// <param name="instance">The instance</param>
    /// <param name="feature">The feature to check for</param>
    /// <returns>true if the feature is supported, false otherwise.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceHasWGSLLanguageFeature", CallingConvention = CallingConvention.Cdecl)]
    public static extern WebGPUBool InstanceHasWGSLLanguageFeature(InstanceHandle instance, WGSLLanguageFeatureName feature);
    /// <summary>
    /// Processes asynchronous events on this `Instance`, calling any callbacks for asynchronous operations created with <see cref="CallbackMode.AllowProcessEvents" />.
    /// </summary>
    /// <param name="instance">The instance</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceProcessEvents", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InstanceProcessEvents(InstanceHandle instance);
    /// <summary>
    /// Retrieves an Adapter which matches the given <see cref="RequestAdapterOptionsFFI" />.
    /// </summary>
    /// <param name="instance">The instance</param>
    /// <param name="callbackInfo">The callback to call when the adapter is ready</param>
    /// <param name="options">The options to use for the adapter</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceRequestAdapter", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future InstanceRequestAdapter(InstanceHandle instance, RequestAdapterOptionsFFI* options, RequestAdapterCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Wait for at least one Future in `futures` to complete, and call callbacks of the respective completed asynchronous operations.
    /// </summary>
    /// <param name="instance">The instance</param>
    /// <param name="timeoutNS">The timeout in nanoseconds</param>
    /// <param name="futures">The futures to wait for</param>
    /// <param name="futureCount">The number of futures to wait for</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceWaitAny", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="instance">The instance</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="instance">The instance</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuInstanceRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void InstanceRelease(InstanceHandle instance);
    /// <summary>
    /// Sets the label of the pipeline layout.
    /// </summary>
    /// <param name="pipelineLayout">The pipeline layout</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuPipelineLayoutSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="pipelineLayout">The pipeline layout</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuPipelineLayoutAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="pipelineLayout">The pipeline layout</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuPipelineLayoutRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void PipelineLayoutRelease(PipelineLayoutHandle pipelineLayout);
    /// <summary>
    /// Destroys the  <see cref="QuerySet"/>.
    /// </summary>
    /// <param name="querySet">The query set</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuerySetDestroy(QuerySetHandle querySet);
    /// <summary>
    /// Gets the number of queries managed by this QuerySet.
    /// </summary>
    /// <param name="querySet">The query set</param>
    /// <returns>number of queries managed by this QuerySet.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetGetCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint QuerySetGetCount(QuerySetHandle querySet);
    /// <summary>
    /// Specifying the type of queries managed by the <see cref="QuerySetHandle" />.
    /// </summary>
    /// <param name="querySet">The query set</param>
    /// <returns>
    /// Two possible values:
    /// <list type="bullet"><item><description><see cref="QueryType.Occlusion">Occlusion</see> The <see cref="QuerySetHandle" /> manages occlusion queries.</description></item><item><description><see cref="QueryType.Timestamp">Timestamp</see> The <see cref="QuerySetHandle" /> manages timestamp queries.</description></item></list>
    /// </returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetGetType", CallingConvention = CallingConvention.Cdecl)]
    public static extern QueryType QuerySetGetType(QuerySetHandle querySet);
    /// <summary>
    /// Sets a label on the QuerySet.
    /// </summary>
    /// <param name="querySet">The query set</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="querySet">The query set</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="QuerySetHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    /// <param name="querySet">The query set</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQuerySetRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuerySetRelease(QuerySetHandle querySet);
    /// <summary>
    /// Registers a callback when the previous call to submit finishes running on the gpu. This callback being called implies that all mapped buffer callbacks which were registered before this call will have been called.
    /// For the callback to complete, either queue.submit(..), instance.poll_all(..), or device.poll(..) must be called elsewhere in the runtime, possibly integrated into an event loop or run on a separate thread.
    /// The callback will be called on the thread that first calls the above functions after the gpu work has completed. There are no restrictions on the code you can run in the callback,
    /// however on native the call to the function will not complete until the callback returns, so prefer keeping callbacks short and used to set flags, send messages, etc.
    /// </summary>
    /// <param name="queue">The queue</param>
    /// <param name="callbackInfo">callback to be called with some user data to be passed to the callback.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueOnSubmittedWorkDone", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future QueueOnSubmittedWorkDone(QueueHandle queue, QueueWorkDoneCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Sets a label on the queue.
    /// </summary>
    /// <param name="queue">The queue</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueSetLabel(QueueHandle queue, StringViewFFI label);
    /// <summary>
    /// Schedules the execution of the command buffers by the GPU on this queue.
    /// Submitted command buffers cannot be used again.
    /// </summary>
    /// <param name="queue">The queue</param>
    /// <param name="commands">The command buffers to submit.</param>
    /// <param name="commandCount">The number of command buffers to submit.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueSubmit", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="queue">The queue</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueWriteBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueWriteBuffer(QueueHandle queue, BufferHandle buffer, ulong bufferOffset, void* data, nuint size);
    /// <summary>
    /// Issues a write operation of the provided data into a  <see cref="Texture"/>.
    /// </summary>
    /// <param name="destination">The texture subresource and origin to write to.</param>
    /// <param name="data">Data to write into <paramref name="destination"/>.</param>
    /// <param name="dataLayout">Layout of the content in <paramref name="data"/>.</param>
    /// <param name="size">Extents of the content to write from <paramref name="data"/> to <paramref name="destination"/>.</param>
    /// <param name="queue">The queue</param>
    /// <param name="dataSize">The size of the data to write.</param>
    /// <param name="writeSize">Extents of the content to write from <paramref name="data" /> to <paramref name="destination" />.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueWriteTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueWriteTexture(QueueHandle queue, TexelCopyTextureInfoFFI* destination, void* data, nuint dataSize, TexelCopyBufferLayout* dataLayout, Extent3D* writeSize);
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
    /// <param name="queue">The queue</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="queue">The queue</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuQueueRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void QueueRelease(QueueHandle queue);
    /// <summary>
    /// Sets the debug label of the RenderBundleHandle.
    /// </summary>
    /// <param name="renderBundle">The render bundle</param>
    /// <param name="label">The new debug label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="renderBundle">The render bundle</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="renderBundle">The render bundle</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleRelease", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="firstInstance">The index of the first instance to draw.</param>
    /// <param name="firstVertex">The index of the first vertex to draw.</param>
    /// <param name="instanceCount">The number of instances to draw.</param>
    /// <param name="vertexCount">The number of vertices to draw.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDraw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDraw(RenderBundleEncoderHandle renderBundleEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);
    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffer(s).
    /// 
    /// The active index buffer can be set with <see cref="RenderBundleEncoderHandle.SetIndexBuffer" />.
    /// The active vertex buffer(s) can be set with <see cref="RenderBundleEncoderHandle.SetVertexBuffer" />.
    /// 
    /// Errors if indices Range is outside of the range of the indices range of any set index buffer.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="firstInstance">The index of the first instance to draw.</param>
    /// <param name="baseVertex">The value added to the vertex index before indexing into the vertex buffer.</param>
    /// <param name="firstIndex">The index of the first index to draw.</param>
    /// <param name="instanceCount">The number of instances to draw.</param>
    /// <param name="indexCount">The number of indices to draw.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDrawIndexed", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDrawIndexed(RenderBundleEncoderHandle renderBundleEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);
    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffers, based on the contents of the indirectBuffer.
    /// 
    /// The active index buffer can be set with RenderBundleEncoder.SetIndexBuffer, while the active vertex buffers can be set with RenderBundleEncoder.SetVertexBuffer.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
    /// <param name="indirectBuffer">Buffer containing the indirect drawIndexed parameters.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDrawIndexedIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDrawIndexedIndirect(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Draws primitives from the active vertex buffer(s) based on the contents of the indirectBuffer.
    /// 
    /// The active vertex buffers can be set with <see cref="RenderBundleEncoderHandle.SetVertexBuffer" />.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
    /// <param name="indirectBuffer">Buffer containing the indirect drawIndexed parameters.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderDrawIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderDrawIndirect(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the render bundle commands sequence.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="descriptor">The descriptor to use for the RenderBundle.</param>
    /// <returns>A new RenderBundleHandle.</returns>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderFinish", CallingConvention = CallingConvention.Cdecl)]
    public static extern RenderBundleHandle RenderBundleEncoderFinish(RenderBundleEncoderHandle renderBundleEncoder, RenderBundleDescriptorFFI* descriptor);
    /// <summary>
    /// Inserts a debug marker into the command stream.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="markerLabel">The label of the debug marker.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderInsertDebugMarker(RenderBundleEncoderHandle renderBundleEncoder, StringViewFFI markerLabel);
    /// <summary>
    /// Stops command recording and creates debug group.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderPopDebugGroup(RenderBundleEncoderHandle renderBundleEncoder);
    /// <summary>
    /// Start record commands and group it into debug marker group.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="groupLabel">The label of the debug marker group.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderPushDebugGroup(RenderBundleEncoderHandle renderBundleEncoder, StringViewFFI groupLabel);
    /// <summary>
    /// Sets the active bind group for a given bind group index.
    /// The bind group layout in the active pipeline when any Draw() function is called must match the layout of this bind group.
    /// 
    /// If the bind group have dynamic offsets, provide them in the binding order.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="dynamicOffsets">A square containing buffer offsets in bytes for each entry in bindGroup marked as buffer.HasDynamicOffset, ordered by BindGroupLayoutEntry.Binding.</param>
    /// <param name="dynamicOffsetCount">The number of offsets in dynamicOffsets.</param>
    /// <param name="group">Bind group to use for subsequent render or compute commands.</param>
    /// <param name="groupIndex">The index to set the bind group at.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetBindGroup(RenderBundleEncoderHandle renderBundleEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    /// <summary>
    /// Sets the active index buffer.
    /// 
    /// Subsequent calls to DrawIndexed on this RenderBundleEncoderHandle will use buffer as the source index buffer.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="size">The size in bytes of the index buffer.</param>
    /// <param name="offset">The offset in bytes from the start of the buffer to the first index.</param>
    /// <param name="format">The format of the index buffer.</param>
    /// <param name="buffer">The index buffer to use.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetIndexBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetIndexBuffer(RenderBundleEncoderHandle renderBundleEncoder, BufferHandle buffer, IndexFormat format, ulong offset, ulong size);
    /// <summary>
    /// Sets the debug label of the RenderBundleEncoderHandle.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="label">The new debug label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetLabel(RenderBundleEncoderHandle renderBundleEncoder, StringViewFFI label);
    /// <summary>
    /// Sets the current RenderPipeline.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="pipeline">The render pipeline to use for subsequent drawing commands.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetPipeline", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderSetPipeline(RenderBundleEncoderHandle renderBundleEncoder, RenderPipelineHandle pipeline);
    /// <summary>
    /// Assign a vertex buffer to a slot.
    /// 
    /// Subsequent calls to draw and draw_indexed on this RenderBundleEncoderHandle will use buffer as one of the source vertex buffers.
    /// 
    /// The slot refers to the index of the matching descriptor in VertexState.Buffers.
    /// </summary>
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    /// <param name="size">Size in bytes of the vertex data in buffer. Defaults to the size of the buffer minus the offset.</param>
    /// <param name="offset">Offset in bytes into buffer where the vertex data begins.</param>
    /// <param name="buffer">Buffer containing vertex data to use for subsequent drawing commands.</param>
    /// <param name="slot">The vertex buffer slot to set the vertex buffer for.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderSetVertexBuffer", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="renderBundleEncoder">The render bundle encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderBundleEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderBundleEncoderRelease(RenderBundleEncoderHandle renderBundleEncoder);
    /// <summary>
    /// Start a occlusion query on this render pass. It can be ended with end_occlusion_query. Occlusion queries may not be nested.
    /// </summary>
    /// <param name="queryIndex">The index of the query in the query set.</param>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderBeginOcclusionQuery", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderBeginOcclusionQuery(RenderPassEncoderHandle renderPassEncoder, uint queryIndex);
    /// <summary>
    /// Draws primitives from the active vertex buffer(s).
    /// 
    /// The active vertex buffer(s) can be set with <see cref="SetVertexBuffer" />. Does not use an Index Buffer. If you need this see <see cref="DrawIndexed" />.
    /// 
    /// Errors if vertices Range is outside of the range of the vertices range of any set vertex buffer.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="firstInstance">First instance to draw.</param>
    /// <param name="firstVertex">Offset into the vertex buffers, in vertices, to begin drawing from.</param>
    /// <param name="instanceCount">The number of instances to draw.</param>
    /// <param name="vertexCount">The number of vertices to draw.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDraw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDraw(RenderPassEncoderHandle renderPassEncoder, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);
    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffers.
    /// 
    /// The active index buffer can be set with <see cref="SetIndexBuffer" /> The active vertex buffers can be set with <see cref="SetVertexBuffer" />.
    /// 
    /// Errors if indices Range is outside of the range of the indices range of any set index buffer.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="firstInstance">First instance to draw.</param>
    /// <param name="baseVertex">Added to each index value before indexing into the vertex buffers.</param>
    /// <param name="firstIndex">Offset into the index buffer, in indices, begin drawing from.</param>
    /// <param name="instanceCount">The number of indices to draw.</param>
    /// <param name="indexCount">The number of indices to draw.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDrawIndexed", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDrawIndexed(RenderPassEncoderHandle renderPassEncoder, uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance);
    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffers, based on the contents of the indirectBuffer.
    /// 
    /// This is like calling <see cref="DrawIndexed" /> but the contents of the call are specified in the indirectBuffer.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="indirectBuffer">Buffer containing the indirect drawIndexed parameters</param>
    /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDrawIndexedIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDrawIndexedIndirect(RenderPassEncoderHandle renderPassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Draws primitives from the active vertex buffer(s) based on the contents of the <paramref name="indirectBuffer" />.
    /// 
    /// The active vertex buffers can be set with <see cref="FFI.RenderEncoder.SetVertexBuffer" />.
    /// 
    /// The indirect draw parameters encoded in the buffer must be a tightly packed block of four 32-bit unsigned integer values (16 bytes total), given in the same order as the arguments for <see cref="FFI.RenderEncoder.Draw" />.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
    /// <param name="indirectBuffer">Buffer containing the indirect draw parameters.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderDrawIndirect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderDrawIndirect(RenderPassEncoderHandle renderPassEncoder, BufferHandle indirectBuffer, ulong indirectOffset);
    /// <summary>
    /// Completes recording of the render pass commands sequence.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderEnd", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderEnd(RenderPassEncoderHandle renderPassEncoder);
    /// <summary>
    /// End the occlusion query on this render pass. It can be started with <see cref="BeginOcclusionQuery" />. Occlusion queries may not be nested.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderEndOcclusionQuery", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="bundleCount">The number item in the <paramref name="bundles" /> sequence.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderExecuteBundles", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderExecuteBundles(RenderPassEncoderHandle renderPassEncoder, nuint bundleCount, RenderBundleHandle* bundles);
    /// <summary>
    /// Inserts a debug marker into the command stream.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="markerLabel">The label of the debug marker.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderInsertDebugMarker", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderInsertDebugMarker(RenderPassEncoderHandle renderPassEncoder, StringViewFFI markerLabel);
    /// <summary>
    /// Stops command recording and creates debug group.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderPopDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderPopDebugGroup(RenderPassEncoderHandle renderPassEncoder);
    /// <summary>
    /// Start record commands and group it into debug marker group.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="groupLabel">The label of the debug group.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderPushDebugGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderPushDebugGroup(RenderPassEncoderHandle renderPassEncoder, StringViewFFI groupLabel);
    /// <summary>
    /// Sets the active bind group for a given bind group index. The bind group layout in the active pipeline when any Draw*() method is called must match the layout of this bind group.
    /// 
    /// If the bind group have dynamic offsets, provide them in binding order. These offsets have to be aligned to Limits.MinUniformBufferOffsetAlignment or Limits.MinStorageBufferOffsetAlignment appropriately.
    /// 
    /// Subsequent draw calls' shader executions will be able to access data in these bind groups.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="dynamicOffsets">Sequence containing buffer offsets in bytes for each entry in bindGroup marked as <see cref="BindGroupLayoutEntry.BindGroupLayoutEntry.Buffer">Buffer</see>.<see cref="BufferBindingLayout.HasDynamicOffset">HasDynamicOffset</see>, ordered by <see cref="BindGroupLayoutEntry.BindGroupLayoutEntry.Binding">BindGroupLayoutEntry.Binding</see>.</param>
    /// <param name="dynamicOffsetCount">The number of item in the <paramref name="dynamicOffsets" />.</param>
    /// <param name="group">Bind group to use for subsequent render commands.</param>
    /// <param name="groupIndex">The index to set the bind group at.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetBindGroup", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetBindGroup(RenderPassEncoderHandle renderPassEncoder, uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets);
    /// <summary>
    /// Sets the constant blend color and alpha values used with  <see cref="BlendFactor.Constant"/>
    /// and  <see cref="BlendFactor.One-minus-constant"/>  <see cref="BlendFactor"/>s.
    /// </summary>
    /// <param name="color">The color to use when blending.</param>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetBlendConstant", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetBlendConstant(RenderPassEncoderHandle renderPassEncoder, Color* color);
    /// <summary>
    /// Sets the active index buffer.
    /// 
    /// Subsequent calls to <see cref="DrawIndexed" /> on this RenderPassEncoderHandle will use buffer as the source index buffer.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="size">Size in bytes of the index data in buffer. Defaults to the size of the buffer minus the offset.</param>
    /// <param name="offset">Offset in bytes into buffer where the index data begins. Defaults to 0.</param>
    /// <param name="format">Format of the index data contained in buffer.</param>
    /// <param name="buffer">Buffer containing index data to use for subsequent drawing commands.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetIndexBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetIndexBuffer(RenderPassEncoderHandle renderPassEncoder, BufferHandle buffer, IndexFormat format, ulong offset, ulong size);
    /// <summary>
    /// Sets the debug label of the RenderPassEncoderHandle.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetLabel(RenderPassEncoderHandle renderPassEncoder, StringViewFFI label);
    /// <summary>
    /// Sets the active render pipeline.
    /// 
    /// Subsequent draw calls will exhibit the behavior defined by pipeline.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="pipeline">The render pipeline to use for subsequent drawing commands.</param>
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
    /// <param name="renderPassEncoder">The render pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetScissorRect", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetScissorRect(RenderPassEncoderHandle renderPassEncoder, uint x, uint y, uint width, uint height);
    /// <summary>
    /// Sets the {{RenderState/stencilReference}} value used during stencil tests with
    /// the  <see cref="StencilOperation.Replace"/>  <see cref="StencilOperation"/>.
    /// </summary>
    /// <param name="reference">The new stencil reference value.</param>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetStencilReference", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderSetStencilReference(RenderPassEncoderHandle renderPassEncoder, uint reference);
    /// <summary>
    /// Assign a vertex buffer to a slot.
    /// 
    /// Subsequent calls to draw and draw_indexed on this RenderPass will use buffer as one of the source vertex buffers.
    /// 
    /// The slot refers to the index of the matching descriptor in VertexState.Buffers.
    /// </summary>
    /// <param name="renderPassEncoder">The render pass encoder</param>
    /// <param name="slot">The vertex buffer slot to set the vertex buffer for.</param>
    /// <param name="buffer">Buffer containing vertex data to use for subsequent drawing commands.</param>
    /// <param name="size">Size in bytes of the vertex data in buffer. Defaults to the size of the buffer minus the offset.</param>
    /// <param name="offset">Offset in bytes into buffer where the vertex data begins. Defaults to 0.</param>
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
    /// <param name="renderPassEncoder">The render pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderSetViewport", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="renderPassEncoder">The render pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="renderPassEncoder">The render pass encoder</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPassEncoderRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPassEncoderRelease(RenderPassEncoderHandle renderPassEncoder);
    /// <summary>
    /// Get an object representing the bind group layout at a given index.
    /// 
    /// If this pipeline was created with a default layout, then bind groups created with the returned BindGroupLayout can only be used with this pipeline.
    /// 
    /// This method will raise a validation error if there is no bind group layout at index.
    /// </summary>
    /// <param name="renderPipeline">The render pipeline</param>
    /// <param name="groupIndex">Index into the pipeline layout's sequence.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineGetBindGroupLayout", CallingConvention = CallingConvention.Cdecl)]
    public static extern BindGroupLayoutHandle RenderPipelineGetBindGroupLayout(RenderPipelineHandle renderPipeline, uint groupIndex);
    /// <summary>
    /// Set the debug label of this RenderPipelineHandle.
    /// </summary>
    /// <param name="renderPipeline">The render pipeline</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="renderPipeline">The render pipeline</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="renderPipeline">The render pipeline</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuRenderPipelineRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RenderPipelineRelease(RenderPipelineHandle renderPipeline);
    /// <summary>
    /// Set the label of the sampler.
    /// </summary>
    /// <param name="sampler">The sampler</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSamplerSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="sampler">The sampler</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSamplerAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="sampler">The sampler</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSamplerRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SamplerRelease(SamplerHandle sampler);
    /// <summary>
    /// Returns any messages generated during the <see cref="ShaderModule" />'s compilation.
    /// The locations, order, and contents of messages are implementation-defined
    /// In particular, messages may not be ordered by <see cref="CompilationMessage.LineNum" />.
    /// </summary>
    /// <param name="shaderModule">The shader module</param>
    /// <param name="callbackInfo">The callback to call when the compilation info is ready.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleGetCompilationInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern Future ShaderModuleGetCompilationInfo(ShaderModuleHandle shaderModule, CompilationInfoCallbackInfoFFI callbackInfo);
    /// <summary>
    /// Sets the debug label of the shader module.
    /// </summary>
    /// <param name="shaderModule">The shader module</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="shaderModule">The shader module</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="shaderModule">The shader module</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuShaderModuleRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ShaderModuleRelease(ShaderModuleHandle shaderModule);
    /// <summary>
    /// Configures the surface.
    /// </summary>
    /// <param name="surface">The surface</param>
    /// <param name="config">The configuration to use.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceConfigure", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceConfigure(SurfaceHandle surface, SurfaceConfigurationFFI* config);
    /// <summary>
    /// Returns the capabilities of the surface when used with the given adapter.
    /// 
    /// Returns specified values (see SurfaceCapabilities) if surface is incompatible with the adapter.
    /// </summary>
    /// <param name="surface">The surface</param>
    /// <param name="capabilities">The capabilities of the surface.</param>
    /// <param name="adapter">The adapter to use.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceGetCapabilities", CallingConvention = CallingConvention.Cdecl)]
    public static extern Status SurfaceGetCapabilities(SurfaceHandle surface, AdapterHandle adapter, SurfaceCapabilitiesFFI* capabilities);
    /// <summary>
    /// Gets the current texture of the surface.
    /// </summary>
    /// <param name="surface">The surface</param>
    /// <param name="surfaceTexture">The current texture of the surface.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceGetCurrentTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceGetCurrentTexture(SurfaceHandle surface, SurfaceTextureFFI* surfaceTexture);
    /// <summary>
    /// Presents the surface.
    /// </summary>
    /// <param name="surface">The surface</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfacePresent", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfacePresent(SurfaceHandle surface);
    /// <summary>
    /// Sets the label of the surface.
    /// </summary>
    /// <param name="surface">The surface</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceSetLabel(SurfaceHandle surface, StringViewFFI label);
    /// <summary>
    /// Unconfigures the surface.
    /// </summary>
    /// <param name="surface">The surface</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceUnconfigure", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="surface">The surface</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="surface">The surface</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuSurfaceRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SurfaceRelease(SurfaceHandle surface);
    /// <summary>
    /// Creates a  <see cref="TextureView"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="TextureView"/> to create.</param>
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureCreateView", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureViewHandle TextureCreateView(TextureHandle texture, TextureViewDescriptorFFI* descriptor);
    /// <summary>
    /// Destroys the  <see cref="Texture"/>.
    /// </summary>
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureDestroy", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureDestroy(TextureHandle texture);
    /// <summary>
    /// Returns the depth or layer count of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Size.DepthOrArrayLayers" /> that was specified when creating the texture.
    /// </summary>
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetDepthOrArrayLayers", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetDepthOrArrayLayers(TextureHandle texture);
    /// <summary>
    /// Returns the dimension of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Dimension" /> that was specified when creating the texture.
    /// </summary>
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetDimension", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureDimension TextureGetDimension(TextureHandle texture);
    /// <summary>
    /// Returns the format of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Format" /> that was specified when creating the texture.
    /// </summary>
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetFormat", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureFormat TextureGetFormat(TextureHandle texture);
    /// <summary>
    /// Returns the height of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Size.Height" /> that was specified when creating the texture.
    /// </summary>
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetHeight", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetHeight(TextureHandle texture);
    /// <summary>
    /// Returns the number of mip levels in the texture.
    /// </summary>
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetMipLevelCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetMipLevelCount(TextureHandle texture);
    /// <summary>
    /// Returns the number of samples in the texture.
    /// </summary>
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetSampleCount", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetSampleCount(TextureHandle texture);
    /// <summary>
    /// Returns the allowed usages of this Texture.
    /// 
    /// This is always equal to the usage that was specified when creating the texture.
    /// </summary>
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetUsage", CallingConvention = CallingConvention.Cdecl)]
    public static extern TextureUsage TextureGetUsage(TextureHandle texture);
    /// <summary>
    /// Returns the width of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Size.Width" /> that was specified when creating the texture.
    /// </summary>
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureGetWidth", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextureGetWidth(TextureHandle texture);
    /// <summary>
    /// Sets the debug label of texture.
    /// </summary>
    /// <param name="texture">The texture</param>
    /// <param name="label">The new label.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureSetLabel", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureAddRef", CallingConvention = CallingConvention.Cdecl)]
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
    /// <param name="texture">The texture</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureRelease(TextureHandle texture);
    /// <summary>
    /// Set the label of the texture view.
    /// </summary>
    /// <param name="textureView">The texture view</param>
    /// <param name="label">The label to set.</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureViewSetLabel", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureViewSetLabel(TextureViewHandle textureView, StringViewFFI label);
    /// <summary>
    /// Increments the reference count of the <see cref="TextureViewHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    /// <param name="textureView">The texture view</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureViewAddRef", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureViewAddRef(TextureViewHandle textureView);
    /// <summary>
    /// Decrements the reference count of the <see cref="TextureViewHandle"/>. When the reference count reaches zero, the <see cref="TextureViewHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="TextureViewHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    /// <param name="textureView">The texture view</param>
    [DllImport("webgpu_dawn", EntryPoint = "wgpuTextureViewRelease", CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextureViewRelease(TextureViewHandle textureView);
}
