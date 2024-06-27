using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SharedFenceHandle : IEquatable<SharedFenceHandle>
{
    private readonly nuint _ptr;
    public static SharedFenceHandle Null
    {
        get => new(nuint.Zero);
    }

    public SharedFenceHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(SharedFenceHandle handle) => handle._ptr;
    public static bool operator ==(SharedFenceHandle left, SharedFenceHandle right) => left._ptr == right._ptr;
    public static bool operator !=(SharedFenceHandle left, SharedFenceHandle right) => left._ptr != right._ptr;
    public static bool operator ==(SharedFenceHandle left, SharedFenceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(SharedFenceHandle left, SharedFenceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(SharedFenceHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(SharedFenceHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(SharedFenceHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is SharedFenceHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
