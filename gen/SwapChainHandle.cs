using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SwapChainHandle : IEquatable<SwapChainHandle>
{
    private readonly nuint _ptr;
    public static SwapChainHandle Null
    {
        get => new(nuint.Zero);
    }

    public SwapChainHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(SwapChainHandle handle) => handle._ptr;
    public static bool operator ==(SwapChainHandle left, SwapChainHandle right) => left._ptr == right._ptr;
    public static bool operator !=(SwapChainHandle left, SwapChainHandle right) => left._ptr != right._ptr;
    public static bool operator ==(SwapChainHandle left, SwapChainHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(SwapChainHandle left, SwapChainHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(SwapChainHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(SwapChainHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(SwapChainHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is SwapChainHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
