using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct PipelineLayoutHandle : IEquatable<PipelineLayoutHandle>
{
    private readonly nuint _ptr;
    public static PipelineLayoutHandle Null
    {
        get => new(nuint.Zero);
    }

    public PipelineLayoutHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(PipelineLayoutHandle handle) => handle._ptr;
    public static bool operator ==(PipelineLayoutHandle left, PipelineLayoutHandle right) => left._ptr == right._ptr;
    public static bool operator !=(PipelineLayoutHandle left, PipelineLayoutHandle right) => left._ptr != right._ptr;
    public static bool operator ==(PipelineLayoutHandle left, PipelineLayoutHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(PipelineLayoutHandle left, PipelineLayoutHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(PipelineLayoutHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(PipelineLayoutHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(PipelineLayoutHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is PipelineLayoutHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
    public void SetLabel(byte* label) => WebGPU_FFI.PipelineLayoutSetLabel(this, label);
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.PipelineLayoutSetLabel2(this, label);
    public void AddRef() => WebGPU_FFI.PipelineLayoutAddRef(this);
    public void Release() => WebGPU_FFI.PipelineLayoutRelease(this);
}
