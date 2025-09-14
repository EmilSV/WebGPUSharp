using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public static unsafe partial class WebGPU
{
    /// <inheritdoc cref="WebGPU_FFI.CreateInstance" />
    public static Instance? CreateInstance()
    {
        InstanceDescriptor descriptor = new();
        return CreateInstance(in descriptor);
    }

    /// <inheritdoc cref="WebGPU_FFI.CreateInstance(InstanceDescriptorFFI*)" />
    [SkipLocalsInit]
    public static Instance? CreateInstance(in InstanceDescriptor descriptor)
    {
        fixed (InstanceLimits* requiredLimitsPtr = &Nullable.GetValueRefOrDefaultRef(in descriptor.RequiredLimits))
        fixed (InstanceFeatureName* featuresPtr = descriptor.RequiredFeatures)
        {
            nuint featureCount = (nuint)descriptor.RequiredFeatures.Length;

            InstanceDescriptorFFI ffiDescriptor = new()
            {
                RequiredFeatureCount = featureCount,
                RequiredFeatures = featureCount == 0 ? null : featuresPtr,
                RequiredLimits = requiredLimitsPtr
            };

            return WebGPU_FFI.CreateInstance(&ffiDescriptor).ToSafeHandle(false);
        }
    }

    /// <inheritdoc cref="WebGPU_FFI.GetInstanceFeatures(SupportedInstanceFeaturesFFI*)" />
    [SkipLocalsInit]
    public static SupportedInstanceFeatures GetInstanceFeatures()
    {
        SupportedInstanceFeaturesFFI ffiFeatures = default;
        try
        {
            WebGPU_FFI.GetInstanceFeatures(&ffiFeatures);
            ReadOnlySpan<InstanceFeatureName> features = new(
                pointer: ffiFeatures.Features,
                length: (int)ffiFeatures.FeatureCount
            );

            return new SupportedInstanceFeatures(features.ToArray());
        }
        finally
        {
            if (ffiFeatures.Features != null)
            {
                WebGPU_FFI.SupportedInstanceFeaturesFreeMembers(ffiFeatures);
            }
        }
    }

    /// <inheritdoc cref="WebGPU_FFI.GetInstanceLimits(InstanceLimits*)" />
    [SkipLocalsInit]
    public static InstanceLimits? GetInstanceLimits()
    {
        InstanceLimits instanceLimits = default;

        var status = WebGPU_FFI.GetInstanceLimits(&instanceLimits);
        if (status != Status.Success)
        {
            return null;
        }
        return instanceLimits;
    }


    public static WebGPUBool HasInstanceFeature(InstanceFeatureName feature) =>
       WebGPU_FFI.HasInstanceFeature(feature);
}