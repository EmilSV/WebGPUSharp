using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct TextureViewHandle : IEquatable<TextureViewHandle>
{
	private readonly UIntPtr _ptr;
	public TextureViewHandle(UIntPtr ptr) { _ptr = ptr; }
	public static TextureViewHandle Null => new TextureViewHandle(UIntPtr.Zero);
	public static explicit operator TextureViewHandle(UIntPtr ptr) => new TextureViewHandle(ptr);
	public static explicit operator UIntPtr(TextureViewHandle handle) => handle._ptr;
	public static bool operator ==(TextureViewHandle left, TextureViewHandle right) => left._ptr == right._ptr;
	public static bool operator !=(TextureViewHandle left, TextureViewHandle right) => left._ptr != right._ptr;
	public static bool operator ==(TextureViewHandle left, TextureViewHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(TextureViewHandle left, TextureViewHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(TextureViewHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(TextureViewHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(TextureViewHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is TextureViewHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

