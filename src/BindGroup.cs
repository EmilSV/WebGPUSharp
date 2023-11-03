using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class BindGroup : BaseWebGpuSafeHandle<BindGroup, BindGroupHandle>
{
    private BindGroup(BindGroupHandle handle) : base(handle)
    {
    }

    internal static BindGroup? FromHandle(BindGroupHandle handle, bool isOwnedHandle)
    {
        var newBindGroup = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new BindGroup(handle));
        if (isOwnedHandle)
        {
            newBindGroup?.AddReference(false);
        }
        return newBindGroup;
    }
}