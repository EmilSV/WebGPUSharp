using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct CommandBufferHandle : IEquatable<CommandBufferHandle>
{
	private readonly UIntPtr _ptr;
	public CommandBufferHandle(UIntPtr ptr) { _ptr = ptr; }
	public static CommandBufferHandle Null => new CommandBufferHandle(UIntPtr.Zero);
	public static explicit operator CommandBufferHandle(UIntPtr ptr) => new CommandBufferHandle(ptr);
	public static explicit operator UIntPtr(CommandBufferHandle handle) => handle._ptr;
	public static bool operator ==(CommandBufferHandle left, CommandBufferHandle right) => left._ptr == right._ptr;
	public static bool operator !=(CommandBufferHandle left, CommandBufferHandle right) => left._ptr != right._ptr;
	public static bool operator ==(CommandBufferHandle left, CommandBufferHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(CommandBufferHandle left, CommandBufferHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(CommandBufferHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(CommandBufferHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(CommandBufferHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is CommandBufferHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

