using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct RenderBundleEncoderHandle : IEquatable<RenderBundleEncoderHandle>
{
	private readonly UIntPtr _ptr;
	public RenderBundleEncoderHandle(UIntPtr ptr) { _ptr = ptr; }
	public static RenderBundleEncoderHandle Null => new RenderBundleEncoderHandle(UIntPtr.Zero);
	public static explicit operator RenderBundleEncoderHandle(UIntPtr ptr) => new RenderBundleEncoderHandle(ptr);
	public static explicit operator UIntPtr(RenderBundleEncoderHandle handle) => handle._ptr;
	public static bool operator ==(RenderBundleEncoderHandle left, RenderBundleEncoderHandle right) => left._ptr == right._ptr;
	public static bool operator !=(RenderBundleEncoderHandle left, RenderBundleEncoderHandle right) => left._ptr != right._ptr;
	public static bool operator ==(RenderBundleEncoderHandle left, RenderBundleEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(RenderBundleEncoderHandle left, RenderBundleEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(RenderBundleEncoderHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(RenderBundleEncoderHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(RenderBundleEncoderHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is RenderBundleEncoderHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

