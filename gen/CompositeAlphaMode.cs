using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Specifies how the alpha channel of the textures should be handled during compositing.
/// </summary>
public enum CompositeAlphaMode
{
    /// <summary>
    /// Chooses either Opaque or Inherit automatically, depending on the AlphaMode that the current surface can support.
    /// </summary>
    Auto = 0,
    /// <summary>
    /// The alpha channel, if it exists, of the textures is ignored in the compositing process. Instead, the textures is treated as if it has a constant alpha of 1.0.
    /// </summary>
    Opaque = 1,
    /// <summary>
    /// The alpha channel, if it exists, of the textures is respected in the compositing process. The non-alpha channels of the textures are expected to already be multiplied by the alpha channel by the application.
    /// </summary>
    Premultiplied = 2,
    /// <summary>
    /// The alpha channel, if it exists, of the textures is respected in the compositing process. The non-alpha channels of the textures are not expected to already be multiplied by the alpha channel by the application; instead, the compositor will multiply the non-alpha channels of the texture by the alpha channel during compositing.
    /// </summary>
    Unpremultiplied = 3,
    /// <summary>
    /// The alpha channel, if it exists, of the textures is unknown for processing during compositing. Instead, the application is responsible for setting the composite alpha blending mode using native WSI command. If not set, then a platform-specific default will be used.
    /// </summary>
    Inherit = 4,
}
