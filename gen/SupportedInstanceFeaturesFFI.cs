using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SupportedInstanceFeaturesFFI
{
    public nuint FeatureCount;
    public InstanceFeatureName* Features;

    public SupportedInstanceFeaturesFFI() { }

}
