using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct RequestAdapterOptions :
    IWebGpuFFIConvertible<RequestAdapterOptions, RequestAdapterOptionsFFI>
{
    public required SurfaceBase CompatibleSurface;
    public PowerPreference PowerPreference;
    public BackendType BackendType;
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