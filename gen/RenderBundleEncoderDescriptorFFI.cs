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
    public WebGPUBool DepthReadOnly;
    public WebGPUBool StencilReadOnly;

    public RenderBundleEncoderDescriptorFFI()
    {
    }


    public RenderBundleEncoderDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, nuint colorFormatCount = default, TextureFormat* colorFormats = default, TextureFormat depthStencilFormat = default, uint sampleCount = default, WebGPUBool depthReadOnly = false, WebGPUBool stencilReadOnly = false)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.ColorFormatCount = colorFormatCount;
        this.ColorFormats = colorFormats;
        this.DepthStencilFormat = depthStencilFormat;
        this.SampleCount = sampleCount;
        this.DepthReadOnly = depthReadOnly;
        this.StencilReadOnly = stencilReadOnly;
    }


    public RenderBundleEncoderDescriptorFFI(byte* label = default, nuint colorFormatCount = default, TextureFormat* colorFormats = default, TextureFormat depthStencilFormat = default, uint sampleCount = default, WebGPUBool depthReadOnly = false, WebGPUBool stencilReadOnly = false)
    {
        this.Label = label;
        this.ColorFormatCount = colorFormatCount;
        this.ColorFormats = colorFormats;
        this.DepthStencilFormat = depthStencilFormat;
        this.SampleCount = sampleCount;
        this.DepthReadOnly = depthReadOnly;
        this.StencilReadOnly = stencilReadOnly;
    }

}
