using System.Buffers;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct AdapterHandle :
    IDisposable, IWebGpuHandleNeedInstance<AdapterHandle, Adapter>
{
    /// <returns>The features supported.</returns>
    /// <inheritdoc cref="GetFeatures(SupportedFeaturesFFI*)" />
    public readonly FeatureName[] GetFeatures()
    {
        bool gotFeatures = false;
        SupportedFeaturesFFI supportedFeaturesFFI;
        Unsafe.SkipInit(out supportedFeaturesFFI);
        try
        {
            WebGPU_FFI.AdapterGetFeatures(this, &supportedFeaturesFFI);
            gotFeatures = true;
            FeatureName[] features = new FeatureName[supportedFeaturesFFI.FeatureCount];
            var supportedFeaturesFFISpan = new Span<FeatureName>(supportedFeaturesFFI.Features, (int)supportedFeaturesFFI.FeatureCount);
            supportedFeaturesFFISpan.CopyTo(features);
            return features;
        }
        finally
        {
            if (gotFeatures)
            {
                WebGPU_FFI.SupportedFeaturesFreeMembers(supportedFeaturesFFI);
            }
        }
    }

    /// <returns>If true the call was successful, false otherwise.</returns>
    /// <inheritdoc cref="GetLimits(Limits*)"/>
    public readonly bool GetLimits(out Limits limits)
    {
        limits = default;
        fixed (Limits* limitsPtr = &limits)
        {
            return WebGPU_FFI.AdapterGetLimits(this, limitsPtr) == Status.Success;
        }
    }


    /// <returns>The limits or null if it failed</returns>
    /// <inheritdoc cref="GetLimits(Limits*)"/>
    public readonly Limits? GetLimits()
    {
        Limits limits = default;
        if (WebGPU_FFI.AdapterGetLimits(this, &limits) == Status.Success)
        {
            return limits;
        }
        else
        {
            return null;
        }
    }

    /// <returns>The AdapterInfo or null if it failed</returns>
    /// <inheritdoc cref="GetInfo(AdapterInfoFFI*)"/>
    public readonly AdapterInfo? GetInfo()
    {
        AdapterInfoFFI adapterInfoFFI = default;
        WebGPU_FFI.AdapterGetInfo(this, &adapterInfoFFI);
        var outAdapterInfo = new AdapterInfo(adapterInfoFFI);
        WebGPU_FFI.AdapterInfoFreeMembers(adapterInfoFFI);
        return outAdapterInfo;
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.AdapterRelease(this);
        }
    }

    public static ref nuint AsPointer(ref AdapterHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static AdapterHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(AdapterHandle handle)
    {
        return handle == Null;
    }

    public static AdapterHandle UnsafeFromPointer(nuint pointer)
    {
        return new AdapterHandle(pointer);
    }

    public Adapter? ToSafeHandle(Instance instance)
    {
        return ToSafeHandle<Adapter, AdapterHandle>(this, instance);
    }

    public static void Reference(AdapterHandle handle)
    {
        WebGPU_FFI.AdapterAddRef(handle);
    }

    public static void Release(AdapterHandle handle)
    {
        WebGPU_FFI.AdapterRelease(handle);
    }
}