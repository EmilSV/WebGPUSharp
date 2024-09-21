using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public unsafe ref struct SamplerDescriptor
{
    internal SamplerDescriptorFFI _unsafeDescriptor = new();

    public WGPURefText Label;
    public AddressMode AddressModeU
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.AddressModeU;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.AddressModeU = value;
    }
    public AddressMode AddressModeV
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.AddressModeV;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.AddressModeV = value;
    }
    public AddressMode AddressModeW
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.AddressModeW;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.AddressModeW = value;
    }
    public FilterMode MagFilter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.MagFilter;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.MagFilter = value;
    }
    public FilterMode MinFilter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.MinFilter;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.MinFilter = value;
    }
    public MipmapFilterMode MipmapFilter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.MipmapFilter;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.MipmapFilter = value;
    }
    public float LodMinClamp
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.LodMinClamp;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.LodMinClamp = value;
    }
    public float LodMaxClamp
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.LodMaxClamp;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.LodMaxClamp = value;
    }
    public CompareFunction Compare
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.Compare;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.Compare = value;
    }
    public ushort MaxAnisotropy
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.MaxAnisotropy;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.MaxAnisotropy = value;
    }

    public SamplerDescriptor()
    {

    }
}