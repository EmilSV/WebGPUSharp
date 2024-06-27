using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct ComputePassEncoderHandle : IEquatable<ComputePassEncoderHandle>
{
    private readonly nuint _ptr;
    public static ComputePassEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public ComputePassEncoderHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(ComputePassEncoderHandle handle) => handle._ptr;
    public static bool operator ==(ComputePassEncoderHandle left, ComputePassEncoderHandle right) => left._ptr == right._ptr;
    public static bool operator !=(ComputePassEncoderHandle left, ComputePassEncoderHandle right) => left._ptr != right._ptr;
    public static bool operator ==(ComputePassEncoderHandle left, ComputePassEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(ComputePassEncoderHandle left, ComputePassEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(ComputePassEncoderHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(ComputePassEncoderHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(ComputePassEncoderHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is ComputePassEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
