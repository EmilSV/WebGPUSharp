using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class AdapterBase : WebGPUHandleWrapperBase<AdapterHandle>
{

    public AdapterInfo GetInfo() => Handle.GetInfo()!;
    public bool GetLimits(out SupportedLimits limits) => Handle.GetLimits(out limits);
    public SupportedLimits? GetLimits() => Handle.GetLimits();

    public FeatureName[] GetFeatures() => Handle.GetFeatures();
    public bool HasFeature(FeatureName feature) => Handle.HasFeature(feature);

    public Task<Device> RequestDeviceAsync(in DeviceDescriptor descriptor) =>
        Handle.RequestDeviceAsync(descriptor).ContinueWith(static task => task.Result.ToSafeHandle(false)!);

    public void RequestDeviceAsync(in DeviceDescriptor descriptor, Action<Device> callback) =>
        Handle.RequestDeviceAsync(descriptor, callback!);
}