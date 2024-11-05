using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Instance :
    InstanceBase,
    IFromHandle<Instance, InstanceHandle>
{
    private readonly WebGpuSafeHandle<InstanceHandle> _safeHandle;

    protected override InstanceHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private Instance(InstanceHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<InstanceHandle>(handle);
    }

    static Instance? IFromHandle<Instance, InstanceHandle>.FromHandle(InstanceHandle handle)
    {
        if (InstanceHandle.IsNull(handle))
        {
            return null;
        }

        InstanceHandle.Reference(handle);
        return new(handle);
    }

    static Instance? IFromHandle<Instance, InstanceHandle>.FromHandleNoRefIncrement(InstanceHandle handle)
    {
        if (InstanceHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}