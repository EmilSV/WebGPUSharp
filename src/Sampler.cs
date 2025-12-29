using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="SamplerHandle"/>
public unsafe sealed class Sampler :
    WebGPUManagedHandleBase<SamplerHandle>,
    IFromHandle<Sampler, SamplerHandle>
{
    private Sampler(SamplerHandle handle) : base(handle)
    {
    }


    static Sampler? IFromHandle<Sampler, SamplerHandle>.FromHandle(
        SamplerHandle handle)
    {
        if (SamplerHandle.IsNull(handle))
        {
            return null;
        }

        SamplerHandle.Reference(handle);
        return new(handle);
    }
}