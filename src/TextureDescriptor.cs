using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

/// <summary>
/// Describes a Texture.
/// 
/// For use with <see cref="DeviceHandle.CreateTexture(TextureDescriptor)" />.
/// </summary>
public unsafe ref partial struct TextureDescriptor
{
    /// <inheritdoc cref="WebGPU_FFI.ARRAY_LAYER_COUNT_UNDEFINED" />
    public const uint MIP_LEVEL_COUNT_UNDEFINED = WebGPU_FFI.MIP_LEVEL_COUNT_UNDEFINED;

    internal TextureDescriptorFFI _unmanagedDescriptor = new()
    {
        Usage = default,
        Size = default,
        Format = default,
    };
    /// <inheritdoc cref="TextureDescriptorFFI.Label"/>
    public WGPURefText Label;

    /// <inheritdoc cref="TextureDescriptorFFI.Usage"/>
    required public TextureUsage Usage
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Usage;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Usage = value;
    }

    /// <inheritdoc cref="TextureDescriptorFFI.Dimension"/>
    public TextureDimension Dimension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Dimension;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Dimension = value;
    }

    /// <inheritdoc cref="TextureDescriptorFFI.Size"/>
    required public Extent3D Size
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Size;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Size = value;
    }

    /// <inheritdoc cref="TextureDescriptorFFI.Format"/>
    required public TextureFormat Format
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Format;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Format = value;
    }

    /// <inheritdoc cref="TextureDescriptorFFI.MipLevelCount"/>
    public uint MipLevelCount
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.MipLevelCount;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.MipLevelCount = value;
    }

    /// <inheritdoc cref="TextureDescriptorFFI.SampleCount"/>
    public uint SampleCount
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.SampleCount;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.SampleCount = value;
    }

    /// <inheritdoc cref="TextureDescriptorFFI.ViewFormats"/>
    public ReadOnlySpan<TextureFormat> ViewFormats;

    public TextureDescriptor()
    {
    }
}