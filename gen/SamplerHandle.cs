using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Handle to a sampler.
/// 
/// A Sampler object defines how a pipeline will sample from a TextureView.
/// Samplers define image filters (including anisotropy) and address (wrapping) modes, among other things.
/// See the documentation for SamplerDescriptor for more information.
/// 
/// It can be created with <see cref="DeviceHandle.CreateSampler" />.
/// </summary>
public unsafe partial struct SamplerHandle : IEquatable<SamplerHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static SamplerHandle Null
    {
        get => new(nuint.Zero);
    }

    public SamplerHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    public static explicit operator nuint(SamplerHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    public static bool operator ==(SamplerHandle left, SamplerHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    public static bool operator !=(SamplerHandle left, SamplerHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    public static bool operator ==(SamplerHandle left, SamplerHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    public static bool operator !=(SamplerHandle left, SamplerHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    public static bool operator ==(SamplerHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    public static bool operator !=(SamplerHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    public bool Equals(SamplerHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    public override bool Equals(object? other) => other is SamplerHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Set the label of the sampler.
    /// </summary>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.SamplerSetLabel(this, label);

    /// <summary>
    /// Increments the reference count of the <see cref="SamplerHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.SamplerAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="SamplerHandle"/>. When the reference count reaches zero, the <see cref="SamplerHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="SamplerHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.SamplerRelease(this);

}
