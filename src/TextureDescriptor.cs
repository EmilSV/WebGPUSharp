using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;


public ref partial struct TextureDescriptor
{
    internal TextureDescriptorFFI _unmanagedDescriptor;
    public WGPURefText Label;
    public ref TextureUsage Usage
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unmanagedDescriptor.Usage;
    }

    public ref TextureDimension Dimension
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unmanagedDescriptor.Dimension;
    }

    public ref Extent3D Size
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unmanagedDescriptor.Size;
    }

    public ref TextureFormat Format
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unmanagedDescriptor.Format;
    }

    public ref uint MipLevelCount
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unmanagedDescriptor.MipLevelCount;
    }

    public ref uint SampleCount
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unmanagedDescriptor.SampleCount;
    }
    public ReadOnlySpan<TextureFormat> ViewFormats;
}