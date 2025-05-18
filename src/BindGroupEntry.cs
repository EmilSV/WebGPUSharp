using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

/// <inheritdoc cref="BindGroupEntryFFI"/>
public struct BindGroupEntry : IWebGpuFFIConvertibleAlloc<BindGroupEntry, BindGroupEntryFFI>
{
    /// <inheritdoc cref="BindGroupEntryFFI.Binding"/>
    public required uint Binding;
    /// <inheritdoc cref="BindGroupEntryFFI.Buffer"/>
    public Buffer? Buffer;
    /// <inheritdoc cref="BindGroupEntryFFI.Offset"/>
    public ulong Offset = 0;
    /// <inheritdoc cref="BindGroupEntryFFI.Size"/>
    public ulong? Size;
    /// <inheritdoc cref="BindGroupEntryFFI.Sampler"/>
    public SamplerBase? Sampler;
    /// <inheritdoc cref="BindGroupEntryFFI.TextureView"/>
    public TextureViewBase? TextureView;

    public BindGroupEntry()
    {
    }

    static void IWebGpuFFIConvertibleAlloc<BindGroupEntry, BindGroupEntryFFI>.UnsafeConvertToFFI(
        in BindGroupEntry input, WebGpuAllocatorHandle allocator, out BindGroupEntryFFI dest)
    {
        ulong size = 0;
        if (input.Size.HasValue)
        {
            size = input.Size.Value;
        }
        else if (input.Buffer != null)
        {
            size = input.Buffer.GetSize() - input.Offset;
        }

        dest = new()
        {
            Binding = input.Binding,
            Buffer = GetBorrowHandle(input.Buffer),
            Offset = input.Offset,
            Size = size,
            Sampler = GetBorrowHandle(input.Sampler),
            TextureView = allocator.GetHandle(input.TextureView)
        };
    }
}

