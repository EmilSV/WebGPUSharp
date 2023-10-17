using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct BufferHandle : IEquatable<BufferHandle>
{
	private readonly UIntPtr _ptr;
	public BufferHandle(UIntPtr ptr) { _ptr = ptr; }
	public static BufferHandle Null => new BufferHandle(UIntPtr.Zero);
	public static explicit operator BufferHandle(UIntPtr ptr) => new BufferHandle(ptr);
	public static explicit operator UIntPtr(BufferHandle handle) => handle._ptr;
	public static bool operator ==(BufferHandle left, BufferHandle right) => left._ptr == right._ptr;
	public static bool operator !=(BufferHandle left, BufferHandle right) => left._ptr != right._ptr;
	public static bool operator ==(BufferHandle left, BufferHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(BufferHandle left, BufferHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(BufferHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(BufferHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(BufferHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is BufferHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

