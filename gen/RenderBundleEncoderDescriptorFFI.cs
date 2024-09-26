using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderBundleEncoderDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public nuint ColorFormatCount;
    public TextureFormat* ColorFormats;
    public TextureFormat DepthStencilFormat;
    public uint SampleCount;
    /// <summary>
    /// If `true`, indicates that the render bundle does not modify the depth component of the <see cref="FFI.RenderPassDepthStencilAttachment"/>of any render pass the render bundle is executed
    /// in.
    /// Seeread-only depth-stencil.
    /// </summary>
    public WebGPUBool DepthReadOnly = false;
    /// <summary>
    /// If `true`, indicates that the render bundle does not modify the stencil component of the <see cref="FFI.RenderPassDepthStencilAttachment"/>of any render pass the render bundle is executed
    /// in.
    /// Seeread-only depth-stencil.
    /// </summary>
    public WebGPUBool StencilReadOnly = false;

    public RenderBundleEncoderDescriptorFFI()
    {
    }

}
