using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct RequestAdapterOptions :
    IWebGpuFFIConvertible<RequestAdapterOptions, RequestAdapterOptionsFFI>
{
    public required Surface CompatibleSurface;
    public PowerPreference PowerPreference;
    public BackendType BackendType;
    public bool ForceFallbackAdapter = false;

    public RequestAdapterOptions()
    {
    }

    static unsafe void IWebGpuFFIConvertible<RequestAdapterOptions, RequestAdapterOptionsFFI>.UnsafeConvertToFFI(
        in RequestAdapterOptions input, out RequestAdapterOptionsFFI dest)
    {
        dest = new(
            compatibleSurface: WebGPUMarshal.ToFFI<Surface, SurfaceHandle>(input.CompatibleSurface),
            powerPreference: input.PowerPreference,
            backendType: input.BackendType,
            forceFallbackAdapter: input.ForceFallbackAdapter
        );
    }

    static void IWebGpuFFIConvertibleAlloc<RequestAdapterOptions, RequestAdapterOptionsFFI>.UnsafeConvertToFFI(
        in RequestAdapterOptions input, WebGpuAllocatorHandle allocator, out RequestAdapterOptionsFFI dest)
    {
        WebGPUMarshal.ToFFI(input, out dest);
    }
}