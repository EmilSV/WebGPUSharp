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

}
