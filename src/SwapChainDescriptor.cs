using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;
namespace WebGpuSharp;

public ref partial struct SwapChainDescriptor
{
    internal SwapChainDescriptorFFI _unsafeDescriptor;
    public WGPURefText Label;

    public TextureUsage Usage
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.Usage;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.Usage = value;
    }

    public TextureFormat Format
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.Format;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.Format = value;
    }

    public uint Width
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.Width;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.Width = value;
    }

    public uint Height
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.Height;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.Height = value;
    }

    public PresentMode PresentMode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.PresentMode;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.PresentMode = value;
    }
}