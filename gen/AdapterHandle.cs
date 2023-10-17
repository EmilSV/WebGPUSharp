using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct AdapterHandle : IEquatable<AdapterHandle>
{
	private readonly UIntPtr _ptr;
	public AdapterHandle(UIntPtr ptr) { _ptr = ptr; }
	public static AdapterHandle Null => new AdapterHandle(UIntPtr.Zero);
	public static explicit operator AdapterHandle(UIntPtr ptr) => new AdapterHandle(ptr);
	public static explicit operator UIntPtr(AdapterHandle handle) => handle._ptr;
	public static bool operator ==(AdapterHandle left, AdapterHandle right) => left._ptr == right._ptr;
	public static bool operator !=(AdapterHandle left, AdapterHandle right) => left._ptr != right._ptr;
	public static bool operator ==(AdapterHandle left, AdapterHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(AdapterHandle left, AdapterHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(AdapterHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(AdapterHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(AdapterHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is AdapterHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

