using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;

/// <inheritdoc cref="RequestAdapterOptionsFFI"/>
public struct RequestAdapterOptions :
    IWebGpuMarshallable<RequestAdapterOptions, RequestAdapterOptionsFFI>
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

    static unsafe void IWebGpuMarshallable<RequestAdapterOptions, RequestAdapterOptionsFFI>.MarshalToFFI(
        in RequestAdapterOptions input, out RequestAdapterOptionsFFI dest)
    {
        dest = new()
        {
            CompatibleSurface = GetBorrowHandle(input.CompatibleSurface),
            PowerPreference = input.PowerPreference,
            BackendType = input.BackendType,
            ForceFallbackAdapter = input.ForceFallbackAdapter
        };
    }
}