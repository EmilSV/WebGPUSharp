using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Handle to a rendering (graphics) pipeline.
/// 
/// A RenderPipeline object represents a graphics pipeline and its stages, bindings, vertex buffers and targets.
/// It can be created with <see cref="DeviceHandle.CreateRenderPipeline" />.
/// </summary>
public unsafe partial struct RenderPipelineHandle : IEquatable<RenderPipelineHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static RenderPipelineHandle Null
    {
        get => new(nuint.Zero);
    }

    public RenderPipelineHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(RenderPipelineHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(RenderPipelineHandle left, RenderPipelineHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(RenderPipelineHandle left, RenderPipelineHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(RenderPipelineHandle left, RenderPipelineHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(RenderPipelineHandle left, RenderPipelineHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(RenderPipelineHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(RenderPipelineHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(RenderPipelineHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is RenderPipelineHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Get an object representing the bind group layout at a given index.
    /// 
    /// If this pipeline was created with a default layout, then bind groups created with the returned BindGroupLayout can only be used with this pipeline.
    /// 
    /// This method will raise a validation error if there is no bind group layout at index.
    /// </summary>
    public BindGroupLayoutHandle GetBindGroupLayout(uint groupIndex) => WebGPU_FFI.RenderPipelineGetBindGroupLayout(this, groupIndex);

    /// <summary>
    /// Set the debug label of this RenderPipelineHandle.
    /// </summary>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.RenderPipelineSetLabel(this, label);

    /// <summary>
    /// Increments the reference count of the <see cref="RenderPipelineHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.RenderPipelineAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="RenderPipelineHandle"/>. When the reference count reaches zero, the <see cref="RenderPipelineHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="RenderPipelineHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.RenderPipelineRelease(this);

}
