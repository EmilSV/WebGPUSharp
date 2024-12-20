using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum TextureFormat
{
    Undefined = 0,
    R8Unorm = 1,
    R8Snorm = 2,
    R8Uint = 3,
    R8Sint = 4,
    R16Uint = 5,
    R16Sint = 6,
    R16Float = 7,
    RG8Unorm = 8,
    RG8Snorm = 9,
    RG8Uint = 10,
    RG8Sint = 11,
    R32Float = 12,
    R32Uint = 13,
    R32Sint = 14,
    RG16Uint = 15,
    RG16Sint = 16,
    RG16Float = 17,
    RGBA8Unorm = 18,
    RGBA8UnormSrgb = 19,
    RGBA8Snorm = 20,
    RGBA8Uint = 21,
    RGBA8Sint = 22,
    BGRA8Unorm = 23,
    BGRA8UnormSrgb = 24,
    RGB10A2Uint = 25,
    RGB10A2Unorm = 26,
    RG11B10Ufloat = 27,
    RGB9E5Ufloat = 28,
    RG32Float = 29,
    RG32Uint = 30,
    RG32Sint = 31,
    RGBA16Uint = 32,
    RGBA16Sint = 33,
    RGBA16Float = 34,
    RGBA32Float = 35,
    RGBA32Uint = 36,
    RGBA32Sint = 37,
    Stencil8 = 38,
    Depth16Unorm = 39,
    Depth24Plus = 40,
    Depth24PlusStencil8 = 41,
    Depth32Float = 42,
    Depth32FloatStencil8 = 43,
    BC1RGBAUnorm = 44,
    BC1RGBAUnormSrgb = 45,
    BC2RGBAUnorm = 46,
    BC2RGBAUnormSrgb = 47,
    BC3RGBAUnorm = 48,
    BC3RGBAUnormSrgb = 49,
    BC4RUnorm = 50,
    BC4RSnorm = 51,
    BC5RGUnorm = 52,
    BC5RGSnorm = 53,
    BC6HRGBUfloat = 54,
    BC6HRGBFloat = 55,
    BC7RGBAUnorm = 56,
    BC7RGBAUnormSrgb = 57,
    ETC2RGB8Unorm = 58,
    ETC2RGB8UnormSrgb = 59,
    ETC2RGB8A1Unorm = 60,
    ETC2RGB8A1UnormSrgb = 61,
    ETC2RGBA8Unorm = 62,
    ETC2RGBA8UnormSrgb = 63,
    EACR11Unorm = 64,
    EACR11Snorm = 65,
    EACRG11Unorm = 66,
    EACRG11Snorm = 67,
    ASTC4x4Unorm = 68,
    ASTC4x4UnormSrgb = 69,
    ASTC5x4Unorm = 70,
    ASTC5x4UnormSrgb = 71,
    ASTC5x5Unorm = 72,
    ASTC5x5UnormSrgb = 73,
    ASTC6x5Unorm = 74,
    ASTC6x5UnormSrgb = 75,
    ASTC6x6Unorm = 76,
    ASTC6x6UnormSrgb = 77,
    ASTC8x5Unorm = 78,
    ASTC8x5UnormSrgb = 79,
    ASTC8x6Unorm = 80,
    ASTC8x6UnormSrgb = 81,
    ASTC8x8Unorm = 82,
    ASTC8x8UnormSrgb = 83,
    ASTC10x5Unorm = 84,
    ASTC10x5UnormSrgb = 85,
    ASTC10x6Unorm = 86,
    ASTC10x6UnormSrgb = 87,
    ASTC10x8Unorm = 88,
    ASTC10x8UnormSrgb = 89,
    ASTC10x10Unorm = 90,
    ASTC10x10UnormSrgb = 91,
    ASTC12x10Unorm = 92,
    ASTC12x10UnormSrgb = 93,
    ASTC12x12Unorm = 94,
    ASTC12x12UnormSrgb = 95,
    R16Unorm = 327680,
    RG16Unorm = 327681,
    RGBA16Unorm = 327682,
    R16Snorm = 327683,
    RG16Snorm = 327684,
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
