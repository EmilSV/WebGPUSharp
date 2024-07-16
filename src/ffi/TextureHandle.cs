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
    public TextureViewHandle CreateView(TextureViewDescriptor textureViewDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(textureViewDescriptor.Label, allocator))
        {
            TextureViewDescriptorFFI* textureViewDescriptorPtr = &textureViewDescriptor._unsafeDescriptor;
            textureViewDescriptorPtr->Label = labelPtr;
            return WebGPU_FFI.TextureCreateView(this, textureViewDescriptorPtr);
        }
    }

    public TextureViewHandle CreateView(ref TextureViewDescriptor textureViewDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        fixed (TextureViewDescriptorFFI* textureViewDescriptorPtr = &textureViewDescriptor._unsafeDescriptor)
        fixed (byte* labelPtr = ToRefCstrUtf8(textureViewDescriptor.Label, allocator))
        {
            textureViewDescriptorPtr->Label = labelPtr;
            return WebGPU_FFI.TextureCreateView(this, textureViewDescriptorPtr);
        }
    }

    public TextureViewHandle CreateView(in TextureViewDescriptorFFI descriptor)
    {
        fixed (TextureViewDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.TextureCreateView(this, descriptorPtr);
        }
    }

    public void Destroy()
    {
        WebGPU_FFI.TextureDestroy(this);
    }

    public uint GetDepthOrArrayLayers()
    {
        return WebGPU_FFI.TextureGetDepthOrArrayLayers(this);
    }

    public TextureDimension GetDimension()
    {
        return WebGPU_FFI.TextureGetDimension(this);
    }

    public TextureFormat GetFormat()
    {
        return WebGPU_FFI.TextureGetFormat(this);
    }

    public uint GetHeight()
    {
        return WebGPU_FFI.TextureGetHeight(this);
    }

    public uint GetMipLevelCount()
    {
        return WebGPU_FFI.TextureGetMipLevelCount(this);
    }

    public uint GetSampleCount()
    {
        return WebGPU_FFI.TextureGetSampleCount(this);
    }

    public TextureUsage GetUsage()
    {
        return WebGPU_FFI.TextureGetUsage(this);
    }

    public uint GetWidth()
    {
        return WebGPU_FFI.TextureGetWidth(this);
    }

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.TextureSetLabel(this, labelPtr);
        }
    }

    public static ref nuint AsPointer(ref TextureHandle handle)
    {
        return ref Unsafe.As<TextureHandle, nuint>(ref handle);
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
        WebGPU_FFI.TextureAddRef(handle);
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