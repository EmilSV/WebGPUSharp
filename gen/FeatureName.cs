using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum FeatureName
{
    DepthClipControl = 1,
    Depth32FloatStencil8 = 2,
    TimestampQuery = 3,
    TextureCompressionBC = 4,
    TextureCompressionETC2 = 5,
    TextureCompressionASTC = 6,
    IndirectFirstInstance = 7,
    ShaderF16 = 8,
    RG11B10UfloatRenderable = 9,
    BGRA8UnormStorage = 10,
    Float32Filterable = 11,
    Subgroups = 12,
    SubgroupsF16 = 13,
}
