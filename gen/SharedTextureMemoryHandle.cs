using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SharedTextureMemoryHandle : IEquatable<SharedTextureMemoryHandle>
{
    private readonly nuint _ptr;
    public static SharedTextureMemoryHandle Null
    {
        get => new(nuint.Zero);
    }

    public SharedTextureMemoryHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(SharedTextureMemoryHandle handle) => handle._ptr;
    public static bool operator ==(SharedTextureMemoryHandle left, SharedTextureMemoryHandle right) => left._ptr == right._ptr;
    public static bool operator !=(SharedTextureMemoryHandle left, SharedTextureMemoryHandle right) => left._ptr != right._ptr;
    public static bool operator ==(SharedTextureMemoryHandle left, SharedTextureMemoryHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(SharedTextureMemoryHandle left, SharedTextureMemoryHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(SharedTextureMemoryHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(SharedTextureMemoryHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(SharedTextureMemoryHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is SharedTextureMemoryHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
