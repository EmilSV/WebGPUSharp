using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct ComputePipelineHandle : IEquatable<ComputePipelineHandle>
{
	private readonly UIntPtr _ptr;
	public ComputePipelineHandle(UIntPtr ptr) { _ptr = ptr; }
	public static ComputePipelineHandle Null => new ComputePipelineHandle(UIntPtr.Zero);
	public static explicit operator ComputePipelineHandle(UIntPtr ptr) => new ComputePipelineHandle(ptr);
	public static explicit operator UIntPtr(ComputePipelineHandle handle) => handle._ptr;
	public static bool operator ==(ComputePipelineHandle left, ComputePipelineHandle right) => left._ptr == right._ptr;
	public static bool operator !=(ComputePipelineHandle left, ComputePipelineHandle right) => left._ptr != right._ptr;
	public static bool operator ==(ComputePipelineHandle left, ComputePipelineHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(ComputePipelineHandle left, ComputePipelineHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(ComputePipelineHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(ComputePipelineHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(ComputePipelineHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is ComputePipelineHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

