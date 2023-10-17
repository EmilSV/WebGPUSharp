using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct SamplerDescriptor
{
    internal SamplerDescriptorFFI _unsafeDescriptor;

    public WGPURefText Label;
    public ref AddressMode AddressModeU
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.AddressModeU;
    }
    public ref AddressMode AddressModeV
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.AddressModeV;
    }
    public ref AddressMode AddressModeW
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.AddressModeW;
    }
    public ref FilterMode MagFilter
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.MagFilter;
    }
    public ref FilterMode MinFilter
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.MinFilter;
    }
    public ref MipmapFilterMode MipmapFilter
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.MipmapFilter;
    }
    public ref float LodMinClamp
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.LodMinClamp;
    }
    public ref float LodMaxClamp
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.LodMaxClamp;
    }
    public ref CompareFunction Compare
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.Compare;
    }
    public ref ushort MaxAnisotropy
    {
        [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _unsafeDescriptor.MaxAnisotropy;
    }

    public SamplerDescriptor()
    {

    }

    public unsafe SamplerDescriptor(
        WGPURefText label = default,
        AddressMode addressModeU = default,
        AddressMode addressModeV = default,
        AddressMode addressModeW = default,
        FilterMode magFilter = default,
        FilterMode minFilter = default,
        MipmapFilterMode mipmapFilter = default,
        float lodMinClamp = default,
        float lodMaxClamp = default,
        CompareFunction compare = default,
        ushort maxAnisotropy = default)
    {
        Label = label;
        _unsafeDescriptor = new(
            label: null,
            addressModeU: addressModeU,
            addressModeV: addressModeV,
            addressModeW: addressModeW,
            magFilter: magFilter,
            minFilter: minFilter,
            mipmapFilter: mipmapFilter,
            lodMinClamp: lodMinClamp,
            lodMaxClamp: lodMaxClamp,
            compare: compare,
            maxAnisotropy: maxAnisotropy
        );
    }
}