using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

internal static class WebGpuSafeHandleCache
{
    private static class Cache<THandle>
        where THandle : unmanaged
    {
        public static readonly ConcurrentDictionary<THandle, GCHandle> _cache = new();
        public static readonly ReaderWriterLockSlim _cacheLock = new();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe static TSafeHandle? GetOrCreate<THandle, TSafeHandle>(
        THandle handle, Func<THandle, TSafeHandle> createFunc)
        where TSafeHandle : class
        where THandle : unmanaged, IWebGpuHandle<THandle>
    {
        if (THandle.IsNull(handle))
        {
            return null;
        }

        Cache<THandle>._cacheLock.EnterReadLock();
        var gcHandle = Cache<THandle>._cache.GetOrAdd(
             handle,
           static (THandle handle, Func<THandle, TSafeHandle> createFunc) =>
                {
                    return GCHandle.Alloc(createFunc(handle), GCHandleType.Weak);
                },
            createFunc
         );

        TSafeHandle? safeHandle = null;
        bool isAllocated = gcHandle.IsAllocated;
        if (isAllocated)
        {
            safeHandle = (TSafeHandle)gcHandle.Target!;
        }
        Cache<THandle>._cacheLock.ExitReadLock();

        if (isAllocated && safeHandle == null)
        {
            RemoveHandle(handle);
            return GetOrCreate(handle, createFunc);
        }

        return safeHandle;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void RemoveHandle<THandle>(THandle handle)
      where THandle : unmanaged, IWebGpuHandle<THandle>
    {
        if (THandle.IsNull(handle))
        {
            return;
        }

        Cache<THandle>._cacheLock.EnterWriteLock();
        if (Cache<THandle>._cache.TryRemove(handle, out GCHandle gcHandle))
        {
            gcHandle.Free();
        }
        Cache<THandle>._cacheLock.ExitWriteLock();
    }
}