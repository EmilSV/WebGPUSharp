using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct BindGroupLayoutHandle : IEquatable<BindGroupLayoutHandle>
{
	private readonly UIntPtr _ptr;
	public BindGroupLayoutHandle(UIntPtr ptr) { _ptr = ptr; }
	public static BindGroupLayoutHandle Null => new BindGroupLayoutHandle(UIntPtr.Zero);
	public static explicit operator BindGroupLayoutHandle(UIntPtr ptr) => new BindGroupLayoutHandle(ptr);
	public static explicit operator UIntPtr(BindGroupLayoutHandle handle) => handle._ptr;
	public static bool operator ==(BindGroupLayoutHandle left, BindGroupLayoutHandle right) => left._ptr == right._ptr;
	public static bool operator !=(BindGroupLayoutHandle left, BindGroupLayoutHandle right) => left._ptr != right._ptr;
	public static bool operator ==(BindGroupLayoutHandle left, BindGroupLayoutHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(BindGroupLayoutHandle left, BindGroupLayoutHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(BindGroupLayoutHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(BindGroupLayoutHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(BindGroupLayoutHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is BindGroupLayoutHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

