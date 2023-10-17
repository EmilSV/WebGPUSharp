using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct ComputePassEncoderHandle : IEquatable<ComputePassEncoderHandle>
{
	private readonly UIntPtr _ptr;
	public ComputePassEncoderHandle(UIntPtr ptr) { _ptr = ptr; }
	public static ComputePassEncoderHandle Null => new ComputePassEncoderHandle(UIntPtr.Zero);
	public static explicit operator ComputePassEncoderHandle(UIntPtr ptr) => new ComputePassEncoderHandle(ptr);
	public static explicit operator UIntPtr(ComputePassEncoderHandle handle) => handle._ptr;
	public static bool operator ==(ComputePassEncoderHandle left, ComputePassEncoderHandle right) => left._ptr == right._ptr;
	public static bool operator !=(ComputePassEncoderHandle left, ComputePassEncoderHandle right) => left._ptr != right._ptr;
	public static bool operator ==(ComputePassEncoderHandle left, ComputePassEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(ComputePassEncoderHandle left, ComputePassEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(ComputePassEncoderHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(ComputePassEncoderHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(ComputePassEncoderHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is ComputePassEncoderHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

