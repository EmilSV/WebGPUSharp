using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

public struct BindGroupEntry : IWebGpuFFIConvertibleAlloc<BindGroupEntry, BindGroupEntryFFI>
{
    public required uint Binding;
    public Buffer? Buffer;
    public ulong Offset;
    public ulong Size;
    public Sampler? Sampler;
    public ITextureViewSource? TextureView;

    public BindGroupEntry()
    {
    }
    
    static void IWebGpuFFIConvertibleAlloc<BindGroupEntry, BindGroupEntryFFI>.UnsafeConvertToFFI(
        in BindGroupEntry input, WebGpuAllocatorHandle allocator, out BindGroupEntryFFI dest)
    {
        var textureViewOwnedHandle = input.TextureView?.UnsafeGetCurrentTextureViewOwnedHandle()
            ?? TextureViewHandle.Null;
        allocator.AddHandleToDispose(textureViewOwnedHandle);

        dest = new()
        {
            Binding = input.Binding,
            Buffer = GetBorrowHandle(input.Buffer),
            Offset = input.Offset,
            Size = input.Size,
            Sampler = GetBorrowHandle(input.Sampler),
            TextureView = textureViewOwnedHandle
        };
    }
}

