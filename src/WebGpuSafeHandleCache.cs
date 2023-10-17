using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace WebGpuSharp.Internal;

internal static class WebGpuSafeHandleCache<T>
    where T : unmanaged, IWebGpuHandle<T>
{
    internal interface ISafeHandleFactory
    {
        static abstract WebGpuSafeHandle<T> Create(T handle);
    }

    private static readonly ConcurrentDictionary<T, GCHandle> _cache = new();

    public static WebGpuSafeHandle<T>? GetOrCreate<TFactory>(T handle)
        where TFactory : ISafeHandleFactory
    {
        if (T.IsNull(handle))
        {
            return null;
        }

        var gcHandle = _cache.GetOrAdd(
             handle,
             static (handle) => GCHandle.Alloc(TFactory.Create(handle), GCHandleType.Weak)
         );

        if (gcHandle.IsAllocated)
        {
            var safeHandle = (WebGpuSafeHandle<T>)gcHandle.Target!;
            if (safeHandle == null)
            {
                RemoveHandle(handle);
                return GetOrCreate<TFactory>(handle);
            }

            return safeHandle;
        }

        return null;
    }

    public static void RemoveHandle(T handle)
    {
        if (T.IsNull(handle))
        {
            return;
        }

        if (_cache.TryRemove(handle, out GCHandle gcHandle))
        {
            gcHandle.Free();
        }
    }
}