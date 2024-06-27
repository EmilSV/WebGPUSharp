using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SamplerHandle : IEquatable<SamplerHandle>
{
    private readonly nuint _ptr;
    public static SamplerHandle Null
    {
        get => new(nuint.Zero);
    }

    public SamplerHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(SamplerHandle handle) => handle._ptr;
    public static bool operator ==(SamplerHandle left, SamplerHandle right) => left._ptr == right._ptr;
    public static bool operator !=(SamplerHandle left, SamplerHandle right) => left._ptr != right._ptr;
    public static bool operator ==(SamplerHandle left, SamplerHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(SamplerHandle left, SamplerHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(SamplerHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(SamplerHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(SamplerHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is SamplerHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
