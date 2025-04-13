using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct AdapterHandle : IEquatable<AdapterHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static AdapterHandle Null
    {
        get => new(nuint.Zero);
    }

    public AdapterHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    public static explicit operator nuint(AdapterHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    public static bool operator ==(AdapterHandle left, AdapterHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    public static bool operator !=(AdapterHandle left, AdapterHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    public static bool operator ==(AdapterHandle left, AdapterHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    public static bool operator !=(AdapterHandle left, AdapterHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    public static bool operator ==(AdapterHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    public static bool operator !=(AdapterHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    public bool Equals(AdapterHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    public override bool Equals(object? other) => other is AdapterHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Get the features supported by the adapter.
    /// </summary>
    /// <param name="info">The features to fill in.</param>
    /// <returns>the status of the call.</returns>
    public void GetFeatures(SupportedFeaturesFFI* features) => WebGPU_FFI.AdapterGetFeatures(this, features);

    /// <summary>
    /// Get info about the adapter itself.
    /// </summary>
    /// <param name="info">The info to fill in.</param>
    /// <returns>the status of the call.</returns>
    public Status GetInfo(AdapterInfoFFI* info) => WebGPU_FFI.AdapterGetInfo(this, info);

    /// <summary>
    /// The best limits which can be used to create devices on this adapter.
    /// </summary>
    /// <param name="limits">The limits to fill in.</param>
    /// <returns>the status of the call.</returns>
    public Status GetLimits(SupportedLimits* limits) => WebGPU_FFI.AdapterGetLimits(this, limits);

    /// <summary>
    /// Check if and additional functionality is supported by the adapter.
    /// </summary>
    /// <param name="feature">The feature to check.</param>
    /// <returns>true if the feature is supported.</returns>
    public WebGPUBool HasFeature(FeatureName feature) => WebGPU_FFI.AdapterHasFeature(this, feature);

    /// <summary>
    /// Requests a device from the adapter.
    /// This is a one-time action: if a device is returned successfully,
    /// the adapter then enters a "consumed" state
    /// </summary>
    /// <param name="descriptor">The device descriptor to use.</param>
    /// <param name="callbackInfo">The callback to call when the device is ready</param>
    public Future RequestDevice(DeviceDescriptorFFI* options, RequestDeviceCallbackInfoFFI callbackInfo) => WebGPU_FFI.AdapterRequestDevice(this, options, callbackInfo);

    /// <summary>
    /// Increments the reference count of the <see cref="AdapterHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.AdapterAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="AdapterHandle"/>. When the reference count reaches zero, the <see cref="AdapterHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="AdapterHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.AdapterRelease(this);

}
