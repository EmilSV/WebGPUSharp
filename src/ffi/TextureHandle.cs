using System.Runtime.CompilerServices;
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

        var labelUtf8Span = ToUtf8Span(textureViewDescriptor.Label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            TextureViewDescriptorFFI* textureViewDescriptorPtr = &textureViewDescriptor._unsafeDescriptor;
            textureViewDescriptorPtr->Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
            return WebGPU_FFI.TextureCreateView(this, textureViewDescriptorPtr);
        }
    }

    public TextureViewHandle CreateView(ref TextureViewDescriptor textureViewDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(textureViewDescriptor.Label, allocator, addNullTerminator: false);

        fixed (TextureViewDescriptorFFI* textureViewDescriptorPtr = &textureViewDescriptor._unsafeDescriptor)
        fixed (byte* labelPtr = labelUtf8Span)
        {
            textureViewDescriptorPtr->Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length);
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

    public TextureViewHandle CreateView()
    {
        return WebGPU_FFI.TextureCreateView(this, null);
    }

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);
        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.TextureSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
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

    public Texture? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return ToSafeHandle<Texture, TextureHandle>(this);
        }
        else
        {
            return ToSafeHandleNoRefIncrement<Texture, TextureHandle>(this);
        }
    }
}