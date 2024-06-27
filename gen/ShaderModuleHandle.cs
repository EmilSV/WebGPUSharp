using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct ShaderModuleHandle : IEquatable<ShaderModuleHandle>
{
    private readonly nuint _ptr;
    public static ShaderModuleHandle Null
    {
        get => new(nuint.Zero);
    }

    public ShaderModuleHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(ShaderModuleHandle handle) => handle._ptr;
    public static bool operator ==(ShaderModuleHandle left, ShaderModuleHandle right) => left._ptr == right._ptr;
    public static bool operator !=(ShaderModuleHandle left, ShaderModuleHandle right) => left._ptr != right._ptr;
    public static bool operator ==(ShaderModuleHandle left, ShaderModuleHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(ShaderModuleHandle left, ShaderModuleHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(ShaderModuleHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(ShaderModuleHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(ShaderModuleHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is ShaderModuleHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
