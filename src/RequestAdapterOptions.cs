using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="FFI.RequestAdapterOptionsFFI"/>
public struct RequestAdapterOptions :
    IWebGpuFFIConvertible<RequestAdapterOptions, RequestAdapterOptionsFFI>
{
    /// <inheritdoc cref="FFI.RequestAdapterOptionsFFI.CompatibleSurface"/>
    public required SurfaceBase CompatibleSurface;
    /// <inheritdoc cref="FFI.RequestAdapterOptionsFFI.PowerPreference"/>
    public PowerPreference PowerPreference;
    /// <inheritdoc cref="FFI.RequestAdapterOptionsFFI.BackendType"/>
    public BackendType BackendType;
    /// <inheritdoc cref="FFI.RequestAdapterOptionsFFI.ForceFallbackAdapter"/>
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