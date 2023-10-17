using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SwapChainHandle : IEquatable<SwapChainHandle>
{
	private readonly UIntPtr _ptr;
	public SwapChainHandle(UIntPtr ptr) { _ptr = ptr; }
	public static SwapChainHandle Null => new SwapChainHandle(UIntPtr.Zero);
	public static explicit operator SwapChainHandle(UIntPtr ptr) => new SwapChainHandle(ptr);
	public static explicit operator UIntPtr(SwapChainHandle handle) => handle._ptr;
	public static bool operator ==(SwapChainHandle left, SwapChainHandle right) => left._ptr == right._ptr;
	public static bool operator !=(SwapChainHandle left, SwapChainHandle right) => left._ptr != right._ptr;
	public static bool operator ==(SwapChainHandle left, SwapChainHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(SwapChainHandle left, SwapChainHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(SwapChainHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(SwapChainHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(SwapChainHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is SwapChainHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

