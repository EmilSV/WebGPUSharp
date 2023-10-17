using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SharedTextureMemoryHandle : IEquatable<SharedTextureMemoryHandle>
{
	private readonly UIntPtr _ptr;
	public SharedTextureMemoryHandle(UIntPtr ptr) { _ptr = ptr; }
	public static SharedTextureMemoryHandle Null => new SharedTextureMemoryHandle(UIntPtr.Zero);
	public static explicit operator SharedTextureMemoryHandle(UIntPtr ptr) => new SharedTextureMemoryHandle(ptr);
	public static explicit operator UIntPtr(SharedTextureMemoryHandle handle) => handle._ptr;
	public static bool operator ==(SharedTextureMemoryHandle left, SharedTextureMemoryHandle right) => left._ptr == right._ptr;
	public static bool operator !=(SharedTextureMemoryHandle left, SharedTextureMemoryHandle right) => left._ptr != right._ptr;
	public static bool operator ==(SharedTextureMemoryHandle left, SharedTextureMemoryHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(SharedTextureMemoryHandle left, SharedTextureMemoryHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(SharedTextureMemoryHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(SharedTextureMemoryHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(SharedTextureMemoryHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is SharedTextureMemoryHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

