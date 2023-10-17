using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct DeviceHandle : IEquatable<DeviceHandle>
{
	private readonly UIntPtr _ptr;
	public DeviceHandle(UIntPtr ptr) { _ptr = ptr; }
	public static DeviceHandle Null => new DeviceHandle(UIntPtr.Zero);
	public static explicit operator DeviceHandle(UIntPtr ptr) => new DeviceHandle(ptr);
	public static explicit operator UIntPtr(DeviceHandle handle) => handle._ptr;
	public static bool operator ==(DeviceHandle left, DeviceHandle right) => left._ptr == right._ptr;
	public static bool operator !=(DeviceHandle left, DeviceHandle right) => left._ptr != right._ptr;
	public static bool operator ==(DeviceHandle left, DeviceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(DeviceHandle left, DeviceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(DeviceHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(DeviceHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(DeviceHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is DeviceHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

