using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SharedBufferMemoryHandle : IEquatable<SharedBufferMemoryHandle>
{
    private readonly nuint _ptr;
    public static SharedBufferMemoryHandle Null
    {
        get => new(nuint.Zero);
    }

    public SharedBufferMemoryHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(SharedBufferMemoryHandle handle) => handle._ptr;
    public static bool operator ==(SharedBufferMemoryHandle left, SharedBufferMemoryHandle right) => left._ptr == right._ptr;
    public static bool operator !=(SharedBufferMemoryHandle left, SharedBufferMemoryHandle right) => left._ptr != right._ptr;
    public static bool operator ==(SharedBufferMemoryHandle left, SharedBufferMemoryHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(SharedBufferMemoryHandle left, SharedBufferMemoryHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(SharedBufferMemoryHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(SharedBufferMemoryHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(SharedBufferMemoryHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is SharedBufferMemoryHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
