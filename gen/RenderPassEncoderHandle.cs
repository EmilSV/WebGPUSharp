using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct RenderPassEncoderHandle : IEquatable<RenderPassEncoderHandle>
{
    private readonly nuint _ptr;
    public static RenderPassEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public RenderPassEncoderHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(RenderPassEncoderHandle handle) => handle._ptr;
    public static bool operator ==(RenderPassEncoderHandle left, RenderPassEncoderHandle right) => left._ptr == right._ptr;
    public static bool operator !=(RenderPassEncoderHandle left, RenderPassEncoderHandle right) => left._ptr != right._ptr;
    public static bool operator ==(RenderPassEncoderHandle left, RenderPassEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(RenderPassEncoderHandle left, RenderPassEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(RenderPassEncoderHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(RenderPassEncoderHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(RenderPassEncoderHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is RenderPassEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
