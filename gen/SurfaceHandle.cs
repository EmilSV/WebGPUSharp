using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SurfaceHandle : IEquatable<SurfaceHandle>
{
    private readonly nuint _ptr;
    public static SurfaceHandle Null
    {
        get => new(nuint.Zero);
    }

    public SurfaceHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(SurfaceHandle handle) => handle._ptr;
    public static bool operator ==(SurfaceHandle left, SurfaceHandle right) => left._ptr == right._ptr;
    public static bool operator !=(SurfaceHandle left, SurfaceHandle right) => left._ptr != right._ptr;
    public static bool operator ==(SurfaceHandle left, SurfaceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(SurfaceHandle left, SurfaceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(SurfaceHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(SurfaceHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(SurfaceHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is SurfaceHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
