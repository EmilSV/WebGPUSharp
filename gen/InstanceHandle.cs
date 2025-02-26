using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Context for all other WebGPU objects.
/// This is the first thing you create when using WebGPU. Its primary use is to create <see cref="AdapterHandle" /> and <see cref="SurfaceHandle" />.
/// </summary>
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

    /// <summary>
    /// Creates a new surface targeting a given window/canvas/surface/etc..
    /// </summary>
    public SurfaceHandle CreateSurface(SurfaceDescriptorFFI* descriptor) => WebGPU_FFI.InstanceCreateSurface(this, descriptor);

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

    public void AddRef() => WebGPU_FFI.InstanceAddRef(this);

    public void Release() => WebGPU_FFI.InstanceRelease(this);

}
