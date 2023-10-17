using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct ExternalTextureHandle : IEquatable<ExternalTextureHandle>
{
	private readonly UIntPtr _ptr;
	public ExternalTextureHandle(UIntPtr ptr) { _ptr = ptr; }
	public static ExternalTextureHandle Null => new ExternalTextureHandle(UIntPtr.Zero);
	public static explicit operator ExternalTextureHandle(UIntPtr ptr) => new ExternalTextureHandle(ptr);
	public static explicit operator UIntPtr(ExternalTextureHandle handle) => handle._ptr;
	public static bool operator ==(ExternalTextureHandle left, ExternalTextureHandle right) => left._ptr == right._ptr;
	public static bool operator !=(ExternalTextureHandle left, ExternalTextureHandle right) => left._ptr != right._ptr;
	public static bool operator ==(ExternalTextureHandle left, ExternalTextureHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(ExternalTextureHandle left, ExternalTextureHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(ExternalTextureHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(ExternalTextureHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(ExternalTextureHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is ExternalTextureHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

