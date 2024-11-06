using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class Buffer :
    BufferBase,
    IFromHandle<Buffer, BufferHandle>
{
    private readonly WebGpuSafeHandle<BufferHandle> _safeHandle;

    protected override BufferHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private Buffer(BufferHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<BufferHandle>(handle);
    }

    static Buffer? IFromHandle<Buffer, BufferHandle>.FromHandle(BufferHandle handle)
    {
        if (BufferHandle.IsNull(handle))
        {
            return null;
        }

        BufferHandle.Reference(handle);
        return new(handle);
    }

    static Buffer? IFromHandle<Buffer, BufferHandle>.FromHandleNoRefIncrement(BufferHandle handle)
    {
        if (BufferHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}