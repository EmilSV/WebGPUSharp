using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderBundleEncoderDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label = StringViewFFI.NullValue;
    public nuint ColorFormatCount;
    public TextureFormat* ColorFormats;
    public TextureFormat DepthStencilFormat;
    public uint SampleCount;
    /// <summary>
    /// If `true`, indicates that the render bundle does not modify the depth component of the
    ///  <see cref="RenderPassDepthStencilAttachment"/> of any render pass the render bundle is executed
    /// in.
    /// See read-only depth-stencil.
    /// </summary>
    public WebGPUBool DepthReadOnly = false;
    /// <summary>
    /// If `true`, indicates that the render bundle does not modify the stencil component of the
    ///  <see cref="RenderPassDepthStencilAttachment"/> of any render pass the render bundle is executed
    /// in.
    /// See read-only depth-stencil.
    /// </summary>
    public WebGPUBool StencilReadOnly = false;

    public RenderBundleEncoderDescriptorFFI() { }

}
