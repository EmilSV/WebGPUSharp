using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SharedFenceHandle : IEquatable<SharedFenceHandle>
{
	private readonly UIntPtr _ptr;
	public SharedFenceHandle(UIntPtr ptr) { _ptr = ptr; }
	public static SharedFenceHandle Null => new SharedFenceHandle(UIntPtr.Zero);
	public static explicit operator SharedFenceHandle(UIntPtr ptr) => new SharedFenceHandle(ptr);
	public static explicit operator UIntPtr(SharedFenceHandle handle) => handle._ptr;
	public static bool operator ==(SharedFenceHandle left, SharedFenceHandle right) => left._ptr == right._ptr;
	public static bool operator !=(SharedFenceHandle left, SharedFenceHandle right) => left._ptr != right._ptr;
	public static bool operator ==(SharedFenceHandle left, SharedFenceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(SharedFenceHandle left, SharedFenceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(SharedFenceHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(SharedFenceHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(SharedFenceHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is SharedFenceHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

