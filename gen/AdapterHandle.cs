using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct AdapterHandle : IEquatable<AdapterHandle>
{
    private readonly nuint _ptr;
    public static AdapterHandle Null
    {
        get => new(nuint.Zero);
    }

    public AdapterHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(AdapterHandle handle) => handle._ptr;
    public static bool operator ==(AdapterHandle left, AdapterHandle right) => left._ptr == right._ptr;
    public static bool operator !=(AdapterHandle left, AdapterHandle right) => left._ptr != right._ptr;
    public static bool operator ==(AdapterHandle left, AdapterHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(AdapterHandle left, AdapterHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(AdapterHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(AdapterHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(AdapterHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is AdapterHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
