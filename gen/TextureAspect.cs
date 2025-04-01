using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Kind of data the texture holds.
/// </summary>
public enum TextureAspect
{
    Undefined = 0,
    /// <summary>
    /// All available aspects of the texture format will be accessible to the texture view. For
    /// color formats the color aspect will be accessible. For
    /// combined depth-stencil formats both the depth and stencil aspects will be accessible.
    /// Depth-or-stencil formats with a single aspect will only make that aspect accessible.
    /// The GPUTextureAspect.set of aspects is =aspect.color=], [=aspect.depth=], [=aspect.stencil=.
    /// </summary>
    All = 1,
    /// <summary>
    /// Only the stencil aspect of a depth-or-stencil format format will be accessible to the
    /// texture view.
    /// The GPUTextureAspect.set of aspects is =aspect.stencil=.
    /// </summary>
    StencilOnly = 2,
    /// <summary>
    /// Only the depth aspect of a depth-or-stencil format format will be accessible to the
    /// texture view.
    /// The GPUTextureAspect.set of aspects is =aspect.depth=.
    /// </summary>
    DepthOnly = 3,
    Plane0Only = 327680,
    Plane1Only = 327681,
    Plane2Only = 327682,
}
