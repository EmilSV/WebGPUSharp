using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct AdapterHandle : IEquatable<AdapterHandle>
{
    private readonly nuint _ptr;
    public static AdapterHandle Null
    {
        get => new(nuint.Zero);
    }

    public AdapterHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(AdapterHandle handle) => handle._ptr;

    public static bool operator ==(AdapterHandle left, AdapterHandle right) => left._ptr == right._ptr;

    public static bool operator !=(AdapterHandle left, AdapterHandle right) => left._ptr != right._ptr;

    public static bool operator ==(AdapterHandle left, AdapterHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(AdapterHandle left, AdapterHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(AdapterHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(AdapterHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(AdapterHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is AdapterHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

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
    /// the adapter becomes {{adapter/state/"consumed"}}.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="Device"/> to request.</param>
    public Future RequestDevice(DeviceDescriptorFFI* options, RequestDeviceCallbackInfoFFI callbackInfo) => WebGPU_FFI.AdapterRequestDevice(this, options, callbackInfo);

    public void AddRef() => WebGPU_FFI.AdapterAddRef(this);

    public void Release() => WebGPU_FFI.AdapterRelease(this);

}
