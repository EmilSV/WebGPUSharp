using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SupportedFeaturesFFI
{
    public nuint FeatureCount;
    public FeatureName* Features;

    public SupportedFeaturesFFI() { }

}
