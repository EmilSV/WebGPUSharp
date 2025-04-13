using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderBundleEncoderDescriptorFFI
{
    /// <summary>
    /// Pointer to the first element in a chain of structures that extends this descriptor.
    /// </summary>
    /// <remarks>
    /// Enables struct-chaining, a pattern that extends existing structs with new members while 
    /// maintaining API compatibility. Each extension struct must be properly initialized with 
    /// correct sType values and linked together. For detailed information about struct-chaining,
    /// see: <see href="https://webgpu-native.github.io/webgpu-headers/StructChaining.html"/>
    /// </remarks>
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
