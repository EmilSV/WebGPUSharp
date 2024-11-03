using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public sealed class WebGpuSafeHandle<THandle> : WebGpuSafeHandle
    where THandle : unmanaged, IWebGpuHandle<THandle>
{
    private THandle _handle;

    public WebGpuSafeHandle(THandle handle)
    {
        _handle = handle;
        IncrementTotalActiveHandles();
        WebGpuSafeHandleCountStore<THandle>.IncrementActiveHandles();
    }

    public THandle Handle
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _handle;
    }

    ~WebGpuSafeHandle()
    {
        TryDispose();
    }

    private bool TryDispose()
    {
        var handleValue = Interlocked.Exchange(ref THandle.AsPointer(ref _handle), UIntPtr.Zero);
        if (handleValue != UIntPtr.Zero)
        {
            THandle.Release(_handle);
            DecrementTotalActiveHandles();
            WebGpuSafeHandleCountStore<THandle>.DecrementActiveHandles();
            return true;
        }

        return false;
    }

    public override void Dispose()
    {
        if (TryDispose())
        {
            GC.SuppressFinalize(this);
        }
    }
}

public abstract class WebGpuSafeHandle : IDisposable
{

    protected static class WebGpuSafeHandleCountStore<THandle>
    {
        private static ulong _totalActiveHandles = 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong GetActiveHandles() => _totalActiveHandles;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IncrementActiveHandles() => Interlocked.Increment(ref _totalActiveHandles);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DecrementActiveHandles() => Interlocked.Decrement(ref _totalActiveHandles);
    }

    private static ulong _totalActiveHandles = 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong GetTotalActiveHandles() => _totalActiveHandles;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong GetActiveHandles<THandle>()
            where THandle : unmanaged, IWebGpuHandle<THandle>
            => WebGpuSafeHandleCountStore<THandle>.GetActiveHandles();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected static void IncrementTotalActiveHandles() => Interlocked.Increment(ref _totalActiveHandles);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected static void DecrementTotalActiveHandles() => Interlocked.Decrement(ref _totalActiveHandles);

    internal WebGpuSafeHandle() { }
    public abstract void Dispose();
}