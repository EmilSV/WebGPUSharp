using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct TextureHandle : IDisposable, IWebGpuHandle<TextureHandle>
{
    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.TextureRelease(this);
        }
    }

    public readonly TextureViewHandle CreateView(in TextureViewDescriptor textureViewDescriptor)
    {
        unsafe
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            UFT8CStrFactory uft8Factory = new(allocator);

            fixed (TextureViewDescriptorFFI* textureViewDescriptorPtr = &textureViewDescriptor._unsafeDescriptor)
            fixed (byte* labelPtr = textureViewDescriptor.Label)
            {
                textureViewDescriptorPtr->Label = uft8Factory.Create(
                    text: labelPtr,
                    is16BitSize: textureViewDescriptor.Label.Is16BitSize,
                    length: textureViewDescriptor.Label.Length,
                    allowPassthrough: true
                );

                return WebGPU_FFI.TextureCreateView(this, textureViewDescriptorPtr);
            }
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
}