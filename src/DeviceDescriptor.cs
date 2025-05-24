namespace WebGpuSharp;

/// <inheritdoc cref="FFI.DeviceDescriptorFFI"/>
public ref partial struct DeviceDescriptor
{
    public DeviceDescriptor() { }

    /// <inheritdoc cref="FFI.DeviceDescriptorFFI.Label"/>
    public WGPURefText Label;
    /// <inheritdoc cref="FFI.DeviceDescriptorFFI.RequiredFeatures"/>
    public Span<FeatureName> RequiredFeatures;
    /// <inheritdoc cref="FFI.DeviceDescriptorFFI.RequiredLimits"/>
    public WGPUNullableRef<Limits> RequiredLimits;
    /// <inheritdoc cref="FFI.DeviceDescriptorFFI.DefaultQueue"/>
    public QueueDescriptor DefaultQueue;

    public CallbackMode DeviceLostCallbackMode = CallbackMode.AllowProcessEvents;

    /// <inheritdoc cref="FFI.DeviceDescriptorFFI.DeviceLostCallbackInfo"/>
    public Action<DeviceLostReason, ReadOnlySpan<byte>>? DeviceLostCallback;
    /// <inheritdoc cref="FFI.DeviceDescriptorFFI.UncapturedErrorCallbackInfo"/>
    public Action<ErrorType, ReadOnlySpan<byte>>? UncapturedErrorCallback;
}