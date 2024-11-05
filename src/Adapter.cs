using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Adapter :
    AdapterBase,
    IFromHandle<Adapter, AdapterHandle>
{
    private readonly WebGpuSafeHandle<AdapterHandle> _safeHandle;

    private Adapter(AdapterHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<AdapterHandle>(handle);
    }

    protected override AdapterHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

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