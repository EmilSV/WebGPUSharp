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

    public DeviceHandle CreateDevice(DeviceDescriptorFFI* descriptor) => WebGPU_FFI.AdapterCreateDevice(this, descriptor);

    public nuint EnumerateFeatures(FeatureName* features) => WebGPU_FFI.AdapterEnumerateFeatures(this, features);

    public Status GetFormatCapabilities(TextureFormat format, FormatCapabilities* capabilities) => WebGPU_FFI.AdapterGetFormatCapabilities(this, format, capabilities);

    public Status GetInfo(AdapterInfoFFI* info) => WebGPU_FFI.AdapterGetInfo(this, info);

    public InstanceHandle GetInstance() => WebGPU_FFI.AdapterGetInstance(this);

    public Status GetLimits(SupportedLimits* limits) => WebGPU_FFI.AdapterGetLimits(this, limits);

    public WebGPUBool HasFeature(FeatureName feature) => WebGPU_FFI.AdapterHasFeature(this, feature);

    /// <summary>
    /// Requests a device from the adapter.
    /// This is a one-time action: if a device is returned successfully,
    /// the adapter becomes {{adapter/state/"consumed"}}.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="WebGpuSharp.Device"/> to request.</param>
    public void RequestDevice(DeviceDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<RequestDeviceStatus, DeviceHandle, byte*, void*, void> callback, void* userdata) => WebGPU_FFI.AdapterRequestDevice(this, descriptor, callback, userdata);

    public Future RequestDevice(DeviceDescriptorFFI* options, RequestDeviceCallbackInfo2FFI callbackInfo) => WebGPU_FFI.AdapterRequestDevice2(this, options, callbackInfo);

    public Future RequestDeviceF(DeviceDescriptorFFI* options, RequestDeviceCallbackInfoFFI callbackInfo) => WebGPU_FFI.AdapterRequestDeviceF(this, options, callbackInfo);

    public void AddRef() => WebGPU_FFI.AdapterAddRef(this);

    public void Release() => WebGPU_FFI.AdapterRelease(this);

}
