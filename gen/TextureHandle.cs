using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct TextureHandle : IEquatable<TextureHandle>
{
	private readonly UIntPtr _ptr;
	public TextureHandle(UIntPtr ptr) { _ptr = ptr; }
	public static TextureHandle Null => new TextureHandle(UIntPtr.Zero);
	public static explicit operator TextureHandle(UIntPtr ptr) => new TextureHandle(ptr);
	public static explicit operator UIntPtr(TextureHandle handle) => handle._ptr;
	public static bool operator ==(TextureHandle left, TextureHandle right) => left._ptr == right._ptr;
	public static bool operator !=(TextureHandle left, TextureHandle right) => left._ptr != right._ptr;
	public static bool operator ==(TextureHandle left, TextureHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(TextureHandle left, TextureHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(TextureHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(TextureHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(TextureHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is TextureHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

