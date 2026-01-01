using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;


/// <inheritdoc cref="AdapterHandle"/>
public sealed class Adapter :
    WebGPUManagedHandleBase<AdapterHandle>,
    IFromHandleWithInstance<Adapter, AdapterHandle>
{
    private readonly Instance _instance;

    private Adapter(AdapterHandle handle, Instance instance) : base(handle)
    {
        _instance = instance;
    }

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

    /// <inheritdoc cref="AdapterHandle.RequestDevice(in DeviceDescriptor)"/>
    public Task<Device> RequestDeviceAsync(in DeviceDescriptor descriptor) =>
        Handle.RequestDevice(descriptor).ContinueWith(static (task, state) => task.Result.ToSafeHandle((Instance)state!)!, _instance);

    /// <inheritdoc cref="AdapterHandle.RequestDevice()"/>
    public unsafe Task<Device> RequestDeviceAsync() =>
        Handle.RequestDevice().ContinueWith(static (task, state) => task.Result.ToSafeHandle((Instance)state!)!, _instance);

    /// <inheritdoc cref="AdapterHandle.RequestDevice(in DeviceDescriptor, Action{Device?})"/>
    public void RequestDevice(in DeviceDescriptor descriptor, Action<RequestDeviceStatus, Device?, ReadOnlySpan<byte>> callback) =>
        Handle.RequestDevice(descriptor, callback);

    static Adapter? IFromHandleWithInstance<Adapter, AdapterHandle>.FromHandle(AdapterHandle handle, Instance instance)
    {
        if (AdapterHandle.IsNull(handle))
        {
            return null;
        }

        AdapterHandle.Reference(handle);
        return new(handle, instance);
    }

    static Instance IFromHandleWithInstance<Adapter, AdapterHandle>.GetOwnerInstance(Adapter instance)
    {
        return instance._instance;
    }
}