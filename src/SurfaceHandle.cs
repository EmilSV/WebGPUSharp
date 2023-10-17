using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SurfaceHandle : IDisposable, IWebGpuHandle<SurfaceHandle>
{
    public TextureFormat GetPreferredFormat(AdapterHandle adapter) => TextureFormat.BGRA8Unorm;
    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.SurfaceRelease(this);
        }
    }

    public static ref nuint AsPointer(ref SurfaceHandle handle)
    {
        return ref Unsafe.AsRef(handle._ptr);
    }

    public static SurfaceHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(SurfaceHandle handle)
    {
        return handle == Null;
    }

    public static SurfaceHandle UnsafeFromPointer(nuint pointer)
    {
        return new SurfaceHandle(pointer);
    }
}