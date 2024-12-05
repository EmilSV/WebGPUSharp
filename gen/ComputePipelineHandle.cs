using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct ComputePipelineHandle : IEquatable<ComputePipelineHandle>
{
    private readonly nuint _ptr;
    public static ComputePipelineHandle Null
    {
        get => new(nuint.Zero);
    }

    public ComputePipelineHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(ComputePipelineHandle handle) => handle._ptr;

    public static bool operator ==(ComputePipelineHandle left, ComputePipelineHandle right) => left._ptr == right._ptr;

    public static bool operator !=(ComputePipelineHandle left, ComputePipelineHandle right) => left._ptr != right._ptr;

    public static bool operator ==(ComputePipelineHandle left, ComputePipelineHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(ComputePipelineHandle left, ComputePipelineHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(ComputePipelineHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(ComputePipelineHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(ComputePipelineHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is ComputePipelineHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    public BindGroupLayoutHandle GetBindGroupLayout(uint groupIndex) => WebGPU_FFI.ComputePipelineGetBindGroupLayout(this, groupIndex);

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.ComputePipelineSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.ComputePipelineAddRef(this);

    public void Release() => WebGPU_FFI.ComputePipelineRelease(this);

}
