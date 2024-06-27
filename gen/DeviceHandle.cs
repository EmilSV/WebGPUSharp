using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct DeviceHandle : IEquatable<DeviceHandle>
{
    private readonly nuint _ptr;
    public static DeviceHandle Null
    {
        get => new(nuint.Zero);
    }

    public DeviceHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(DeviceHandle handle) => handle._ptr;
    public static bool operator ==(DeviceHandle left, DeviceHandle right) => left._ptr == right._ptr;
    public static bool operator !=(DeviceHandle left, DeviceHandle right) => left._ptr != right._ptr;
    public static bool operator ==(DeviceHandle left, DeviceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(DeviceHandle left, DeviceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(DeviceHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(DeviceHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(DeviceHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is DeviceHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
