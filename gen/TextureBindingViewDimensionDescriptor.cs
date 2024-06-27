using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct TextureBindingViewDimensionDescriptor
{
    public ChainedStruct Chain;
    public TextureViewDimension TextureBindingViewDimension;

    public TextureBindingViewDimensionDescriptor()
    {
    }


    public TextureBindingViewDimensionDescriptor(ChainedStruct chain = default, TextureViewDimension textureBindingViewDimension = default)
    {
        this.Chain = chain;
        this.TextureBindingViewDimension = textureBindingViewDimension;
    }

}
