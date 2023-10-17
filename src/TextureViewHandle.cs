using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly partial struct TextureViewHandle : IDisposable, IWebGpuHandle<TextureViewHandle>
{
    public static ref nuint AsPointer(ref TextureViewHandle handle)
    {
        return ref Unsafe.AsRef(handle._ptr);
    }

    public static TextureViewHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(TextureViewHandle handle)
    {
        return handle == null;
    }

    public static TextureViewHandle UnsafeFromPointer(nuint pointer)
    {
        return new TextureViewHandle(pointer);
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.TextureViewRelease(this);
        }
    }
}
