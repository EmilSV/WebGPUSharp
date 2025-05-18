using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc/>
public sealed class BindGroupLayout :
    BindGroupLayoutBase,
    IFromHandle<BindGroupLayout, BindGroupLayoutHandle>
{
    private readonly WebGpuSafeHandle<BindGroupLayoutHandle> _safeHandle;

    protected override BindGroupLayoutHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private BindGroupLayout(BindGroupLayoutHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<BindGroupLayoutHandle>(handle);
    }

    static BindGroupLayout? IFromHandle<BindGroupLayout, BindGroupLayoutHandle>.FromHandle(
        BindGroupLayoutHandle handle)
    {
        if (BindGroupLayoutHandle.IsNull(handle))
        {
            return null;
        }

        BindGroupLayoutHandle.Reference(handle);
        return new(handle);
    }

    static BindGroupLayout? IFromHandle<BindGroupLayout, BindGroupLayoutHandle>.FromHandleNoRefIncrement(
        BindGroupLayoutHandle handle)
    {
        if (BindGroupLayoutHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}