using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp;

public struct BindGroupEntry : IWebGpuFFIConvertible<BindGroupEntry, BindGroupEntryFFI>
{
    public uint Binding;
    public Buffer? Buffer;
    public ulong Offset;
    public ulong Size;
    public Sampler? Sampler;
    public TextureView? TextureView;

    public BindGroupEntry()
    {
        Binding = default;
        Buffer = default;
        Offset = default;
        Size = default;
        Sampler = default;
        TextureView = default;
    }

    public BindGroupEntry(
        uint binding = default, Buffer? buffer = default,
        ulong offset = default, ulong size = default,
        Sampler? sampler = default, TextureView? textureView = default)
    {
        Binding = binding;
        Buffer = buffer;
        Offset = offset;
        Size = size;
        Sampler = sampler;
        TextureView = textureView;
    }

    static void IWebGpuFFIConvertibleAlloc<BindGroupEntry, BindGroupEntryFFI>.UnsafeConvertToFFI(
        in BindGroupEntry input, WebGpuAllocatorHandle allocator, out BindGroupEntryFFI dest)
    {
        ToFFI(input, out dest);
    }

    static void IWebGpuFFIConvertible<BindGroupEntry, BindGroupEntryFFI>.UnsafeConvertToFFI(
        in BindGroupEntry input, out BindGroupEntryFFI dest)
    {
        dest = new(
            binding: input.Binding,
            buffer: ToFFI<Buffer, BufferHandle>(input.Buffer),
            offset: input.Offset,
            size: input.Size,
            sampler: ToFFI<Sampler, SamplerHandle>(input.Sampler),
            textureView: ToFFI<TextureView, TextureViewHandle>(input.TextureView)
        );
    }
}

