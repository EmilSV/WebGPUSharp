using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// The <see cref="SupportedFeaturesFFI" /> struct is used to pass a list of supported features to the WebGPU API.
/// </summary>
public unsafe partial struct SupportedFeaturesFFI
{
    public nuint FeatureCount;
    public FeatureName* Features;

    public SupportedFeaturesFFI() { }

}
