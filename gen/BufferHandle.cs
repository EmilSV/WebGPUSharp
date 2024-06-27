using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct BufferHandle : IEquatable<BufferHandle>
{
    private readonly nuint _ptr;
    public static BufferHandle Null
    {
        get => new(nuint.Zero);
    }

    public BufferHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(BufferHandle handle) => handle._ptr;
    public static bool operator ==(BufferHandle left, BufferHandle right) => left._ptr == right._ptr;
    public static bool operator !=(BufferHandle left, BufferHandle right) => left._ptr != right._ptr;
    public static bool operator ==(BufferHandle left, BufferHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(BufferHandle left, BufferHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(BufferHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(BufferHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(BufferHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is BufferHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
