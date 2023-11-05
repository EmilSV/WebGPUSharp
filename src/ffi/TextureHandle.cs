using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct TextureHandle :
    IDisposable, IWebGpuHandle<TextureHandle, Texture>
{
    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.TextureRelease(this);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly TextureViewHandle CreateView(TextureViewDescriptor textureViewDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(textureViewDescriptor.Label, allocator))
        {
            TextureViewDescriptorFFI* textureViewDescriptorPtr = &textureViewDescriptor._unsafeDescriptor;
            textureViewDescriptorPtr->Label = labelPtr;
            return WebGPU_FFI.TextureCreateView(this, textureViewDescriptorPtr);
        }
    }

    public readonly TextureViewHandle CreateView(ref TextureViewDescriptor textureViewDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        fixed (TextureViewDescriptorFFI* textureViewDescriptorPtr = &textureViewDescriptor._unsafeDescriptor)
        fixed (byte* labelPtr = ToRefCstrUtf8(textureViewDescriptor.Label, allocator))
        {
            textureViewDescriptorPtr->Label = labelPtr;
            return WebGPU_FFI.TextureCreateView(this, textureViewDescriptorPtr);
        }
    }

    public static ref nuint AsPointer(ref TextureHandle handle)
    {
        return ref Unsafe.AsRef(handle._ptr);
    }

    public static TextureHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(TextureHandle handle)
    {
        return handle == Null;
    }

    public static TextureHandle UnsafeFromPointer(nuint pointer)
    {
        return new TextureHandle(pointer);
    }

    public static void Reference(TextureHandle handle)
    {
        WebGPU_FFI.TextureReference(handle);
    }

    public static void Release(TextureHandle handle)
    {
        WebGPU_FFI.TextureRelease(handle);
    }

    public Texture? ToSafeHandle(bool isOwnedHandle)
    {
        return Texture.FromHandle(this, isOwnedHandle);
    }
}