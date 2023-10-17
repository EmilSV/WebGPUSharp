using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct InstanceHandle : IEquatable<InstanceHandle>
{
	private readonly UIntPtr _ptr;
	public InstanceHandle(UIntPtr ptr) { _ptr = ptr; }
	public static InstanceHandle Null => new InstanceHandle(UIntPtr.Zero);
	public static explicit operator InstanceHandle(UIntPtr ptr) => new InstanceHandle(ptr);
	public static explicit operator UIntPtr(InstanceHandle handle) => handle._ptr;
	public static bool operator ==(InstanceHandle left, InstanceHandle right) => left._ptr == right._ptr;
	public static bool operator !=(InstanceHandle left, InstanceHandle right) => left._ptr != right._ptr;
	public static bool operator ==(InstanceHandle left, InstanceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(InstanceHandle left, InstanceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(InstanceHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(InstanceHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(InstanceHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is InstanceHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

