using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct TextureBindingLayout
{
    public ChainedStruct* NextInChain;
    public TextureSampleType SampleType;
    public TextureViewDimension ViewDimension;
    public WebGPUBool Multisampled;

    public TextureBindingLayout()
    {
    }


    public TextureBindingLayout(ChainedStruct* nextInChain = default, TextureSampleType sampleType = default, TextureViewDimension viewDimension = default, WebGPUBool multisampled = default)
    {
        this.NextInChain = nextInChain;
        this.SampleType = sampleType;
        this.ViewDimension = viewDimension;
        this.Multisampled = multisampled;
    }


    public TextureBindingLayout(TextureSampleType sampleType = default, TextureViewDimension viewDimension = default, WebGPUBool multisampled = default)
    {
        this.SampleType = sampleType;
        this.ViewDimension = viewDimension;
        this.Multisampled = multisampled;
    }

}
