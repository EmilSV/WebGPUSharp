using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct RequestAdapterOptions :
    IWebGpuFFIConvertible<RequestAdapterOptions, RequestAdapterOptionsFFI>
{
    public Surface CompatibleSurface;
    public PowerPreference PowerPreference;
    public BackendType BackendType;
    public bool ForceFallbackAdapter;
    public bool CompatibilityMode;

    static void IWebGpuFFIConvertible<RequestAdapterOptions, RequestAdapterOptionsFFI>.UnsafeConvertToFFI(
        in RequestAdapterOptions input, out RequestAdapterOptionsFFI dest)
    {
        dest = new(
            compatibleSurface : WebGPUMarshal.ToFFI<Surface, SurfaceHandle>(input.CompatibleSurface),
            powerPreference: input.PowerPreference,
            backendType: input.BackendType,
            forceFallbackAdapter: input.ForceFallbackAdapter,
            compatibilityMode: input.CompatibilityMode
        );
    }

    static void IWebGpuFFIConvertibleAlloc<RequestAdapterOptions, RequestAdapterOptionsFFI>.UnsafeConvertToFFI(
        in RequestAdapterOptions input, WebGpuAllocatorHandle allocator, out RequestAdapterOptionsFFI dest)
    {
        WebGPUMarshal.ToFFI(input, out dest);
    }
}