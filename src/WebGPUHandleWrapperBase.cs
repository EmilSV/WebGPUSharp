using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public abstract class WebGPUManagedHandleBase<THandle> :
    IEquatable<WebGPUManagedHandleBase<THandle>>,
    IEquatable<THandle>
    where THandle : unmanaged, IEquatable<THandle>, IWebGpuHandle<THandle>
{
    private readonly WebGpuSafeHandle<THandle> _safeHandle;

    protected THandle Handle
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _safeHandle.Handle;
    }

    protected WebGPUManagedHandleBase(THandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<THandle>(handle);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal THandle GetHandle()
    {
        return _safeHandle.Handle;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(WebGPUManagedHandleBase<THandle>? other)
    {
        return other != null && Handle.Equals(other.Handle);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(THandle other)
    {
        return Handle.Equals(other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WebGPUManagedHandleBase<THandle>? left, WebGPUManagedHandleBase<THandle>? right) =>
        ReferenceEquals(left, right) || (left?.Equals(right) ?? false);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WebGPUManagedHandleBase<THandle>? left, WebGPUManagedHandleBase<THandle>? right) =>
        !(left == right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
    {
        if (obj is WebGPUManagedHandleBase<THandle> other)
        {
            return Equals(other);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Handle.GetHashCode();
    }
}
