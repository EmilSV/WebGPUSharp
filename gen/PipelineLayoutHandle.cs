using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct PipelineLayoutHandle : IEquatable<PipelineLayoutHandle>
{
	private readonly UIntPtr _ptr;
	public PipelineLayoutHandle(UIntPtr ptr) { _ptr = ptr; }
	public static PipelineLayoutHandle Null => new PipelineLayoutHandle(UIntPtr.Zero);
	public static explicit operator PipelineLayoutHandle(UIntPtr ptr) => new PipelineLayoutHandle(ptr);
	public static explicit operator UIntPtr(PipelineLayoutHandle handle) => handle._ptr;
	public static bool operator ==(PipelineLayoutHandle left, PipelineLayoutHandle right) => left._ptr == right._ptr;
	public static bool operator !=(PipelineLayoutHandle left, PipelineLayoutHandle right) => left._ptr != right._ptr;
	public static bool operator ==(PipelineLayoutHandle left, PipelineLayoutHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(PipelineLayoutHandle left, PipelineLayoutHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(PipelineLayoutHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(PipelineLayoutHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(PipelineLayoutHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is PipelineLayoutHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

