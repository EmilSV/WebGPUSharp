using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// The <see cref="SupportedFeaturesFFI" /> struct is used to pass a list of supported features to the WebGPU API.
/// </summary>
public unsafe partial struct SupportedFeaturesFFI
{
    /// <summary>
    /// The number of items in the <see cref="Features" /> sequence.
    /// </summary>
    public nuint FeatureCount;
    /// <summary>
    /// The features supported by the WebGPU API.
    /// </summary>
    public FeatureName* Features;

    public SupportedFeaturesFFI() { }

}
