using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Handle to a compute pipeline.
/// 
/// A ComputePipeline object represents a compute pipeline and its single shader stage.
/// It can be created with <see cref="DeviceHandle.CreateComputePipeline" />.
/// </summary>
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

    /// <summary>
    /// Gets the bind group layout for the given group index.
    /// 
    /// If this pipeline was created with a default layout,
    /// then bind groups created with the returned BindGroupLayout can only be used with this pipeline.
    /// This method will raise a validation error if there is no bind group layout at index.
    /// </summary>
    /// <param name="groupIndex">Index into the pipeline layout's bindGroupLayouts sequence.</param>
    /// <returns>The bind group layout for the given group index.</returns>
    public BindGroupLayoutHandle GetBindGroupLayout(uint groupIndex) => WebGPU_FFI.ComputePipelineGetBindGroupLayout(this, groupIndex);

    /// <summary>
    /// Set debug label of this compute pipeline.
    /// </summary>
    /// <param name="label">The new label.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.ComputePipelineSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.ComputePipelineAddRef(this);

    public void Release() => WebGPU_FFI.ComputePipelineRelease(this);

}
