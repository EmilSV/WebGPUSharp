using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Adapter : BaseWebGpuSafeHandle<AdapterHandle>
{
    private Adapter(AdapterHandle handle) : base(handle)
    {
    }

    internal static Adapter? FromHandle(AdapterHandle handle, bool isOwnedHandle)
    {
        var newAdapter = WebGpuSafeHandleCache.GetOrCreate(
            handle,
            static (handle) => new Adapter(handle)
        );

        if (isOwnedHandle)
        {
            newAdapter?.AddReference(false);
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
    
    public Task<Device?> RequestDeviceAsync(in DeviceDescriptor descriptor) => 
        _handle.RequestDeviceAsync(descriptor).ContinueWith(static task => task.Result.ToSafeHandle(true));
    
    public SupportedLimits GetLimits() => _handle.GetLimits();
    public void GetLimits(ref SupportedLimits limits) => _handle.GetLimits(ref limits);
}