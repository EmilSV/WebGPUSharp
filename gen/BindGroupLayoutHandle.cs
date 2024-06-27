using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct BindGroupLayoutHandle : IEquatable<BindGroupLayoutHandle>
{
    private readonly nuint _ptr;
    public static BindGroupLayoutHandle Null
    {
        get => new(nuint.Zero);
    }

    public BindGroupLayoutHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(BindGroupLayoutHandle handle) => handle._ptr;
    public static bool operator ==(BindGroupLayoutHandle left, BindGroupLayoutHandle right) => left._ptr == right._ptr;
    public static bool operator !=(BindGroupLayoutHandle left, BindGroupLayoutHandle right) => left._ptr != right._ptr;
    public static bool operator ==(BindGroupLayoutHandle left, BindGroupLayoutHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(BindGroupLayoutHandle left, BindGroupLayoutHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(BindGroupLayoutHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(BindGroupLayoutHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(BindGroupLayoutHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is BindGroupLayoutHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
