using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Adapter : WebGpuSafeHandle<AdapterHandle>
{
    private class CacheFactory :
        WebGpuSafeHandleCache<AdapterHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<AdapterHandle> Create(AdapterHandle handle)
        {
            return new Adapter(handle);
        }
    }


    private Adapter(AdapterHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.AdapterReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.AdapterReference(_handle);
    }


    internal static Adapter? FromHandle(AdapterHandle handle, bool incrementReferenceCount = true)
    {
        var newAdapter = WebGpuSafeHandleCache<AdapterHandle>.GetOrCreate<CacheFactory>(handle) as Adapter;
        if (incrementReferenceCount && newAdapter != null)
        {
            newAdapter.AddReference(false);
        }

        return newAdapter;
    }


    public nuint GetEnumerateFeaturesCount() => _handle.GetEnumerateFeaturesCount();
    public nuint EnumerateFeatures(Span<FeatureName> output) => _handle.EnumerateFeatures(output);
    public bool AdapterGetLimits(out SupportedLimits limits) => _handle.AdapterGetLimits(out limits);
    public SupportedLimits? AdapterGetLimits() => _handle.AdapterGetLimits();
    public void AdapterGetProperties(out AdapterProperties properties) => _handle.AdapterGetProperties(out properties);
    public AdapterProperties AdapterGetProperties() => _handle.AdapterGetProperties();
    public bool AdapterHasFeature(FeatureName feature) => _handle.AdapterHasFeature(feature);
    public Task<Device?> RequestDeviceAsync(in DeviceDescriptor descriptor)
    {
        return _handle.RequestDeviceAsync(descriptor).ContinueWith(static task => Device.FromHandle(task.Result));
    }
    public SupportedLimits GetLimits() => _handle.GetLimits();
    public void GetLimits(ref SupportedLimits limits) => _handle.GetLimits(ref limits);
}