using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

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
}