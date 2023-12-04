using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public unsafe ref partial struct SamplerDescriptor
{
    internal SamplerDescriptorFFI _unsafeDescriptor = new(
         label: null,
         addressModeU: AddressMode.ClampToEdge,
         addressModeV: AddressMode.ClampToEdge,
         addressModeW: AddressMode.ClampToEdge,
         magFilter: FilterMode.Nearest,
         minFilter: FilterMode.Nearest,
         mipmapFilter: MipmapFilterMode.Nearest,
         lodMinClamp: 0,
         lodMaxClamp: 32,
         compare: default,
         maxAnisotropy: 1
    );

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

    public unsafe SamplerDescriptor(
        WGPURefText label = default,
        AddressMode addressModeU = AddressMode.ClampToEdge,
        AddressMode addressModeV = AddressMode.ClampToEdge,
        AddressMode addressModeW = AddressMode.ClampToEdge,
        FilterMode magFilter = FilterMode.Nearest,
        FilterMode minFilter = FilterMode.Nearest,
        MipmapFilterMode mipmapFilter = MipmapFilterMode.Nearest,
        float lodMinClamp = 0,
        float lodMaxClamp = 32,
        CompareFunction compare = default,
        ushort maxAnisotropy = 1)
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