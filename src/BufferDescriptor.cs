using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct BufferDescriptor
{
    internal BufferDescriptorFFI _unmanagedDescriptor;
    public WGPURefText Label;

    required public BufferUsage Usage
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Usage;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Usage = value;
    }

    required public ulong Size
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Size;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Size = value;
    }

    public WGPUBool MappedAtCreation
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.MappedAtCreation;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.MappedAtCreation = value;
    }
}