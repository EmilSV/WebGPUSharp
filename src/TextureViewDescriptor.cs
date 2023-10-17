using System.Diagnostics.CodeAnalysis;
using WebGpuSharp.FFI;
namespace WebGpuSharp;


public ref partial struct TextureViewDescriptor
{
    internal TextureViewDescriptorFFI _unsafeDescriptor;
    public WGPURefText Label;
    public ref TextureFormat Format
    {
        [UnscopedRef]
        get => ref _unsafeDescriptor.Format;
    }

    public ref TextureViewDimension Dimension
    {
        [UnscopedRef]
        get => ref _unsafeDescriptor.Dimension;
    }

    public ref uint BaseMipLevel
    {
        [UnscopedRef]
        get => ref _unsafeDescriptor.BaseMipLevel;
    }

    public ref uint MipLevelCount
    {
        [UnscopedRef]
        get => ref _unsafeDescriptor.MipLevelCount;
    }

    public ref uint BaseArrayLayer
    {
        [UnscopedRef]
        get => ref _unsafeDescriptor.BaseArrayLayer;
    }

    public ref uint ArrayLayerCount
    {
        [UnscopedRef]
        get => ref _unsafeDescriptor.ArrayLayerCount;
    }

    public ref TextureAspect Aspect
    {
        [UnscopedRef]
        get => ref _unsafeDescriptor.Aspect;
    }
}