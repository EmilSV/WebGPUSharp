using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;

/// <inheritdoc cref="RequestAdapterOptionsFFI"/>
public struct RequestAdapterOptions :
    IWebGpuMarshallable<RequestAdapterOptions, RequestAdapterOptionsFFI>
{

    /// <inheritdoc cref="RequestAdapterOptionsFFI.FeatureLevel"/>
    public FeatureLevel FeatureLevel = FeatureLevel.Core;
    /// <inheritdoc cref="RequestAdapterOptionsFFI.PowerPreference"/>
    public PowerPreference PowerPreference;
    /// <inheritdoc cref="RequestAdapterOptionsFFI.ForceFallbackAdapter"/>
    public bool ForceFallbackAdapter = false;
    /// <inheritdoc cref="RequestAdapterOptionsFFI.BackendType"/>
    public BackendType BackendType;
    /// <inheritdoc cref="RequestAdapterOptionsFFI.CompatibleSurface"/>
    public required Surface CompatibleSurface;

    public RequestAdapterOptions()
    {
    }

    static unsafe void IWebGpuMarshallable<RequestAdapterOptions, RequestAdapterOptionsFFI>.MarshalToFFI(
        in RequestAdapterOptions input, out RequestAdapterOptionsFFI dest)
    {
        dest = new()
        {
            FeatureLevel = input.FeatureLevel,
            PowerPreference = input.PowerPreference,
            ForceFallbackAdapter = input.ForceFallbackAdapter,
            BackendType = input.BackendType,
            CompatibleSurface = GetHandle(input.CompatibleSurface),
        };
    }
}