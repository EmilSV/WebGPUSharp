using System.Runtime.CompilerServices;

namespace WebGpuSharp.Internal;

public abstract class WebGPUHandleWrapperBase<THandle> :
    IEquatable<WebGPUHandleWrapperBase<THandle>>,
    IEquatable<THandle>
    where THandle : unmanaged, IEquatable<THandle>
{
    protected abstract THandle Handle { get; }
    protected abstract bool HandleWrapperSameLifetime { get; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsHandleWrapperSameLifetime(WebGPUHandleWrapperBase<THandle> handleWrapper)
    {
        return handleWrapper.HandleWrapperSameLifetime;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static THandle GetHandle(WebGPUHandleWrapperBase<THandle> handleWrapper)
    {
        return handleWrapper.Handle;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(WebGPUHandleWrapperBase<THandle>? other)
    {
        return other != null && Handle.Equals(other.Handle);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(THandle other)
    {
        return Handle.Equals(other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WebGPUHandleWrapperBase<THandle>? left, WebGPUHandleWrapperBase<THandle>? right) =>
        ReferenceEquals(left, right) || (left?.Equals(right) ?? false);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WebGPUHandleWrapperBase<THandle>? left, WebGPUHandleWrapperBase<THandle>? right) =>
        !(left == right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
    {
        if (obj is WebGPUHandleWrapperBase<THandle> other)
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
