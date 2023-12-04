using System.Diagnostics.CodeAnalysis;
using WebGpuSharp.FFI;
namespace WebGpuSharp;


// dictionary GPUTextureViewDescriptor
//          : GPUObjectDescriptorBase {
//     GPUTextureFormat format;
//     GPUTextureViewDimension dimension;
//     GPUTextureAspect aspect = "all";
//     GPUIntegerCoordinate baseMipLevel = 0;
//     GPUIntegerCoordinate mipLevelCount;
//     GPUIntegerCoordinate baseArrayLayer = 0;
//     GPUIntegerCoordinate arrayLayerCount;
// };

public unsafe ref partial struct TextureViewDescriptor
{
    internal TextureViewDescriptorFFI _unsafeDescriptor = new(
        label: default,
        format: default,
        dimension: default,
        aspect: TextureAspect.All,
        baseMipLevel: 0,
        mipLevelCount: default,
        baseArrayLayer: 0,
        arrayLayerCount: default
    );
    public WGPURefText Label;

    public TextureViewDescriptor()
    {
    }

    public TextureFormat Format
    {
        readonly get => _unsafeDescriptor.Format;
        set => _unsafeDescriptor.Format = value;
    }

    public TextureViewDimension Dimension
    {
        readonly get => _unsafeDescriptor.Dimension;
        set => _unsafeDescriptor.Dimension = value;
    }

    public uint BaseMipLevel
    {
        readonly get => _unsafeDescriptor.BaseMipLevel;
        set => _unsafeDescriptor.BaseMipLevel = value;
    }

    public uint MipLevelCount
    {
        readonly get => _unsafeDescriptor.MipLevelCount;
        set => _unsafeDescriptor.MipLevelCount = value;
    }

    public uint BaseArrayLayer
    {
        readonly get => _unsafeDescriptor.BaseArrayLayer;
        set => _unsafeDescriptor.BaseArrayLayer = value;
    }

    public uint ArrayLayerCount
    {
        readonly get => _unsafeDescriptor.ArrayLayerCount;
        set => _unsafeDescriptor.ArrayLayerCount = value;
    }

    public TextureAspect Aspect
    {
        readonly get => _unsafeDescriptor.Aspect;
        set => _unsafeDescriptor.Aspect = value;
    }
}