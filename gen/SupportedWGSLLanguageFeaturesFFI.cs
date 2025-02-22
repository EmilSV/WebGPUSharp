using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SupportedWGSLLanguageFeaturesFFI
{
    public nuint FeatureCount;
    public WGSLLanguageFeatureName* Features;

    public SupportedWGSLLanguageFeaturesFFI() { }

}
