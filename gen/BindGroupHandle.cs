using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A handle to a <see cref="WebGpuSharp.BindGroup" />.
/// </summary>
public readonly unsafe partial struct BindGroupHandle : IEquatable<BindGroupHandle>
{
    private readonly nuint _ptr;
    public static BindGroupHandle Null
    {
        get => new(nuint.Zero);
    }

    public BindGroupHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(BindGroupHandle handle) => handle._ptr;

    public static bool operator ==(BindGroupHandle left, BindGroupHandle right) => left._ptr == right._ptr;

    public static bool operator !=(BindGroupHandle left, BindGroupHandle right) => left._ptr != right._ptr;

    public static bool operator ==(BindGroupHandle left, BindGroupHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(BindGroupHandle left, BindGroupHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(BindGroupHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(BindGroupHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(BindGroupHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is BindGroupHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Set the label of the bind group.
    /// </summary>
    /// <param name="label">The label to set.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.BindGroupSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.BindGroupAddRef(this);

    public void Release() => WebGPU_FFI.BindGroupRelease(this);

}
