using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct InstanceHandle : IEquatable<InstanceHandle>
{
    private readonly nuint _ptr;
    public static InstanceHandle Null
    {
        get => new(nuint.Zero);
    }

    public InstanceHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(InstanceHandle handle) => handle._ptr;
    public static bool operator ==(InstanceHandle left, InstanceHandle right) => left._ptr == right._ptr;
    public static bool operator !=(InstanceHandle left, InstanceHandle right) => left._ptr != right._ptr;
    public static bool operator ==(InstanceHandle left, InstanceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(InstanceHandle left, InstanceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(InstanceHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(InstanceHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(InstanceHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is InstanceHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
    public SurfaceHandle CreateSurface(SurfaceDescriptorFFI* descriptor) => WebGPU_FFI.InstanceCreateSurface(this, descriptor);
    public nuint EnumerateWGSLLanguageFeatures(WGSLFeatureName* features) => WebGPU_FFI.InstanceEnumerateWGSLLanguageFeatures(this, features);
    public WebGPUBool HasWGSLLanguageFeature(WGSLFeatureName feature) => WebGPU_FFI.InstanceHasWGSLLanguageFeature(this, feature);
    public void ProcessEvents() => WebGPU_FFI.InstanceProcessEvents(this);
    public void RequestAdapter(RequestAdapterOptionsFFI* options, delegate* unmanaged[Cdecl]<RequestAdapterStatus, AdapterHandle, byte*, void*, void> callback, void* userdata) => WebGPU_FFI.InstanceRequestAdapter(this, options, callback, userdata);
    public WaitStatus WaitAny(nuint futureCount, FutureWaitInfo* futures, ulong timeoutNS) => WebGPU_FFI.InstanceWaitAny(this, futureCount, futures, timeoutNS);
    public void AddRef() => WebGPU_FFI.InstanceAddRef(this);
    public void Release() => WebGPU_FFI.InstanceRelease(this);
}
