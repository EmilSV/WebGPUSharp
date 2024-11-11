using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

public struct BindGroupEntry : IWebGpuFFIConvertibleAlloc<BindGroupEntry, BindGroupEntryFFI>
{
    public required uint Binding;
    public Buffer? Buffer;
    public ulong Offset = 0;
    public ulong? Size;
    public SamplerBase? Sampler;
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

