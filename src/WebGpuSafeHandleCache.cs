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

        var gcHandle = Cache<THandle>._cache.GetOrAdd(
             handle,
           static (THandle handle, Func<THandle, TSafeHandle> createFunc) =>
                {
                    return GCHandle.Alloc(createFunc(handle), GCHandleType.Weak);
                },
            createFunc
         );

        if (gcHandle.IsAllocated)
        {
            var safeHandle = (TSafeHandle)gcHandle.Target!;
            if (safeHandle == null)
            {
                RemoveHandle(handle);
                return GetOrCreate(handle, createFunc);
            }

            return safeHandle;
        }

        return null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void RemoveHandle<THandle>(THandle handle)
      where THandle : unmanaged, IWebGpuHandle<THandle>
    {
        if (THandle.IsNull(handle))
        {
            return;
        }

        if (Cache<THandle>._cache.TryRemove(handle, out GCHandle gcHandle))
        {
            gcHandle.Free();
        }
    }
}