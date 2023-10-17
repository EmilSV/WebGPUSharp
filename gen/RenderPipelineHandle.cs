using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct RenderPipelineHandle : IEquatable<RenderPipelineHandle>
{
	private readonly UIntPtr _ptr;
	public RenderPipelineHandle(UIntPtr ptr) { _ptr = ptr; }
	public static RenderPipelineHandle Null => new RenderPipelineHandle(UIntPtr.Zero);
	public static explicit operator RenderPipelineHandle(UIntPtr ptr) => new RenderPipelineHandle(ptr);
	public static explicit operator UIntPtr(RenderPipelineHandle handle) => handle._ptr;
	public static bool operator ==(RenderPipelineHandle left, RenderPipelineHandle right) => left._ptr == right._ptr;
	public static bool operator !=(RenderPipelineHandle left, RenderPipelineHandle right) => left._ptr != right._ptr;
	public static bool operator ==(RenderPipelineHandle left, RenderPipelineHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(RenderPipelineHandle left, RenderPipelineHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(RenderPipelineHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(RenderPipelineHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(RenderPipelineHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is RenderPipelineHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

