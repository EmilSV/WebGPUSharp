using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A TextureView is a view onto some subset of the <see href="https://gpuweb.github.io/gpuweb/#texture-subresources"> texture subresources</see>
/// defined by a particular <see cref="Texture" />.
/// </summary>
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

    /// <summary>
    /// Set the label of the texture view.
    /// </summary>
    /// <param name="label">The label to set.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.TextureViewSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.TextureViewAddRef(this);

    public void Release() => WebGPU_FFI.TextureViewRelease(this);

}
