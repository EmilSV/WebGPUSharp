using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="RequestAdapterOptionsFFI"/>
public struct RequestAdapterOptions :
    IWebGpuFFIConvertible<RequestAdapterOptions, RequestAdapterOptionsFFI>
{
    /// <inheritdoc cref="RequestAdapterOptionsFFI.CompatibleSurface"/>
    public required Surface CompatibleSurface;
    /// <inheritdoc cref="RequestAdapterOptionsFFI.PowerPreference"/>
    public PowerPreference PowerPreference;
    /// <inheritdoc cref="RequestAdapterOptionsFFI.BackendType"/>
    public BackendType BackendType;
    /// <inheritdoc cref="RequestAdapterOptionsFFI.ForceFallbackAdapter"/>
    public bool ForceFallbackAdapter = false;

    public RequestAdapterOptions()
    {
    }

    static unsafe void IWebGpuFFIConvertible<RequestAdapterOptions, RequestAdapterOptionsFFI>.UnsafeConvertToFFI(
        in RequestAdapterOptions input, out RequestAdapterOptionsFFI dest)
    {
        dest = new()
        {
            CompatibleSurface = WebGPUMarshal.GetBorrowHandle(input.CompatibleSurface),
            PowerPreference = input.PowerPreference,
            BackendType = input.BackendType,
            ForceFallbackAdapter = input.ForceFallbackAdapter
        };
    }

    static void IWebGpuFFIConvertibleAlloc<RequestAdapterOptions, RequestAdapterOptionsFFI>.UnsafeConvertToFFI(
        in RequestAdapterOptions input, WebGpuAllocatorHandle allocator, out RequestAdapterOptionsFFI dest)
    {
        WebGPUMarshal.ToFFI(input, out dest);
    }
}