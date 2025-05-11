using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A handle to a surface.
/// </summary>
public unsafe partial struct SurfaceHandle : IEquatable<SurfaceHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// A null handle.
    /// </summary>
    public static SurfaceHandle Null
    {
        get => new(nuint.Zero);
    }

    public SurfaceHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(SurfaceHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(SurfaceHandle left, SurfaceHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(SurfaceHandle left, SurfaceHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(SurfaceHandle left, SurfaceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(SurfaceHandle left, SurfaceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(SurfaceHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(SurfaceHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(SurfaceHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is SurfaceHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Configures the surface.
    /// </summary>
    /// <param name="config">The configuration to use.</param>
    public void Configure(SurfaceConfigurationFFI* config) => WebGPU_FFI.SurfaceConfigure(this, config);

    /// <summary>
    /// Returns the capabilities of the surface when used with the given adapter.
    /// 
    /// Returns specified values (see SurfaceCapabilities) if surface is incompatible with the adapter.
    /// </summary>
    /// <param name="capabilities">The capabilities of the surface.</param>
    /// <param name="adapter">The adapter to use.</param>
    public Status GetCapabilities(AdapterHandle adapter, SurfaceCapabilitiesFFI* capabilities) => WebGPU_FFI.SurfaceGetCapabilities(this, adapter, capabilities);

    /// <summary>
    /// Gets the current texture of the surface.
    /// </summary>
    /// <param name="surfaceTexture">The current texture of the surface.</param>
    public void GetCurrentTexture(SurfaceTextureFFI* surfaceTexture) => WebGPU_FFI.SurfaceGetCurrentTexture(this, surfaceTexture);

    /// <summary>
    /// Presents the surface.
    /// </summary>
    public void Present() => WebGPU_FFI.SurfacePresent(this);

    /// <summary>
    /// Sets the label of the surface.
    /// </summary>
    /// <param name="label">The label to set.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.SurfaceSetLabel(this, label);

    /// <summary>
    /// Unconfigures the surface.
    /// </summary>
    public void Unconfigure() => WebGPU_FFI.SurfaceUnconfigure(this);

    /// <summary>
    /// Increments the reference count of the <see cref="SurfaceHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.SurfaceAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="SurfaceHandle"/>. When the reference count reaches zero, the <see cref="SurfaceHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="SurfaceHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.SurfaceRelease(this);

}
