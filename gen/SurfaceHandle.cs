using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SurfaceHandle : IEquatable<SurfaceHandle>
{
	private readonly UIntPtr _ptr;
	public SurfaceHandle(UIntPtr ptr) { _ptr = ptr; }
	public static SurfaceHandle Null => new SurfaceHandle(UIntPtr.Zero);
	public static explicit operator SurfaceHandle(UIntPtr ptr) => new SurfaceHandle(ptr);
	public static explicit operator UIntPtr(SurfaceHandle handle) => handle._ptr;
	public static bool operator ==(SurfaceHandle left, SurfaceHandle right) => left._ptr == right._ptr;
	public static bool operator !=(SurfaceHandle left, SurfaceHandle right) => left._ptr != right._ptr;
	public static bool operator ==(SurfaceHandle left, SurfaceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(SurfaceHandle left, SurfaceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(SurfaceHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(SurfaceHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(SurfaceHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is SurfaceHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

