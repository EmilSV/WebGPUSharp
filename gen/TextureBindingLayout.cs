using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct TextureBindingLayout
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Indicates the type required for texture views bound to this binding.
    /// </summary>
    public TextureSampleType SampleType = TextureSampleType.Float;
    /// <summary>
    /// Indicates the required  <see cref="WebGpuSharp.TextureViewDescriptor.Dimension"/> for texture views bound to
    /// this binding.
    /// </summary>
    public TextureViewDimension ViewDimension = TextureViewDimension.D2;
    /// <summary>
    /// Indicates whether or not texture views bound to this binding must be multisampled.
    /// </summary>
    public WebGPUBool Multisampled = false;

    public TextureBindingLayout()
    {
    }

}
