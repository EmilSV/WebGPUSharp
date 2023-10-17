using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class Buffer : WebGpuSafeHandle<BufferHandle>
{
    private class CacheFactory :
        WebGpuSafeHandleCache<BufferHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<BufferHandle> Create(BufferHandle handle)
        {
            return new Buffer(handle);
        }
    }

    private Buffer(BufferHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.BufferReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.BufferRelease(_handle);
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

    internal static Buffer? FromHandle(BufferHandle handle)
    {
        return WebGpuSafeHandleCache<BufferHandle>.GetOrCreate<CacheFactory>(handle) as Buffer;
    }
}