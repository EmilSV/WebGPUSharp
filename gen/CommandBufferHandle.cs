using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct CommandBufferHandle : IEquatable<CommandBufferHandle>
{
    private readonly nuint _ptr;
    public static CommandBufferHandle Null
    {
        get => new(nuint.Zero);
    }

    public CommandBufferHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(CommandBufferHandle handle) => handle._ptr;
    public static bool operator ==(CommandBufferHandle left, CommandBufferHandle right) => left._ptr == right._ptr;
    public static bool operator !=(CommandBufferHandle left, CommandBufferHandle right) => left._ptr != right._ptr;
    public static bool operator ==(CommandBufferHandle left, CommandBufferHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(CommandBufferHandle left, CommandBufferHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(CommandBufferHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(CommandBufferHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(CommandBufferHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is CommandBufferHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
