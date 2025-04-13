using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Pre-prepared reusable bundle of GPU operations.
/// 
/// It only supports a handful of render commands, but it makes them reusable. Executing a RenderBundle is often more efficient than issuing the underlying commands manually.
/// 
/// It can be created by use of a RenderBundleEncoderHandle, and executed onto a CommandEncoder using <see cref="FFI.RenderPassHandle.ExecuteBundles" />.
/// </summary>
public unsafe partial struct RenderBundleHandle : IEquatable<RenderBundleHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static RenderBundleHandle Null
    {
        get => new(nuint.Zero);
    }

    public RenderBundleHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    public static explicit operator nuint(RenderBundleHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    public static bool operator ==(RenderBundleHandle left, RenderBundleHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    public static bool operator !=(RenderBundleHandle left, RenderBundleHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    public static bool operator ==(RenderBundleHandle left, RenderBundleHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    public static bool operator !=(RenderBundleHandle left, RenderBundleHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    public static bool operator ==(RenderBundleHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    public static bool operator !=(RenderBundleHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    public bool Equals(RenderBundleHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    public override bool Equals(object? other) => other is RenderBundleHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Sets the debug label of the RenderBundleHandle.
    /// </summary>
    /// <param name="label">The new debug label to set.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.RenderBundleSetLabel(this, label);

    /// <summary>
    /// Increments the reference count of the <see cref="RenderBundleHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.RenderBundleAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="RenderBundleHandle"/>. When the reference count reaches zero, the <see cref="RenderBundleHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="RenderBundleHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.RenderBundleRelease(this);

}
