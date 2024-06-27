using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public unsafe ref partial struct TextureDescriptor
{
    public const uint MIP_LEVEL_COUNT_UNDEFINED = WebGPU_FFI.MIP_LEVEL_COUNT_UNDEFINED;

    internal TextureDescriptorFFI _unmanagedDescriptor = new(
        label: default,
        usage: default,
        dimension: TextureDimension.D2,
        size: default,
        format: default,
        mipLevelCount: 1,
        sampleCount: 1,
        viewFormatCount: default,
        viewFormats: default
    );
    public WGPURefText Label;
    required public TextureUsage Usage
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Usage;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Usage = value;
    }

    public TextureDimension Dimension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Dimension;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Dimension = value;
    }

    required public Extent3D Size
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Size;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Size = value;
    }

    required public TextureFormat Format
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Format;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Format = value;
    }

    public uint MipLevelCount
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.MipLevelCount;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.MipLevelCount = value;
    }

    public uint SampleCount
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.SampleCount;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.SampleCount = value;
    }
    public ReadOnlySpan<TextureFormat> ViewFormats;

    public TextureDescriptor()
    {
    }
}