using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct TextureBindingLayout
{
    public ChainedStruct* NextInChain;
    public TextureSampleType SampleType = TextureSampleType.Float;
    public TextureViewDimension ViewDimension = TextureViewDimension.D2;
    public WebGPUBool Multisampled = false;

    public TextureBindingLayout()
    {
    }

}
