using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc/>
public unsafe sealed class Sampler :
    SamplerBase,
    IFromHandle<Sampler, SamplerHandle>
{
    private readonly WebGpuSafeHandle<SamplerHandle> _safeHandle;

    protected override SamplerHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private Sampler(SamplerHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<SamplerHandle>(handle);
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

    static Sampler? IFromHandle<Sampler, SamplerHandle>.FromHandleNoRefIncrement(
        SamplerHandle handle)
    {
        if (SamplerHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}