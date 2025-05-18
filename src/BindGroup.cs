using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc/>
public sealed class BindGroup :
    BindGroupBase,
    IFromHandle<BindGroup, BindGroupHandle>
{
    private readonly WebGpuSafeHandle<BindGroupHandle> _safeHandle;

    protected override BindGroupHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private BindGroup(BindGroupHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<BindGroupHandle>(handle);
    }

    static BindGroup? IFromHandle<BindGroup, BindGroupHandle>.FromHandle(
        BindGroupHandle handle)
    {
        if (BindGroupHandle.IsNull(handle))
        {
            return null;
        }

        BindGroupHandle.Reference(handle);
        return new(handle);
    }

    static BindGroup? IFromHandle<BindGroup, BindGroupHandle>.FromHandleNoRefIncrement(
        BindGroupHandle handle)
    {
        if (BindGroupHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}