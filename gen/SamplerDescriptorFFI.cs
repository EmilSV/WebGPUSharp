using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a Sampler.
/// 
/// For use with <see cref="DeviceHandle.CreateSampler" />.
/// </summary>
public unsafe partial struct SamplerDescriptorFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Debug label of the sampler.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;
    /// <summary>
    /// How to deal with out of bounds accesses in the u (i.e. x) direction.
    /// </summary>
    public AddressMode AddressModeU = AddressMode.ClampToEdge;
    /// <summary>
    /// How to deal with out of bounds accesses in the v (i.e. y) direction
    /// </summary>
    public AddressMode AddressModeV = AddressMode.ClampToEdge;
    /// <summary>
    /// How to deal with out of bounds accesses in the w (i.e. z) direction
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
    /// <summary>
    /// Minimum level of detail (i.e. mip level) to use
    /// </summary>
    public float LodMinClamp = 0;
    /// <summary>
    /// Maximum level of detail (i.e. mip level) to use
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
    /// enabled when  <see cref="SamplerDescriptor.MaxAnisotropy"/> is &gt; 1 and the implementation supports it.
    /// Anisotropic filtering improves the image quality of textures sampled at oblique viewing
    /// angles. Higher  <see cref="SamplerDescriptor.MaxAnisotropy"/> values indicate the maximum ratio of
    /// anisotropy supported when filtering.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Most implementations support  <see cref="SamplerDescriptor.MaxAnisotropy"/> values in range
    /// between 1 and 16, inclusive. The used value of  <see cref="SamplerDescriptor.MaxAnisotropy"/>
    /// will be clamped to the maximum value that the platform supports.
    /// The precise filtering behavior is implementation-dependent.
    /// 
    /// </remarks>
    public ushort MaxAnisotropy = 1;

    public SamplerDescriptorFFI() { }

}
