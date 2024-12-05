using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SamplerDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label = new();
    public AddressMode AddressModeU = AddressMode.ClampToEdge;
    public AddressMode AddressModeV = AddressMode.ClampToEdge;
    /// <summary>
    /// Specifies the  <see cref="AddressMode">address modes</see> for the texture width, height, and depth
    /// coordinates, respectively.
    /// </summary>
    public AddressMode AddressModeW = AddressMode.ClampToEdge;
    /// <summary>
    /// Specifies the sampling behavior when the sampled area is smaller than or equal to one
    /// texel.
    /// </summary>
    public FilterMode MagFilter = FilterMode.Nearest;
    /// <summary>
    /// Specifies the sampling behavior when the sampled area is larger than one texel.
    /// </summary>
    public FilterMode MinFilter = FilterMode.Nearest;
    /// <summary>
    /// Specifies behavior for sampling between mipmap levels.
    /// </summary>
    public MipmapFilterMode MipmapFilter = MipmapFilterMode.Nearest;
    public float LodMinClamp = 0;
    /// <summary>
    /// Specifies the minimum and maximum levels of detail, respectively, used internally when
    /// sampling a texture.
    /// </summary>
    public float LodMaxClamp = 32;
    /// <summary>
    /// When provided the sampler will be a comparison sampler with the specified
    ///  <see cref="CompareFunction"/>.
    /// Note: Comparison samplers may use filtering, but the sampling results will be
    /// implementation-dependent and may differ from the normal filtering rules.
    /// </summary>
    public CompareFunction Compare;
    /// <summary>
    /// Specifies the maximum anisotropy value clamp used by the sampler. Anisotropic filtering is
    /// enabled when  <see cref="WebGpuSharp.SamplerDescriptor.MaxAnisotropy"/> is &gt; 1 and the implementation supports it.
    /// Anisotropic filtering improves the image quality of textures sampled at oblique viewing
    /// angles. Higher  <see cref="WebGpuSharp.SamplerDescriptor.MaxAnisotropy"/> values indicate the maximum ratio of
    /// anisotropy supported when filtering.
    /// <remarks>
    /// 
    /// Most implementations support  <see cref="WebGpuSharp.SamplerDescriptor.MaxAnisotropy"/> values in range
    /// between 1 and 16, inclusive. The used value of  <see cref="WebGpuSharp.SamplerDescriptor.MaxAnisotropy"/>
    /// will be clamped to the maximum value that the platform supports.
    /// The precise filtering behavior is implementation-dependent.
    /// 
    /// </remarks>
    /// </summary>
    public ushort MaxAnisotropy = 1;

    public SamplerDescriptorFFI() { }

}
