using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;
namespace WebGpuSharp;

public ref partial struct SwapChainDescriptor
{
    internal SwapChainDescriptorFFI _unsafeDescriptor;
    public WGPURefText Label;

    public ref TextureUsage Usage
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.Usage;
    }

    public ref TextureFormat Format
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.Format;
    }

    public ref uint Width
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.Width;
    }

    public ref uint Height
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.Height;
    }

    public ref PresentMode PresentMode
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.PresentMode;
    }
}