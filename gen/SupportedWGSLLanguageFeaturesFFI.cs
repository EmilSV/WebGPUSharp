using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A structure that contains the supported WGSL extensions language features by the WebGPU implementation.
/// </summary>
public unsafe partial struct SupportedWGSLLanguageFeaturesFFI
{
    /// <summary>
    /// The count of item in the <see cref="Features" /> sequence.
    /// </summary>
    public nuint FeatureCount;
    /// <summary>
    /// The the WGSL language extensions supported by the WebGPU implementation.
    /// </summary>
    public WGSLLanguageFeatureName* Features;

    public SupportedWGSLLanguageFeaturesFFI() { }

}
