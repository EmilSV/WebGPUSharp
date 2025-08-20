using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Features that are not guaranteed to be supported. If you want to use a feature,
/// you need to first verify that the adapter supports the feature. If the adapter does not
/// support the feature, requesting a device with it enabled will fail.
/// </summary>
public enum FeatureName
{
    /// <summary>
    /// By default, polygon depth is clipped to 0-1 range before/during rasterization.
    /// Anything outside of that range is rejected, and respective fragments are not
    /// touched. With this extension, we can disabling clipping. That allows shadow map
    /// occluders to be rendered into a tighter depth range. Supported platforms:
    /// <list type="bullet"><item><description>desktops</description></item><item><description>some mobile chips</description></item></list>
    /// </summary>
    DepthClipControl = 1,
    /// <summary>
    /// Allows for explicit creation of textures of format <see cref="TextureFormat.Depth32FloatStencil8" />
    /// .
    /// Supported platforms:
    /// <list type="bullet"><item><description>Vulkan (mostly)</description></item><item><description>DX12</description></item><item><description>Metal</description></item><item><description>OpenGL</description></item></list>
    /// </summary>
    Depth32FloatStencil8 = 2,
    /// <summary>
    /// Enables use of Timestamp Queries. These queries tell the current gpu timestamp when all work before the query is finished.
    /// 
    /// This feature allows the use of
    /// 
    /// <see cref="RenderPassDescriptor.TimestampWrites" /><see cref="WebGpuSharp.ComputePassDescriptor.TimestampWrites" />
    /// to write out timestamps.
    /// 
    /// For arbitrary timestamp write commands on encoders refer to
    /// <see cref="FeatureName.TimestampQueryInsideEncoders" />. For arbitrary timestamp write commands on passes refer to <see cref="FeatureName.TimestampQueryInsidePasses" />
    /// .
    /// 
    /// They must be resolved using
    /// <see cref="CommandEncoder.ResolveQuerySet" />
    /// into a buffer, the timestamps results is in nanoseconds and stored as 64bit integers. Multiple timestamps can then be diffed to get the time for operations between them to finish.
    /// 
    /// Supported Platforms:
    /// <list type="bullet"><item><description>Vulkan</description></item><item><description>DX12</description></item><item><description>Metal</description></item></list>
    /// </summary>
    TimestampQuery = 3,
    /// <summary>
    /// Enables BCn family of compressed textures. All BCn textures use 4x4 pixel blocks with 8 or 16 bytes per block.
    /// 
    /// Compressed textures sacrifice some quality in exchange for significantly reduced bandwidth usage.
    /// 
    /// Support for this feature guarantees availability of
    /// <see cref="Webgpu.TextureUsage.CopySrc" />, <see cref="Webgpu.TextureUsage.CopyDst" /> or <see cref="Webgpu.TextureUsage.TextureBinding" /> for BCn formats. <see cref="FeatureName.TextureAdapterSpecificFormatFeatures" />
    /// may enable additional usages.
    /// 
    /// This feature guarantees availability of sliced-3d textures for BC formats when combined with
    /// <see cref="FeatureName.TextureCompressionBcSliced3d" />
    /// .
    /// 
    /// Supported Platforms:
    /// <list type="bullet"><item><description>desktops</description></item><item><description>Mobile (All Apple9 and some Apple7 and Apple8 devices)</description></item></list>
    /// </summary>
    TextureCompressionBC = 4,
    /// <summary>
    /// Allows the 3d dimension for textures with BC compressed formats.
    /// 
    /// This feature must be used in combination with TEXTURE_COMPRESSION_BC to enable 3D textures with BC compression. It does not enable the BC formats by itself.
    /// </summary>
    TextureCompressionBCSliced3D = 5,
    /// <summary>
    /// Enables ETC family of compressed textures. All ETC textures use 4x4 pixel blocks.
    /// ETC2 RGB and RGBA1 are 8 bytes per block. RTC2 RGBA8 and EAC are 16 bytes per block.
    /// 
    /// Compressed textures sacrifice some quality in exchange for significantly reduced bandwidth usage.
    /// 
    /// Support for this feature guarantees availability of
    /// <see cref="Webgpu.TextureUsage.CopySrc" />, <see cref="Webgpu.TextureUsage.CopyDst" /> or <see cref="Webgpu.TextureUsage.TextureBinding" />
    /// for ETC2 formats.
    /// <see cref="FeatureName.TextureAdapterSpecificFormatFeatures" />
    /// may enable additional usages.
    /// 
    /// Supported Platforms:
    /// <list type="bullet"><item><description>Vulkan on Intel</description></item><item><description>Mobile (some)</description></item></list>
    /// </summary>
    TextureCompressionETC2 = 6,
    /// <summary>
    /// Enables ASTC family of compressed textures. ASTC textures use pixel blocks varying from 4x4 to 12x12. Blocks are always 16 bytes.
    /// 
    /// Compressed textures sacrifice some quality in exchange for significantly reduced bandwidth usage.
    /// 
    /// Support for this feature guarantees availability of
    /// <see cref="Webgpu.TextureUsage.CopySrc" />, <see cref="Webgpu.TextureUsage.CopyDst" /> or <see cref="Webgpu.TextureUsage.TextureBinding" /> for ASTC formats with Unorm/UnormSrgb channel type. <see cref="FeatureName.TextureAdapterSpecificFormatFeatures" />
    /// may enable additional usages.
    /// 
    /// Supported Platforms:
    /// <list type="bullet"><item><description>Vulkan on Intel</description></item><item><description>Mobile (some)</description></item></list>
    /// </summary>
    TextureCompressionASTC = 7,
    /// <summary>
    /// Allows the 3d dimension for textures with ASTCS compressed formats.
    /// 
    /// This feature must be used in combination with TEXTURE_COMPRESSION_ASTCS to enable 3D textures with ASTCS compression. It does not enable the ASTCS formats by itself.
    /// </summary>
    TextureCompressionASTCSliced3D = 8,
    /// <summary>
    /// Allows non-zero value for the first_instance member in indirect draw calls.
    /// 
    /// If this feature is not enabled, and the first_instance member is non-zero, the behavior may be:
    /// 
    /// <list type="bullet"><item>The draw call is ignored.</item><item>The draw call is executed as if the first_instance is zero.</item><item>The draw call is executed with the correct first_instance value.</item></list>
    /// 
    /// Supported Platforms:
    /// <list type="bullet"><item><description>Vulkan (mostly)</description></item><item><description>DX12</description></item><item><description>Metal on Apple3+ or Mac1+</description></item><item><description>OpenGL (Desktop 4.2+ with ARB_shader_draw_parameters only)</description></item></list>
    /// 
    /// Not Supported:
    /// <list type="bullet"><item>OpenGL ES / WebGL</item></list>
    /// </summary>
    IndirectFirstInstance = 9,
    /// <summary>
    /// Allows shaders to acquire the FP16 ability.
    /// 
    /// Supported platforms:
    /// <list type="bullet"><item>Vulkan</item><item>Metal</item></list>
    /// </summary>
    ShaderF16 = 10,
    /// <summary>
    /// Allows for usage of textures of format
    /// <see cref="TextureFormat.Rg11b10Ufloat" />
    /// as a render target.
    /// 
    /// Supported platforms:
    /// <list type="bullet"><item>Vulkan</item><item>DX12</item><item>Metal</item></list>
    /// </summary>
    RG11B10UfloatRenderable = 11,
    /// <summary>
    /// Allows the
    /// <see cref="TextureUsage.StorageBinding" /> usage on textures with format <see cref="TextureFormat.BGRA8Unorm" />
    /// .
    /// 
    /// Supported Platforms:
    /// <list type="bullet"><item>Vulkan</item><item>DX12</item><item>Metal</item></list>
    /// </summary>
    BGRA8UnormStorage = 12,
    /// <summary>
    /// Allows textures with formats “r32float”, “rg32float”, and “rgba32float” to be filterable.
    /// 
    /// Supported Platforms:
    /// <list type="bullet"><item>Vulkan (mainly on Desktop GPUs)</item><item>DX12</item><item>Metal on macOS or Apple9+ GPUs, optional on iOS/iPadOS with Apple7/8 GPUs</item><item>GL with one of GL_ARB_color_buffer_float/GL_EXT_color_buffer_float/OES_texture_float_linear</item></list>
    /// </summary>
    Float32Filterable = 13,
    /// <summary>
    /// Allows textures with
    /// formats "r32float", "rg32float", and "rgba32float" to be blendable.
    /// </summary>
    Float32Blendable = 14,
    /// <summary>
    /// Allows setting user-defined clip distances in vertex shader outputs.
    /// </summary>
    ClipDistances = 15,
    /// <summary>
    /// Allows two outputs from a shader to be used for blending. Note that dual-source blending doesn’t support multiple render targets.
    /// 
    /// For more info see the OpenGL ES extension GL_EXT_blend_func_extended.
    /// 
    /// Supported platforms:
    /// <list type="bullet"><item>OpenGL ES (with GL_EXT_blend_func_extended)</item><item>Metal (with MSL 1.2+)</item><item>Vulkan (with dualSrcBlend)</item><item>DX12</item></list>
    /// </summary>
    DualSourceBlending = 16,
    /// <summary>
    /// Subgroups enable SIMD-level parallelism by allowing threads in a workgroup to communicate and perform collective math operations (e.g., summing 16 numbers).
    /// </summary>
    Subgroups = 17,
    /// <summary>
    /// Allows all Core WebGPU features and limits to be used.
    /// <remarks>
    /// This is currently available on all adapters and enabled automatically on all devices even if not requested.
    /// </remarks>
    /// </summary>
    CoreFeaturesAndLimits = 18,
    TextureFormatsTier1 = 327738,
}
