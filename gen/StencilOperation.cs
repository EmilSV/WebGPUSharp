using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Operation to perform on the stencil value.
/// </summary>
public enum StencilOperation
{
    /// <summary>
    /// No value is passed for this argument
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Keep the current stencil value.
    /// </summary>
    Keep = 1,
    /// <summary>
    /// Set the stencil value to `0`.
    /// </summary>
    Zero = 2,
    /// <summary>
    /// Set the stencil value to {{RenderState/stencilReference}}.
    /// </summary>
    Replace = 3,
    /// <summary>
    /// Bitwise-invert the current stencil value.
    /// </summary>
    Invert = 4,
    /// <summary>
    /// Increments the current stencil value, clamping to the maximum representable value of the
    ///  <see cref="RenderPassDescriptor.DepthStencilAttachment"/>'s stencil aspect.
    /// </summary>
    IncrementClamp = 5,
    /// <summary>
    /// Decrement the current stencil value, clamping to `0`.
    /// </summary>
    DecrementClamp = 6,
    /// <summary>
    /// Increments the current stencil value, wrapping to zero if the value exceeds the maximum
    /// representable value of the  <see cref="RenderPassDescriptor.DepthStencilAttachment"/>'s stencil
    /// aspect.
    /// </summary>
    IncrementWrap = 7,
    /// <summary>
    /// Decrement the current stencil value, wrapping to the maximum representable value of the
    ///  <see cref="RenderPassDescriptor.DepthStencilAttachment"/>'s stencil aspect if the value goes below
    /// `0`.
    /// </summary>
    DecrementWrap = 8,
}
