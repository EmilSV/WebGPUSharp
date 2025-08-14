using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="BindGroupLayoutHandle"/>
public sealed class BindGroupLayout :
    WebGPUManagedHandleBase<BindGroupLayoutHandle>,
    IFromHandle<BindGroupLayout, BindGroupLayoutHandle>
{
    private BindGroupLayout(BindGroupLayoutHandle handle) : base(handle)
    {
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