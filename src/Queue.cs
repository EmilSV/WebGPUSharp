using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Queue :
    QueueBase,
    IFromHandle<Queue, QueueHandle>
{
    private readonly WebGpuSafeHandle<QueueHandle> _safeHandle;

    protected override QueueHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private Queue(QueueHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<QueueHandle>(handle);
    }

    static Queue? IFromHandle<Queue, QueueHandle>.FromHandle(
        QueueHandle handle)
    {
        if (QueueHandle.IsNull(handle))
        {
            return null;
        }

        QueueHandle.Reference(handle);
        return new(handle);
    }

    static Queue? IFromHandle<Queue, QueueHandle>.FromHandleNoRefIncrement(
        QueueHandle handle)
    {
        if (QueueHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}