using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct TextureComponentSwizzleDescriptor
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    public TextureComponentSwizzle Swizzle = new();

    public TextureComponentSwizzleDescriptor() { }

}
