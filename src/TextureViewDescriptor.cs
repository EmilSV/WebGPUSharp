using System.Diagnostics.CodeAnalysis;
using WebGpuSharp.FFI;
namespace WebGpuSharp;

/// <inheritdoc cref ="TextureViewDescriptorFFI" />
public unsafe ref partial struct TextureViewDescriptor
{
    /// <inheritdoc cref ="WebGPU_FFI.ARRAY_LAYER_COUNT_UNDEFINED" />
    public const uint ARRAY_LAYER_COUNT_UNDEFINED = WebGPU_FFI.ARRAY_LAYER_COUNT_UNDEFINED;
    /// <inheritdoc cref ="WebGPU_FFI.MIP_LEVEL_COUNT_UNDEFINED" />
    public const uint MIP_LEVEL_COUNT_UNDEFINED = WebGPU_FFI.MIP_LEVEL_COUNT_UNDEFINED;

    internal TextureViewDescriptorFFI _unsafeDescriptor = new()
    {
        ArrayLayerCount = ARRAY_LAYER_COUNT_UNDEFINED,
        MipLevelCount = MIP_LEVEL_COUNT_UNDEFINED
    };

    public TextureViewDescriptor()
    {
    }

    /// <inheritdoc cref ="TextureViewDescriptorFFI.Label" />
    public WGPURefText Label;

    /// <inheritdoc cref ="TextureViewDescriptorFFI.Format" />
    public TextureFormat Format
    {
        readonly get => _unsafeDescriptor.Format;
        set => _unsafeDescriptor.Format = value;
    }

    /// <inheritdoc cref ="TextureViewDescriptorFFI.Dimension" />
    public TextureViewDimension Dimension
    {
        readonly get => _unsafeDescriptor.Dimension;
        set => _unsafeDescriptor.Dimension = value;
    }

    /// <inheritdoc cref ="TextureViewDescriptorFFI.BaseMipLevel" />
    public uint BaseMipLevel
    {
        readonly get => _unsafeDescriptor.BaseMipLevel;
        set => _unsafeDescriptor.BaseMipLevel = value;
    }

    /// <inheritdoc cref ="TextureViewDescriptorFFI.MipLevelCount" />
    public uint? MipLevelCount
    {
        readonly get => _unsafeDescriptor.MipLevelCount == MIP_LEVEL_COUNT_UNDEFINED ? null : _unsafeDescriptor.MipLevelCount;
        set => _unsafeDescriptor.MipLevelCount = value ?? MIP_LEVEL_COUNT_UNDEFINED;
    }

    /// <inheritdoc cref ="TextureViewDescriptorFFI.BaseArrayLayer" />
    public uint BaseArrayLayer
    {
        readonly get => _unsafeDescriptor.BaseArrayLayer;
        set => _unsafeDescriptor.BaseArrayLayer = value;
    }
    /// <inheritdoc cref ="TextureViewDescriptorFFI.ArrayLayerCount" />
    public uint? ArrayLayerCount
    {
        readonly get => _unsafeDescriptor.ArrayLayerCount == ARRAY_LAYER_COUNT_UNDEFINED ? null : _unsafeDescriptor.ArrayLayerCount;
        set => _unsafeDescriptor.ArrayLayerCount = value ?? ARRAY_LAYER_COUNT_UNDEFINED;
    }

    /// <inheritdoc cref ="TextureViewDescriptorFFI.Aspect" />
    public TextureAspect Aspect
    {
        readonly get => _unsafeDescriptor.Aspect;
        set => _unsafeDescriptor.Aspect = value;
    }
}