using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Underlying texture data format.
/// 
/// If there is a conversion in the format (such as srgb -&gt; linear),
/// the conversion listed here is for loading from texture in a shader. When writing to the texture,
/// the opposite conversion takes place.
/// </summary>
public enum TextureFormat
{
    /// <summary>
    /// Undefined texture format.
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Red channel only. 8 bit integer per channel. [0, 255] converted to/from float [0, 1] in shader.
    /// </summary>
    R8Unorm = 1,
    /// <summary>
    /// Red channel only. 8 bit integer per channel. [-127, 127] converted to/from float [-1, 1] in shader.
    /// </summary>
    R8Snorm = 2,
    /// <summary>
    /// Red channel only. 8 bit integer per channel. Unsigned in shader.
    /// </summary>
    R8Uint = 3,
    /// <summary>
    /// Red channel only. 8 bit integer per channel. Signed in shader.
    /// </summary>
    R8Sint = 4,
    /// <summary>
    /// Red channel only. 16 bit integer per channel. Unsigned in shader.
    /// </summary>
    R16Uint = 5,
    /// <summary>
    /// Red channel only. 16 bit integer per channel. Signed in shader.
    /// </summary>
    R16Sint = 6,
    /// <summary>
    /// Red channel only. 16 bit float per channel. Float in shader.
    /// </summary>
    R16Float = 7,
    /// <summary>
    /// Red and green channels. 8 bit integer per channel. [0, 255] converted to/from float [0, 1] in shader.
    /// </summary>
    RG8Unorm = 8,
    /// <summary>
    /// Red and green channels. 8 bit integer per channel. [-127, 127] converted to/from float [-1, 1] in shader.
    /// </summary>
    RG8Snorm = 9,
    /// <summary>
    /// Red and green channels. 8 bit integer per channel. Unsigned in shader.
    /// </summary>
    RG8Uint = 10,
    /// <summary>
    /// Red and green channels. 8 bit integer per channel. Signed in shader.
    /// </summary>
    RG8Sint = 11,
    /// <summary>
    /// Red channel only. 32 bit float per channel. Float in shader.
    /// </summary>
    R32Float = 12,
    /// <summary>
    /// Red channel only. 32 bit integer per channel. Unsigned in shader.
    /// </summary>
    R32Uint = 13,
    /// <summary>
    /// Red channel only. 32 bit integer per channel. Signed in shader.
    /// </summary>
    R32Sint = 14,
    /// <summary>
    /// Red and green channels. 16 bit integer per channel. Unsigned in shader.
    /// </summary>
    RG16Uint = 15,
    /// <summary>
    /// Red and green channels. 16 bit integer per channel. Signed in shader.
    /// </summary>
    RG16Sint = 16,
    /// <summary>
    /// Red and green channels. 16 bit float per channel. Float in shader.
    /// </summary>
    RG16Float = 17,
    /// <summary>
    /// Red, green, blue, and alpha channels. 8 bit integer per channel. [0, 255] converted to/from float [0, 1] in shader.
    /// </summary>
    RGBA8Unorm = 18,
    /// <summary>
    /// Red, green, blue, and alpha channels. 8 bit integer per channel. Srgb-color [0, 255] converted to/from linear-color float [0, 1] in shader.
    /// </summary>
    RGBA8UnormSrgb = 19,
    /// <summary>
    /// Red, green, blue, and alpha channels. 8 bit integer per channel. [-127, 127] converted to/from float [-1, 1] in shader.
    /// </summary>
    RGBA8Snorm = 20,
    /// <summary>
    /// Red, green, blue, and alpha channels. 8 bit integer per channel. Unsigned in shader.
    /// </summary>
    RGBA8Uint = 21,
    /// <summary>
    /// Red, green, blue, and alpha channels. 8 bit integer per channel. Signed in shader.
    /// </summary>
    RGBA8Sint = 22,
    /// <summary>
    /// Blue, green, red, and alpha channels. 8 bit integer per channel. [0, 255] converted to/from float [0, 1] in shader.
    /// </summary>
    BGRA8Unorm = 23,
    /// <summary>
    /// Blue, green, red, and alpha channels. 8 bit integer per channel. Srgb-color [0, 255] converted to/from linear-color float [0, 1] in shader.
    /// </summary>
    BGRA8UnormSrgb = 24,
    /// <summary>
    /// Red, green, blue, and alpha channels. 10 bit integer for RGB channels, 2 bit integer for alpha channel. Unsigned in shader.
    /// </summary>
    RGB10A2Uint = 25,
    /// <summary>
    /// Red, green, blue, and alpha channels. 10 bit integer for RGB channels, 2 bit integer for alpha channel. [0, 1023] ([0, 3] for alpha) converted to/from float [0, 1] in shader.
    /// </summary>
    RGB10A2Unorm = 26,
    /// <summary>
    /// Red, green, and blue channels. 11 bit float with no sign bit for RG channels. 10 bit float with no sign bit for blue channel. Float in shader.
    /// </summary>
    RG11B10Ufloat = 27,
    /// <summary>
    /// Packed unsigned float with 9 bits mantisa for each RGB component, then a common 5 bits exponent.
    /// </summary>
    RGB9E5Ufloat = 28,
    /// <summary>
    /// Red and green channels. 32 bit float per channel. Float in shader.
    /// </summary>
    RG32Float = 29,
    /// <summary>
    /// Red and green channels. 32 bit integer per channel. Unsigned in shader.
    /// </summary>
    RG32Uint = 30,
    /// <summary>
    /// Red and green channels. 32 bit integer per channel. Signed in shader.
    /// </summary>
    RG32Sint = 31,
    /// <summary>
    /// Red, green, blue, and alpha channels. 16 bit integer per channel. Unsigned in shader.
    /// </summary>
    RGBA16Uint = 32,
    /// <summary>
    /// Red, green, blue, and alpha channels. 16 bit integer per channel. Signed in shader.
    /// </summary>
    RGBA16Sint = 33,
    /// <summary>
    /// Red, green, blue, and alpha channels. 16 bit float per channel. Float in shader.
    /// </summary>
    RGBA16Float = 34,
    /// <summary>
    /// Red, green, blue, and alpha channels. 32 bit float per channel. Float in shader.
    /// </summary>
    RGBA32Float = 35,
    /// <summary>
    /// Red, green, blue, and alpha channels. 32 bit integer per channel. Unsigned in shader.
    /// </summary>
    RGBA32Uint = 36,
    /// <summary>
    /// Red, green, blue, and alpha channels. 32 bit integer per channel. Signed in shader.
    /// </summary>
    RGBA32Sint = 37,
    /// <summary>
    /// Stencil format with 8 bit integer stencil.
    /// </summary>
    Stencil8 = 38,
    /// <summary>
    /// Special depth format with 16 bit integer depth.
    /// </summary>
    Depth16Unorm = 39,
    /// <summary>
    /// Special depth format with at least 24 bit integer depth.
    /// </summary>
    Depth24Plus = 40,
    /// <summary>
    /// Special depth/stencil format with at least 24 bit integer depth and 8 bits integer stencil.
    /// </summary>
    Depth24PlusStencil8 = 41,
    /// <summary>
    /// Special depth format with 32 bit floating point depth.
    /// </summary>
    Depth32Float = 42,
    /// <summary>
    /// Special depth/stencil format with 32 bit floating point depth and 8 bits integer stencil. <see cref="FeatureName.Depth32FloatStencil8" /> must be enabled to use this texture format.
    /// </summary>
    Depth32FloatStencil8 = 43,
    /// <summary>
    /// 4x4 block compressed texture. 8 bytes per block (4 bit/px). 4 color + alpha pallet. 5 bit R + 6 bit G + 5 bit B + 1 bit alpha. [0, 63] ([0, 1] for alpha) converted to/from float [0, 1] in shader. Also known as DXT1. <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC1RGBAUnorm = 44,
    /// <summary>
    /// 4x4 block compressed texture. 8 bytes per block (4 bit/px). 4 color + alpha pallet. 5 bit R + 6 bit G + 5 bit B + 1 bit alpha. Srgb-color [0, 63] ([0, 1] for alpha) converted to/from linear-color float [0, 1] in shader. Also known as DXT1. <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC1RGBAUnormSrgb = 45,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). 4 color pallet. 5 bit R + 6 bit G + 5 bit B + 4 bit alpha. [0, 63] ([0, 15] for alpha) converted to/from float [0, 1] in shader. Also known as DXT3. <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC2RGBAUnorm = 46,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). 4 color pallet. 5 bit R + 6 bit G + 5 bit B + 4 bit alpha. Srgb-color [0, 63] ([0, 255] for alpha) converted to/from linear-color float [0, 1] in shader. Also known as DXT3. <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC2RGBAUnormSrgb = 47,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). 4 color pallet + 8 alpha pallet. 5 bit R + 6 bit G + 5 bit B + 8 bit alpha. [0, 63] ([0, 255] for alpha) converted to/from float [0, 1] in shader. Also known as DXT5. <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC3RGBAUnorm = 48,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). 4 color pallet + 8 alpha pallet. 5 bit R + 6 bit G + 5 bit B + 8 bit alpha. Srgb-color [0, 63] ([0, 255] for alpha) converted to/from linear-color float [0, 1] in shader. Also known as DXT5. <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC3RGBAUnormSrgb = 49,
    /// <summary>
    /// 4x4 block compressed texture. 8 bytes per block (4 bit/px). 8 color pallet. 8 bit R. [0, 255] converted to/from float [0, 1] in shader. Also known as RGTC1. <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC4RUnorm = 50,
    /// <summary>
    /// 4x4 block compressed texture. 8 bytes per block (4 bit/px). 8 color pallet. 8 bit R. [-127, 127] converted to/from float [-1, 1] in shader. Also known as RGTC1. <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC4RSnorm = 51,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). 8 color red pallet + 8 color green pallet. 8 bit RG. [0, 255] converted to/from float [0, 1] in shader. Also known as RGTC2. <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC5RGUnorm = 52,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). 8 color red pallet + 8 color green pallet. 8 bit RG. [-127, 127] converted to/from float [-1, 1] in shader. Also known as RGTC2. <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC5RGSnorm = 53,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). Variable sized pallet. 16 bit unsigned float RGB. Float in shader. Also known as BPTC (float). <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC6HRGBUfloat = 54,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). Variable sized pallet. 16 bit signed float RGB. Float in shader. Also known as BPTC (float). <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC6HRGBFloat = 55,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). Variable sized pallet. 8 bit integer RGBA. [0, 255] converted to/from float [0, 1] in shader. Also known as BPTC (unorm). <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC7RGBAUnorm = 56,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). Variable sized pallet. 8 bit integer RGBA. Srgb-color [0, 255] converted to/from linear-color float [0, 1] in shader. Also known as BPTC (unorm). <see cref="FeatureName.TextureCompressionBc" /> must be enabled to use this texture format.
    /// </summary>
    BC7RGBAUnormSrgb = 57,
    /// <summary>
    /// 4x4 block compressed texture. 8 bytes per block (4 bit/px). Complex pallet. 8 bit integer RGB. [0, 255] converted to/from float [0, 1] in shader. <see cref="FeatureName.TextureCompressionEtc2" /> must be enabled to use this texture format.
    /// </summary>
    ETC2RGB8Unorm = 58,
    /// <summary>
    /// 4x4 block compressed texture. 8 bytes per block (4 bit/px). Complex pallet. 8 bit integer RGB. Srgb-color [0, 255] converted to/from linear-color float [0, 1] in shader. <see cref="FeatureName.TextureCompressionEtc2" /> must be enabled to use this texture format.
    /// </summary>
    ETC2RGB8UnormSrgb = 59,
    /// <summary>
    /// 4x4 block compressed texture. 8 bytes per block (4 bit/px). Complex pallet. 8 bit integer RGB + 1 bit alpha. [0, 255] ([0, 1] for alpha) converted to/from float [0, 1] in shader. <see cref="FeatureName.TextureCompressionEtc2" /> must be enabled to use this texture format.
    /// </summary>
    ETC2RGB8A1Unorm = 60,
    /// <summary>
    /// 4x4 block compressed texture. 8 bytes per block (4 bit/px). Complex pallet. 8 bit integer RGB + 1 bit alpha. Srgb-color [0, 255] ([0, 1] for alpha) converted to/from linear-color float [0, 1] in shader. <see cref="FeatureName.TextureCompressionEtc2" /> must be enabled to use this texture format.
    /// </summary>
    ETC2RGB8A1UnormSrgb = 61,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). Complex pallet. 8 bit integer RGB + 8 bit alpha. [0, 255] converted to/from float [0, 1] in shader. <see cref="FeatureName.TextureCompressionEtc2" /> must be enabled to use this texture format.
    /// </summary>
    ETC2RGBA8Unorm = 62,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). Complex pallet. 8 bit integer RGB + 8 bit alpha. Srgb-color [0, 255] converted to/from linear-color float [0, 1] in shader. <see cref="FeatureName.TextureCompressionEtc2" /> must be enabled to use this texture format.
    /// </summary>
    ETC2RGBA8UnormSrgb = 63,
    /// <summary>
    /// 4x4 block compressed texture. 8 bytes per block (4 bit/px). Complex pallet. 11 bit integer R. [0, 255] converted to/from float [0, 1] in shader. <see cref="FeatureName.TextureCompressionEtc2" /> must be enabled to use this texture format.
    /// </summary>
    EACR11Unorm = 64,
    /// <summary>
    /// 4x4 block compressed texture. 8 bytes per block (4 bit/px). Complex pallet. 11 bit integer R. [-127, 127] converted to/from float [-1, 1] in shader. <see cref="FeatureName.TextureCompressionEtc2" /> must be enabled to use this texture format.
    /// </summary>
    EACR11Snorm = 65,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). Complex pallet. 11 bit integer R + 11 bit integer G. [0, 255] converted to/from float [0, 1] in shader. <see cref="FeatureName.TextureCompressionEtc2" /> must be enabled to use this texture format.
    /// </summary>
    EACRG11Unorm = 66,
    /// <summary>
    /// 4x4 block compressed texture. 16 bytes per block (8 bit/px). Complex pallet. 11 bit integer R + 11 bit integer G. [-127, 127] converted to/from float [-1, 1] in shader. <see cref="FeatureName.TextureCompressionEtc2" /> must be enabled to use this texture format.
    /// </summary>
    EACRG11Snorm = 67,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC4x4Unorm = 68,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC4x4UnormSrgb = 69,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC5x4Unorm = 70,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC5x4UnormSrgb = 71,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC5x5Unorm = 72,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC5x5UnormSrgb = 73,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC6x5Unorm = 74,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC6x5UnormSrgb = 75,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC6x6Unorm = 76,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC6x6UnormSrgb = 77,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC8x5Unorm = 78,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC8x5UnormSrgb = 79,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC8x6Unorm = 80,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC8x6UnormSrgb = 81,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC8x8Unorm = 82,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC8x8UnormSrgb = 83,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC10x5Unorm = 84,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC10x5UnormSrgb = 85,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC10x6Unorm = 86,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC10x6UnormSrgb = 87,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC10x8Unorm = 88,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC10x8UnormSrgb = 89,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC10x10Unorm = 90,
    /// <summary>
    /// Block compressed texture. 16 bytes per block. <see cref="FeatureName.TextureCompressionASTC" /> must be enabled to use this texture format.
    /// </summary>
    ASTC10x10UnormSrgb = 91,
    ASTC12x10Unorm = 92,
    ASTC12x10UnormSrgb = 93,
    ASTC12x12Unorm = 94,
    ASTC12x12UnormSrgb = 95,
    /// <summary>
    /// Red channel only. 16 bit integer per channel. [0, 65535] converted to/from float [0, 1] in shader. <see cref="FeatureName.TextureFormat16BitNorm" /> must be enabled to use this texture format.
    /// </summary>
    R16Unorm = 327680,
    /// <summary>
    /// Red and green channels. 16 bit integer per channel. [0, 65535] converted to/from float [0, 1] in shader. <see cref="FeatureName.TextureFormat16BitNorm" /> must be enabled to use this texture format.
    /// </summary>
    RG16Unorm = 327681,
    /// <summary>
    /// Red, green, blue, and alpha channels. 16 bit integer per channel. [0, 65535] converted to/from float [0, 1] in shader. <see cref="FeatureName.TextureFormat16BitNorm" /> must be enabled to use this texture format.
    /// </summary>
    RGBA16Unorm = 327682,
    /// <summary>
    /// Red channel only. 16 bit integer per channel. [0, 65535] converted to/from float [-1, 1] in shader. <see cref="FeatureName.TextureFormat16BitNorm" /> must be enabled to use this texture format.
    /// </summary>
    R16Snorm = 327683,
    /// <summary>
    /// Red and green channels. 16 bit integer per channel. [0, 65535] converted to/from float [-1, 1] in shader. <see cref="FeatureName.TextureFormat16BitNorm" /> must be enabled to use this texture format.
    /// </summary>
    RG16Snorm = 327684,
    /// <summary>
    /// Red, green, blue, and alpha. 16 bit integer per channel. [0, 65535] converted to/from float [-1, 1] in shader. <see cref="FeatureName.TextureFormat16BitNorm" /> must be enabled to use this texture format.
    /// </summary>
    RGBA16Snorm = 327685,
    R8BG8Biplanar420Unorm = 327686,
    R10X6BG10X6Biplanar420Unorm = 327687,
    R8BG8A8Triplanar420Unorm = 327688,
    R8BG8Biplanar422Unorm = 327689,
    R8BG8Biplanar444Unorm = 327690,
    R10X6BG10X6Biplanar422Unorm = 327691,
    R10X6BG10X6Biplanar444Unorm = 327692,
    External = 327693,
}
