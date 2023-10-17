using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct RenderBundleHandle : IEquatable<RenderBundleHandle>
{
	private readonly UIntPtr _ptr;
	public RenderBundleHandle(UIntPtr ptr) { _ptr = ptr; }
	public static RenderBundleHandle Null => new RenderBundleHandle(UIntPtr.Zero);
	public static explicit operator RenderBundleHandle(UIntPtr ptr) => new RenderBundleHandle(ptr);
	public static explicit operator UIntPtr(RenderBundleHandle handle) => handle._ptr;
	public static bool operator ==(RenderBundleHandle left, RenderBundleHandle right) => left._ptr == right._ptr;
	public static bool operator !=(RenderBundleHandle left, RenderBundleHandle right) => left._ptr != right._ptr;
	public static bool operator ==(RenderBundleHandle left, RenderBundleHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(RenderBundleHandle left, RenderBundleHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(RenderBundleHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(RenderBundleHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(RenderBundleHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is RenderBundleHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

