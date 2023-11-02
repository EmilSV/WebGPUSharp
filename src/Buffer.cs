using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class Buffer : BaseWebGpuSafeHandle<Buffer, BufferHandle>
{
    private Buffer(BufferHandle handle) : base(handle)
    {
    }
    public void MapAsync(
        MapMode mode,
        nuint offset,
        nuint size,
        Action<BufferMapAsyncStatus> callback)
    {
        _handle.MapAsync(mode, offset, size, callback);
    }

    public Task<BufferMapAsyncStatus> MapAsync(
        MapMode mode,
        nuint offset,
        nuint size)
    {
        return _handle.MapAsync(mode, offset, size);
    }

    internal static Buffer? FromHandle(BufferHandle handle, bool isOwnedHandle)
    {
        var newBuffer = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new Buffer(handle));
        if (isOwnedHandle)
        {
            newBuffer?.AddReference(false);
        }
        return newBuffer;
    }
}