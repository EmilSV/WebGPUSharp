using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

/// <inheritdoc cref="BufferDescriptorFFI"/>
public ref partial struct BufferDescriptor
{
    internal BufferDescriptorFFI _unmanagedDescriptor;
    public WGPURefText Label;

    /// <inheritdoc cref="BufferDescriptorFFI.Usage"/>
    public required BufferUsage Usage
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Usage;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Usage = value;
    }

    /// <inheritdoc cref="BufferDescriptorFFI.Size"/>
    public required ulong Size
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.Size;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.Size = value;
    }

    /// <inheritdoc cref="BufferDescriptorFFI.MappedAtCreation"/>
    public WebGPUBool MappedAtCreation
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _unmanagedDescriptor.MappedAtCreation;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _unmanagedDescriptor.MappedAtCreation = value;
    }
}