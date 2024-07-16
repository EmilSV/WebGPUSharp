using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

public struct BindGroupEntry : IWebGpuFFIConvertibleAlloc<BindGroupEntry, BindGroupEntryFFI>
{
    public uint Binding;
    public Buffer? Buffer;
    public ulong Offset;
    public ulong Size;
    public Sampler? Sampler;
    public ITextureViewSource? TextureView;

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
        Sampler? sampler = default, ITextureViewSource? textureView = default)
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
        var textureViewOwnedHandle = input.TextureView?.UnsafeGetCurrentTextureViewOwnedHandle()
            ?? TextureViewHandle.Null;
        allocator.AddHandleToDispose(textureViewOwnedHandle);

        dest = new(
            binding: input.Binding,
            buffer: GetBorrowHandle(input.Buffer),
            offset: input.Offset,
            size: input.Size,
            sampler: GetBorrowHandle(input.Sampler),
            textureView: textureViewOwnedHandle
        );
    }
}

