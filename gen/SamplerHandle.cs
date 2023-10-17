using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SamplerHandle : IEquatable<SamplerHandle>
{
	private readonly UIntPtr _ptr;
	public SamplerHandle(UIntPtr ptr) { _ptr = ptr; }
	public static SamplerHandle Null => new SamplerHandle(UIntPtr.Zero);
	public static explicit operator SamplerHandle(UIntPtr ptr) => new SamplerHandle(ptr);
	public static explicit operator UIntPtr(SamplerHandle handle) => handle._ptr;
	public static bool operator ==(SamplerHandle left, SamplerHandle right) => left._ptr == right._ptr;
	public static bool operator !=(SamplerHandle left, SamplerHandle right) => left._ptr != right._ptr;
	public static bool operator ==(SamplerHandle left, SamplerHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(SamplerHandle left, SamplerHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(SamplerHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(SamplerHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(SamplerHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is SamplerHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

