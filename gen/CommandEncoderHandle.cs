using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct CommandEncoderHandle : IEquatable<CommandEncoderHandle>
{
    private readonly nuint _ptr;
    public static CommandEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public CommandEncoderHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(CommandEncoderHandle handle) => handle._ptr;
    public static bool operator ==(CommandEncoderHandle left, CommandEncoderHandle right) => left._ptr == right._ptr;
    public static bool operator !=(CommandEncoderHandle left, CommandEncoderHandle right) => left._ptr != right._ptr;
    public static bool operator ==(CommandEncoderHandle left, CommandEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(CommandEncoderHandle left, CommandEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(CommandEncoderHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(CommandEncoderHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(CommandEncoderHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is CommandEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
