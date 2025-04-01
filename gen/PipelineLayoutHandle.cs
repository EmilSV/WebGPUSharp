using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A PipelineLayout object describes the available binding groups of a pipeline. It can be created with <see cref="Device.CreatePipelineLayout" />.
/// </summary>
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

    /// <summary>
    /// Sets the label of the pipeline layout.
    /// </summary>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.PipelineLayoutSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.PipelineLayoutAddRef(this);

    public void Release() => WebGPU_FFI.PipelineLayoutRelease(this);

}
