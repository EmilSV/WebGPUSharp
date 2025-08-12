using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="BindGroupHandle"/>
public sealed class BindGroup :
    WebGPUManagedHandleBase<BindGroupHandle>,
    IFromHandle<BindGroup, BindGroupHandle>
{
    private BindGroup(BindGroupHandle handle) : base(handle)
    {
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