using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes the depth/stencil state in a render pipeline.
/// </summary>
public unsafe partial struct DepthStencilState
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The  <see cref="TextureViewDescriptor.Format"/> of  <see cref="RenderPassDescriptor.DepthStencilAttachment"/>
    /// this  <see cref="RenderPipeline"/> will be compatible with.
    /// </summary>
    public required TextureFormat Format;
    /// <summary>
    /// Indicates if this  <see cref="RenderPipeline"/> can modify
    ///  <see cref="RenderPassDescriptor.DepthStencilAttachment"/> depth values.
    /// </summary>
    public OptionalBool DepthWriteEnabled;
    /// <summary>
    /// The comparison operation used to test fragment depths against
    ///  <see cref="RenderPassDescriptor.DepthStencilAttachment"/> depth values.
    /// </summary>
    public CompareFunction DepthCompare;
    /// <summary>
    /// Defines how stencil comparisons and operations are performed for front-facing primitives.
    /// </summary>
    public StencilFaceState StencilFront = new();
    /// <summary>
    /// Defines how stencil comparisons and operations are performed for back-facing primitives.
    /// </summary>
    public StencilFaceState StencilBack = new();
    /// <summary>
    /// Bitmask controlling which  <see cref="RenderPassDescriptor.DepthStencilAttachment"/> stencil value
    /// bits are read when performing stencil comparison tests.
    /// </summary>
    public uint StencilReadMask = 0xFFFFFFFF;
    /// <summary>
    /// Bitmask controlling which  <see cref="RenderPassDescriptor.DepthStencilAttachment"/> stencil value
    /// bits are written to when performing stencil operations.
    /// </summary>
    public uint StencilWriteMask = 0xFFFFFFFF;
    /// <summary>
    /// Constant depth bias added to each triangle fragment. See biased fragment depth for details.
    /// </summary>
    public int DepthBias = 0;
    /// <summary>
    /// Depth bias that scales with the triangle fragment’s slope. See biased fragment depth for details.
    /// </summary>
    public float DepthBiasSlopeScale = 0;
    /// <summary>
    /// The maximum depth bias of a triangle fragment. See biased fragment depth for details.
    /// </summary>
    public float DepthBiasClamp = 0;

    public DepthStencilState() { }

}
