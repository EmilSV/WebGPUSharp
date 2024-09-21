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


    public TextureBindingLayout(ChainedStruct* nextInChain = default, TextureSampleType sampleType = TextureSampleType.Float, TextureViewDimension viewDimension = TextureViewDimension.D2, WebGPUBool multisampled = false)
    {
        this.NextInChain = nextInChain;
        this.SampleType = sampleType;
        this.ViewDimension = viewDimension;
        this.Multisampled = multisampled;
    }


    public TextureBindingLayout(TextureSampleType sampleType = TextureSampleType.Float, TextureViewDimension viewDimension = TextureViewDimension.D2, WebGPUBool multisampled = false)
    {
        this.SampleType = sampleType;
        this.ViewDimension = viewDimension;
        this.Multisampled = multisampled;
    }

}
