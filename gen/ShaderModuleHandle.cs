using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct ShaderModuleHandle : IEquatable<ShaderModuleHandle>
{
	private readonly UIntPtr _ptr;
	public ShaderModuleHandle(UIntPtr ptr) { _ptr = ptr; }
	public static ShaderModuleHandle Null => new ShaderModuleHandle(UIntPtr.Zero);
	public static explicit operator ShaderModuleHandle(UIntPtr ptr) => new ShaderModuleHandle(ptr);
	public static explicit operator UIntPtr(ShaderModuleHandle handle) => handle._ptr;
	public static bool operator ==(ShaderModuleHandle left, ShaderModuleHandle right) => left._ptr == right._ptr;
	public static bool operator !=(ShaderModuleHandle left, ShaderModuleHandle right) => left._ptr != right._ptr;
	public static bool operator ==(ShaderModuleHandle left, ShaderModuleHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(ShaderModuleHandle left, ShaderModuleHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(ShaderModuleHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(ShaderModuleHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(ShaderModuleHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is ShaderModuleHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

