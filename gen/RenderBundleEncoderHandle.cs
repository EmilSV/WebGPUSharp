using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct RenderBundleEncoderHandle : IEquatable<RenderBundleEncoderHandle>
{
    private readonly nuint _ptr;
    public static RenderBundleEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public RenderBundleEncoderHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(RenderBundleEncoderHandle handle) => handle._ptr;
    public static bool operator ==(RenderBundleEncoderHandle left, RenderBundleEncoderHandle right) => left._ptr == right._ptr;
    public static bool operator !=(RenderBundleEncoderHandle left, RenderBundleEncoderHandle right) => left._ptr != right._ptr;
    public static bool operator ==(RenderBundleEncoderHandle left, RenderBundleEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(RenderBundleEncoderHandle left, RenderBundleEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(RenderBundleEncoderHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(RenderBundleEncoderHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(RenderBundleEncoderHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is RenderBundleEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
