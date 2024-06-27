using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct InstanceHandle : IEquatable<InstanceHandle>
{
    private readonly nuint _ptr;
    public static InstanceHandle Null
    {
        get => new(nuint.Zero);
    }

    public InstanceHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(InstanceHandle handle) => handle._ptr;
    public static bool operator ==(InstanceHandle left, InstanceHandle right) => left._ptr == right._ptr;
    public static bool operator !=(InstanceHandle left, InstanceHandle right) => left._ptr != right._ptr;
    public static bool operator ==(InstanceHandle left, InstanceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(InstanceHandle left, InstanceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(InstanceHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(InstanceHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(InstanceHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is InstanceHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
