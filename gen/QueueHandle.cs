using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct QueueHandle : IEquatable<QueueHandle>
{
    private readonly nuint _ptr;
    public static QueueHandle Null
    {
        get => new(nuint.Zero);
    }

    public QueueHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(QueueHandle handle) => handle._ptr;
    public static bool operator ==(QueueHandle left, QueueHandle right) => left._ptr == right._ptr;
    public static bool operator !=(QueueHandle left, QueueHandle right) => left._ptr != right._ptr;
    public static bool operator ==(QueueHandle left, QueueHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(QueueHandle left, QueueHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(QueueHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(QueueHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(QueueHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is QueueHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
