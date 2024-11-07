using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Device :
    DeviceBase,
    IFromHandle<Device, DeviceHandle>
{
    private readonly WebGpuSafeHandle<DeviceHandle> _safeHandle;

    protected override DeviceHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private Device(DeviceHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<DeviceHandle>(handle);
    }

    static Device? IFromHandle<Device, DeviceHandle>.FromHandle(
        DeviceHandle handle)
    {
        if (DeviceHandle.IsNull(handle))
        {
            return null;
        }

        DeviceHandle.Reference(handle);
        return new(handle);
    }

    static Device? IFromHandle<Device, DeviceHandle>.FromHandleNoRefIncrement(
        DeviceHandle handle)
    {
        if (DeviceHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}