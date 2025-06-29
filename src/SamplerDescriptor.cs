using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

/// <inheritdoc cref="SamplerDescriptorFFI"/>
public unsafe ref struct SamplerDescriptor
{
    internal SamplerDescriptorFFI _unsafeDescriptor = new();

    /// <inheritdoc cref="SamplerDescriptorFFI.Label"/>
    public WGPURefText Label;

    /// <inheritdoc cref="SamplerDescriptorFFI.AddressModeU"/>
    public AddressMode AddressModeU
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.AddressModeU;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.AddressModeU = value;
    }

    /// <inheritdoc cref="SamplerDescriptorFFI.AddressModeV"/>
    public AddressMode AddressModeV
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.AddressModeV;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.AddressModeV = value;
    }
    /// <inheritdoc cref="SamplerDescriptorFFI.AddressModeV"/>
    public AddressMode AddressModeW
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.AddressModeW;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.AddressModeW = value;
    }
    /// <inheritdoc cref="SamplerDescriptorFFI.MagFilter"/>
    public FilterMode MagFilter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.MagFilter;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.MagFilter = value;
    }
    /// <inheritdoc cref="SamplerDescriptorFFI.MinFilter"/>
    public FilterMode MinFilter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.MinFilter;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.MinFilter = value;
    }

    /// <inheritdoc cref="SamplerDescriptorFFI.MipmapFilter"/>
    public MipmapFilterMode MipmapFilter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.MipmapFilter;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.MipmapFilter = value;
    }
    /// <inheritdoc cref="SamplerDescriptorFFI.LodMinClamp"/>
    public float LodMinClamp
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.LodMinClamp;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.LodMinClamp = value;
    }
    /// <inheritdoc cref="SamplerDescriptorFFI.LodMaxClamp"/>
    public float LodMaxClamp
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.LodMaxClamp;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.LodMaxClamp = value;
    }
    /// <inheritdoc cref="SamplerDescriptorFFI.Compare"/>
    public CompareFunction Compare
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unsafeDescriptor.Compare;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unsafeDescriptor.Compare = value;
    }
    /// <inheritdoc cref="SamplerDescriptorFFI.MaxAnisotropy"/>
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