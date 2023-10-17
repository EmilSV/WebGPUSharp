using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct RenderPassEncoderHandle : IEquatable<RenderPassEncoderHandle>
{
	private readonly UIntPtr _ptr;
	public RenderPassEncoderHandle(UIntPtr ptr) { _ptr = ptr; }
	public static RenderPassEncoderHandle Null => new RenderPassEncoderHandle(UIntPtr.Zero);
	public static explicit operator RenderPassEncoderHandle(UIntPtr ptr) => new RenderPassEncoderHandle(ptr);
	public static explicit operator UIntPtr(RenderPassEncoderHandle handle) => handle._ptr;
	public static bool operator ==(RenderPassEncoderHandle left, RenderPassEncoderHandle right) => left._ptr == right._ptr;
	public static bool operator !=(RenderPassEncoderHandle left, RenderPassEncoderHandle right) => left._ptr != right._ptr;
	public static bool operator ==(RenderPassEncoderHandle left, RenderPassEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(RenderPassEncoderHandle left, RenderPassEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(RenderPassEncoderHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(RenderPassEncoderHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(RenderPassEncoderHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is RenderPassEncoderHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

