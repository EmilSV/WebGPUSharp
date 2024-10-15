using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Adapter : BaseWebGpuSafeHandle<Adapter, AdapterHandle>
{
    private Adapter(AdapterHandle handle) : base(handle)
    {
    }

    internal static Adapter? FromHandle(AdapterHandle handle, bool isOwnedHandle)
    {
        var newAdapter = WebGpuSafeHandleCache.GetOrCreate(
            handle: handle,
            createFunc: static (handle) => new Adapter(handle)
        );

        if (isOwnedHandle)
        {
            newAdapter?.AddReference(false);
        }
        return newAdapter;
    }

    public nuint GetEnumerateFeaturesCount() => _handle.GetEnumerateFeaturesCount();
    public nuint EnumerateFeatures(Span<FeatureName> output) => _handle.EnumerateFeatures(output);
    public FeatureName[] GetFeatures() => _handle.GetFeatures();

    public bool GetLimits(out SupportedLimits limits) => _handle.GetLimits(out limits);
    public SupportedLimits? GetLimits() => _handle.GetLimits();

    public bool HasFeature(FeatureName feature) => _handle.HasFeature(feature);

    public Task<Device?> RequestDeviceAsync(in DeviceDescriptor descriptor) =>
        _handle.RequestDeviceAsync(descriptor).ContinueWith(static task => task.Result.ToSafeHandle(true));

    public void RequestDeviceAsync(in DeviceDescriptor descriptor, Action<Device?> callback) =>
        _handle.RequestDeviceAsync(descriptor, callback);
}