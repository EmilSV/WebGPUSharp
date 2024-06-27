using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct ExternalTextureHandle : IEquatable<ExternalTextureHandle>
{
    private readonly nuint _ptr;
    public static ExternalTextureHandle Null
    {
        get => new(nuint.Zero);
    }

    public ExternalTextureHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(ExternalTextureHandle handle) => handle._ptr;
    public static bool operator ==(ExternalTextureHandle left, ExternalTextureHandle right) => left._ptr == right._ptr;
    public static bool operator !=(ExternalTextureHandle left, ExternalTextureHandle right) => left._ptr != right._ptr;
    public static bool operator ==(ExternalTextureHandle left, ExternalTextureHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(ExternalTextureHandle left, ExternalTextureHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(ExternalTextureHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(ExternalTextureHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(ExternalTextureHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is ExternalTextureHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
