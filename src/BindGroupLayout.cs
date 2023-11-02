using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class BindGroupLayout : BaseWebGpuSafeHandle<BindGroupLayout, BindGroupLayoutHandle>
{
    private BindGroupLayout(BindGroupLayoutHandle handle) : base(handle)
    {
    }

    internal static BindGroupLayout? FromHandle(
            BindGroupLayoutHandle handle, bool isOwnedHandle)
    {
        var newBindGroupLayout = WebGpuSafeHandleCache.GetOrCreate(
            handle, static (handle) => new BindGroupLayout(handle)
        );
        if (isOwnedHandle)
        {
            newBindGroupLayout?.AddReference(false);
        }
        return newBindGroupLayout;
    }

}