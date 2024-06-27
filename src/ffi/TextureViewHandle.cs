using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly partial struct TextureViewHandle :
    IDisposable, IWebGpuHandle<TextureViewHandle>
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
        return handle == null;
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

    public TextureView? ToSafeHandle(bool isOwnedHandle)
    {
        return TextureView.FromHandle(this, isOwnedHandle);
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.TextureViewRelease(this);
        }
    }
}
