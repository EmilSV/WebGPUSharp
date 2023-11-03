using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Sampler : BaseWebGpuSafeHandle<Sampler, SamplerHandle>
{
    private Sampler(SamplerHandle handle) : base(handle)
    {
    }

    internal static Sampler? FromHandle(SamplerHandle handle, bool isOwnedHandle)
    {
        var newSampler = WebGpuSafeHandleCache.GetOrCreate(handle, static handle => new Sampler(handle));
        if (isOwnedHandle)
        {
            newSampler?.AddReference(false);
        }
        return newSampler;
    }
}