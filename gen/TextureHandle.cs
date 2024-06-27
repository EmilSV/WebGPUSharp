using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct TextureHandle : IEquatable<TextureHandle>
{
    private readonly nuint _ptr;
    public static TextureHandle Null
    {
        get => new(nuint.Zero);
    }

    public TextureHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(TextureHandle handle) => handle._ptr;
    public static bool operator ==(TextureHandle left, TextureHandle right) => left._ptr == right._ptr;
    public static bool operator !=(TextureHandle left, TextureHandle right) => left._ptr != right._ptr;
    public static bool operator ==(TextureHandle left, TextureHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(TextureHandle left, TextureHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(TextureHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(TextureHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(TextureHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is TextureHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
