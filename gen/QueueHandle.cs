using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct QueueHandle : IEquatable<QueueHandle>
{
	private readonly UIntPtr _ptr;
	public QueueHandle(UIntPtr ptr) { _ptr = ptr; }
	public static QueueHandle Null => new QueueHandle(UIntPtr.Zero);
	public static explicit operator QueueHandle(UIntPtr ptr) => new QueueHandle(ptr);
	public static explicit operator UIntPtr(QueueHandle handle) => handle._ptr;
	public static bool operator ==(QueueHandle left, QueueHandle right) => left._ptr == right._ptr;
	public static bool operator !=(QueueHandle left, QueueHandle right) => left._ptr != right._ptr;
	public static bool operator ==(QueueHandle left, QueueHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(QueueHandle left, QueueHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(QueueHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(QueueHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(QueueHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is QueueHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();

}

