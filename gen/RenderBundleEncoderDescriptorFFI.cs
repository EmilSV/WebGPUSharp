using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a <see cref="RenderBundleHandle" />.
/// 
/// For use with <see cref="DeviceHandle.CreateRenderBundleEncoder" />.
/// </summary>
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
    /// <summary>
    /// Debug label of the render bundle encoder.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// The number of color formats in the <see cref="ColorFormats" /> sequence.
    /// </summary>
    public nuint ColorFormatCount;
    /// <summary>
    /// The formats of the color attachments that this render bundle is capable to rendering to.
    /// This must match the formats of the color attachments in the render pass this render bundle is executed in.
    /// </summary>
    public TextureFormat* ColorFormats;
    /// <summary>
    /// The depth stencil format of the render target.
    /// </summary>
    public TextureFormat DepthStencilFormat;
    /// <summary>
    /// The sample count of the render targets.
    /// </summary>
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
