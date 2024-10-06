using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ColorTargetStateFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The  <see cref="TextureFormat"/> of this color target. The pipeline will only be compatible with
    ///  <see cref="WebGpuSharp.RenderPassEncoder"/>s which use a  <see cref="WebGpuSharp.TextureView"/> of this format in the
    /// corresponding color attachment.
    /// </summary>
    public required TextureFormat Format;
    /// <summary>
    /// The blending behavior for this color target. If left undefined, disables blending for this
    /// color target.
    /// </summary>
    public BlendState* Blend;
    /// <summary>
    /// Bitmask controlling which channels are are written to when drawing to this color target.
    /// </summary>
    public ColorWriteMask WriteMask = ColorWriteMask.All;

    public ColorTargetStateFFI()
    {
    }

}
