using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct CommandEncoderHandle : IEquatable<CommandEncoderHandle>
{
	private readonly UIntPtr _ptr;
	public CommandEncoderHandle(UIntPtr ptr) { _ptr = ptr; }
	public static CommandEncoderHandle Null => new CommandEncoderHandle(UIntPtr.Zero);
	public static explicit operator CommandEncoderHandle(UIntPtr ptr) => new CommandEncoderHandle(ptr);
	public static explicit operator UIntPtr(CommandEncoderHandle handle) => handle._ptr;
	public static bool operator ==(CommandEncoderHandle left, CommandEncoderHandle right) => left._ptr == right._ptr;
	public static bool operator !=(CommandEncoderHandle left, CommandEncoderHandle right) => left._ptr != right._ptr;
	public static bool operator ==(CommandEncoderHandle left, CommandEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(CommandEncoderHandle left, CommandEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(CommandEncoderHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(CommandEncoderHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(CommandEncoderHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is CommandEncoderHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

