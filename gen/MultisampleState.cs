using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct MultisampleState
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Number of samples per pixel. This  <see cref="WebGpuSharp.RenderPipeline"/> will be compatible only
    /// with attachment textures ( <see cref="WebGpuSharp.RenderPassDescriptor.ColorAttachments"/>
    /// and  <see cref="WebGpuSharp.RenderPassDescriptor.DepthStencilAttachment"/>)
    /// with matching  <see cref="WebGpuSharp.TextureDescriptor.SampleCount"/>s.
    /// </summary>
    public uint Count = 1;
    /// <summary>
    /// Mask determining which samples are written to.
    /// </summary>
    public uint Mask = 0xFFFFFFFF;
    /// <summary>
    /// When `true` indicates that a fragment's alpha channel should be used to generate a sample
    /// coverage mask.
    /// </summary>
    public WebGPUBool AlphaToCoverageEnabled = false;

    public MultisampleState()
    {
    }

}
