using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;


/// <inheritdoc cref="AdapterHandle"/>
public sealed class Adapter :
    WebGPUManagedHandleBase<AdapterHandle>,
    IFromHandle<Adapter, AdapterHandle>
{
    private Adapter(AdapterHandle handle) : base(handle)
    {
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

    /// <inheritdoc cref="AdapterHandle.RequestDeviceAsync(in DeviceDescriptor)"/>
    public Task<Device?> RequestDeviceAsync(in DeviceDescriptor descriptor) =>
        Handle.RequestDeviceAsync(descriptor).ContinueWith(static task => task.Result.ToSafeHandle(incrementRefCount: false));

    /// <inheritdoc cref="AdapterHandle.RequestDeviceAsync(in DeviceDescriptor, Action{Device?})"/>
    public void RequestDeviceAsync(in DeviceDescriptor descriptor, Action<Device?> callback) =>
        Handle.RequestDeviceAsync(descriptor, callback);


    static Adapter? IFromHandle<Adapter, AdapterHandle>.FromHandle(
        AdapterHandle handle)
    {
        if (AdapterHandle.IsNull(handle))
        {
            return null;
        }

        AdapterHandle.Reference(handle);
        return new(handle);
    }

    static Adapter? IFromHandle<Adapter, AdapterHandle>.FromHandleNoRefIncrement(
        AdapterHandle handle)
    {
        if (AdapterHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}