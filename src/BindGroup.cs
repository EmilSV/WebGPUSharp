using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class BindGroup : BaseWebGpuSafeHandle<BindGroupHandle>
{
    private BindGroup(BindGroupHandle handle) : base(handle)
    {
    }

    internal static BindGroup? FromHandle(BindGroupHandle handle, bool incrementReferenceCount)
    {
        var newBindGroup = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new BindGroup(handle));
        newBindGroup?.AddReference(incrementReferenceCount);
        return newBindGroup;
    }
}