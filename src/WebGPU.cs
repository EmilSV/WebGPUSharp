using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;
using WebGPUSharp.Internal;

namespace WebGpuSharp;

public static unsafe partial class WebGPU
{
    /// <inheritdoc cref="WebGPU_FFI.CreateInstance" />
    [SkipLocalsInit]
    public static Instance? CreateInstance()
    {
        if (!WebGPU_FFI.HasInstanceFeature(InstanceFeatureName.TimedWaitAny))
        {
            throw new NotSupportedException("The WebGPU implementation does not support the TimedWaitAny instance feature, which is required by WebGPUSharp.");
        }

        var requiredFeature = InstanceFeatureName.TimedWaitAny;
        InstanceDescriptorFFI ffiDescriptor = new()
        {
            RequiredFeatureCount = 1,
            RequiredFeatures = &requiredFeature,
            RequiredLimits = null
        };

        InstanceHandle handle = WebGPU_FFI.CreateInstance(&ffiDescriptor);
        if (handle == InstanceHandle.Null)
        {
            return null;
        }
        InstanceLimits instanceFeatures = default;
        WebGPU_FFI.GetInstanceLimits(&instanceFeatures);
        var eventHandler = new WebGPUEventHandler(handle, (int)instanceFeatures.TimedWaitAnyMaxCount);
        eventHandler.Start();

        return new Instance(handle, eventHandler);
    }

    /// <inheritdoc cref="WebGPU_FFI.CreateInstance(InstanceDescriptorFFI*)" />
    [SkipLocalsInit]
    public static Instance? CreateInstance(in InstanceDescriptor descriptor)
    {
        if (!WebGPU_FFI.HasInstanceFeature(InstanceFeatureName.TimedWaitAny))
        {
            throw new NotSupportedException("The WebGPU implementation does not support the TimedWaitAny instance feature, which is required by WebGPUSharp.");
        }

        bool hasWaitingFeature = false;
        foreach (var feature in descriptor.RequiredFeatures)
        {
            if (feature == InstanceFeatureName.TimedWaitAny)
            {
                hasWaitingFeature = true;
                break;
            }
        }

        Span<InstanceFeatureName> featuresWithWait = hasWaitingFeature
            ? []
            : stackalloc InstanceFeatureName[descriptor.RequiredFeatures.Length + 1];
        ReadOnlySpan<InstanceFeatureName> requiredFeatures = descriptor.RequiredFeatures;

        if (!hasWaitingFeature)
        {
            descriptor.RequiredFeatures.CopyTo(featuresWithWait);
            featuresWithWait[^1] = InstanceFeatureName.TimedWaitAny;
#pragma warning disable CS9080 // Use of variable in this context may expose referenced variables outside of their declaration scope
            requiredFeatures = featuresWithWait;
#pragma warning restore CS9080 // Use of variable in this context may expose referenced variables outside of their declaration scope
        }

        fixed (InstanceLimits* requiredLimitsPtr = &Nullable.GetValueRefOrDefaultRef(in descriptor.RequiredLimits))
        fixed (InstanceFeatureName* featuresPtr = requiredFeatures)
        {
            nuint featureCount = (nuint)descriptor.RequiredFeatures.Length;

            InstanceDescriptorFFI ffiDescriptor = new()
            {
                RequiredFeatureCount = featureCount,
                RequiredFeatures = featureCount == 0 ? null : featuresPtr,
                RequiredLimits = requiredLimitsPtr
            };

            InstanceHandle handle = WebGPU_FFI.CreateInstance(&ffiDescriptor);
            if (handle == InstanceHandle.Null)
            {
                return null;
            }
            InstanceLimits instanceFeatures = default;
            WebGPU_FFI.GetInstanceLimits(&instanceFeatures);
            var eventHandler = new WebGPUEventHandler(handle, (int)instanceFeatures.TimedWaitAnyMaxCount);
            eventHandler.Start();

            return new Instance(handle, eventHandler);
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