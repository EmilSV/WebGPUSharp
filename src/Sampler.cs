using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Sampler : WebGpuSafeHandle<SamplerHandle>
{
    private class CacheFactory :
        WebGpuSafeHandleCache<SamplerHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<SamplerHandle> Create(SamplerHandle handle)
        {
            return new Sampler(handle);
        }
    }

    private Sampler(SamplerHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.SamplerReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.SamplerRelease(_handle);
    }


    internal static Sampler? FromHandle(SamplerHandle handle, bool incrementReferenceCount = true)
    {
        var newSampler = WebGpuSafeHandleCache<SamplerHandle>.GetOrCreate<CacheFactory>(handle) as Sampler;
        if (newSampler != null && incrementReferenceCount)
        {
            newSampler.AddReference(false);
        }
        return newSampler;
    }
}