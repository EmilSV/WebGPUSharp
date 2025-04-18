using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Context for all other WebGPU objects.
/// This is the first thing you create when using WebGPU. Its primary use is to create <see cref="AdapterHandle" /> and <see cref="SurfaceHandle" />.
/// </summary>
public unsafe partial struct InstanceHandle : IEquatable<InstanceHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static InstanceHandle Null
    {
        get => new(nuint.Zero);
    }

    public InstanceHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(InstanceHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(InstanceHandle left, InstanceHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(InstanceHandle left, InstanceHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(InstanceHandle left, InstanceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(InstanceHandle left, InstanceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(InstanceHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(InstanceHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(InstanceHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is InstanceHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Creates a new surface targeting a given window/canvas/surface/etc..
    /// </summary>
    public SurfaceHandle CreateSurface(SurfaceDescriptorFFI* descriptor) => WebGPU_FFI.InstanceCreateSurface(this, descriptor);

    /// <summary>
    /// Returns set of supported WGSL language extensions supported by this instance.
    /// </summary>
    /// <param name="features">A pointer to struct to fill with supported extension</param>
    /// <returns>The status of the operation</returns>
    public Status GetWGSLLanguageFeatures(SupportedWGSLLanguageFeaturesFFI* features) => WebGPU_FFI.InstanceGetWGSLLanguageFeatures(this, features);

    /// <summary>
    /// check if a WGSL language extensions is supported by this instance.
    /// </summary>
    /// <returns>true if the feature is supported, false otherwise.</returns>
    public WebGPUBool HasWGSLLanguageFeature(WGSLLanguageFeatureName feature) => WebGPU_FFI.InstanceHasWGSLLanguageFeature(this, feature);

    /// <summary>
    /// Processes asynchronous events on this `Instance`, calling any callbacks for asynchronous operations created with <see cref="CallbackMode.AllowProcessEvents" />.
    /// </summary>
    public void ProcessEvents() => WebGPU_FFI.InstanceProcessEvents(this);

    /// <summary>
    /// Retrieves an Adapter which matches the given <see cref="RequestAdapterOptionsFFI" />.
    /// </summary>
    public Future RequestAdapter(RequestAdapterOptionsFFI* options, RequestAdapterCallbackInfoFFI callbackInfo) => WebGPU_FFI.InstanceRequestAdapter(this, options, callbackInfo);

    /// <summary>
    /// Wait for at least one Future in `futures` to complete, and call callbacks of the respective completed asynchronous operations.
    /// </summary>
    public WaitStatus WaitAny(nuint futureCount, FutureWaitInfo* futures, ulong timeoutNS) => WebGPU_FFI.InstanceWaitAny(this, futureCount, futures, timeoutNS);

    /// <summary>
    /// Increments the reference count of the <see cref="InstanceHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.InstanceAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="InstanceHandle"/>. When the reference count reaches zero, the <see cref="InstanceHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="InstanceHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.InstanceRelease(this);

}
