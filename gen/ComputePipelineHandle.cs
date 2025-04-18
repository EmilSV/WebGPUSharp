using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Handle to a compute pipeline.
/// 
/// A ComputePipeline object represents a compute pipeline and its single shader stage.
/// It can be created with <see cref="DeviceHandle.CreateComputePipeline" />.
/// </summary>
public unsafe partial struct ComputePipelineHandle : IEquatable<ComputePipelineHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static ComputePipelineHandle Null
    {
        get => new(nuint.Zero);
    }

    public ComputePipelineHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(ComputePipelineHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(ComputePipelineHandle left, ComputePipelineHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(ComputePipelineHandle left, ComputePipelineHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(ComputePipelineHandle left, ComputePipelineHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(ComputePipelineHandle left, ComputePipelineHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(ComputePipelineHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(ComputePipelineHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(ComputePipelineHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is ComputePipelineHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
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

    /// <summary>
    /// Increments the reference count of the <see cref="ComputePipelineHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.ComputePipelineAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="ComputePipelineHandle"/>. When the reference count reaches zero, the <see cref="ComputePipelineHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="ComputePipelineHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.ComputePipelineRelease(this);

}
