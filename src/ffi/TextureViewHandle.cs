using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly partial struct TextureViewHandle :
    IDisposable,
    IWebGpuHandle<TextureViewHandle>
{
    public static ref nuint AsPointer(ref TextureViewHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static TextureViewHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(TextureViewHandle handle)
    {
        return handle._ptr == 0;
    }

    public static void Reference(TextureViewHandle handle)
    {
        WebGPU_FFI.TextureViewAddRef(handle);
    }

    public static void Release(TextureViewHandle handle)
    {
        WebGPU_FFI.TextureViewRelease(handle);
    }

    public static TextureViewHandle UnsafeFromPointer(nuint pointer)
    {
        return new TextureViewHandle(pointer);
    }

    public TextureView? ToSafeHandle(bool incrementRefCount = true)
    {
        if (incrementRefCount)
        {
            return WebGPUMarshal.ToSafeHandle<TextureView, TextureViewHandle>(this);
        }
        else
        {
            return WebGPUMarshal.ToSafeHandleNoRefIncrement<TextureView, TextureViewHandle>(this);
        }
    }

    public void Dispose()
    {
        if (_ptr != 0)
        {
            WebGPU_FFI.TextureViewRelease(this);
        }
    }
}
