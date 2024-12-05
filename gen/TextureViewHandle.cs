using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct TextureViewHandle : IEquatable<TextureViewHandle>
{
    private readonly nuint _ptr;
    public static TextureViewHandle Null
    {
        get => new(nuint.Zero);
    }

    public TextureViewHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(TextureViewHandle handle) => handle._ptr;

    public static bool operator ==(TextureViewHandle left, TextureViewHandle right) => left._ptr == right._ptr;

    public static bool operator !=(TextureViewHandle left, TextureViewHandle right) => left._ptr != right._ptr;

    public static bool operator ==(TextureViewHandle left, TextureViewHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(TextureViewHandle left, TextureViewHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(TextureViewHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(TextureViewHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(TextureViewHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is TextureViewHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.TextureViewSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.TextureViewAddRef(this);

    public void Release() => WebGPU_FFI.TextureViewRelease(this);

}
