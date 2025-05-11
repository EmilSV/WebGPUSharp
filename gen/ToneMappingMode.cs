using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes the tone mapping mode. Allows WebGPU to draw colors brighter than white (#FFFFFF)
/// </summary>
public enum ToneMappingMode
{
    /// <summary>
    /// The default behavior restricts content to the SDR range of the screen.
    /// This mode is accomplished by clamping all color values in the color space of
    /// the screen to the [0, 1] interval.
    /// </summary>
    Standard = 1,
    /// <summary>
    /// Unlocks the full HDR range of the screen.
    /// This mode matches <see cref="Standard" /> in the [0, 1] range of the screen.
    /// Clamping or projection is done to the extended dynamic range of the screen but not [0, 1].
    /// </summary>
    Extended = 2,
}
