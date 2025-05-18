using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="AdapterHandle"/>
public abstract class AdapterBase : WebGPUHandleWrapperBase<AdapterHandle>
{
    /// <inheritdoc cref="AdapterHandle.GetInfo()"/>
    public AdapterInfo GetInfo() => Handle.GetInfo()!;

    /// <inheritdoc cref="AdapterHandle.GetLimits(out Limits)"/>
    public bool GetLimits(out Limits limits) => Handle.GetLimits(out limits);

    /// <inheritdoc cref="AdapterHandle.GetLimits()"/>
    public Limits? GetLimits() => Handle.GetLimits();

    /// <inheritdoc cref="AdapterHandle.GetFeatures()"/>
    public FeatureName[] GetFeatures() => Handle.GetFeatures();

    /// <inheritdoc cref="AdapterHandle.HasFeature(FeatureName)"/>
    public bool HasFeature(FeatureName feature) => Handle.HasFeature(feature);

    /// <inheritdoc cref="AdapterHandle.RequestDeviceAsync(in DeviceDescriptor)"/>
    public Task<Device?> RequestDeviceAsync(in DeviceDescriptor descriptor) =>
        Handle.RequestDeviceAsync(descriptor).ContinueWith(static task => task.Result.ToSafeHandle(false));

    /// <inheritdoc cref="AdapterHandle.RequestDeviceAsync(in DeviceDescriptor, Action{Device?})"/>
    public void RequestDeviceAsync(in DeviceDescriptor descriptor, Action<Device?> callback) =>
        Handle.RequestDeviceAsync(descriptor, callback);
}