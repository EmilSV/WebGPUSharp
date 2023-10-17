using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct BindGroupHandle : IEquatable<BindGroupHandle>
{
	private readonly UIntPtr _ptr;
	public BindGroupHandle(UIntPtr ptr) { _ptr = ptr; }
	public static BindGroupHandle Null => new BindGroupHandle(UIntPtr.Zero);
	public static explicit operator BindGroupHandle(UIntPtr ptr) => new BindGroupHandle(ptr);
	public static explicit operator UIntPtr(BindGroupHandle handle) => handle._ptr;
	public static bool operator ==(BindGroupHandle left, BindGroupHandle right) => left._ptr == right._ptr;
	public static bool operator !=(BindGroupHandle left, BindGroupHandle right) => left._ptr != right._ptr;
	public static bool operator ==(BindGroupHandle left, BindGroupHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(BindGroupHandle left, BindGroupHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(BindGroupHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(BindGroupHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(BindGroupHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is BindGroupHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

