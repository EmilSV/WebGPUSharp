using System.Diagnostics.CodeAnalysis;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public ref partial struct BufferDescriptor
{
    internal BufferDescriptorFFI _unmanagedDescriptor;
    public WGPURefText Label;

    public ref BufferUsage Usage
    {
        [UnscopedRef]
        get => ref _unmanagedDescriptor.Usage;
    }

    public ref ulong Size
    {
        [UnscopedRef]
        get => ref _unmanagedDescriptor.Size;
    }

    public ref WGPUBool MappedAtCreation
    {
        [UnscopedRef]
        get => ref _unmanagedDescriptor.MappedAtCreation;
    }
}