using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct BindGroupHandle :
    IDisposable, IWebGpuHandle<BindGroupHandle>
{
    public readonly void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.BindGroupRelease(this);
        }
    }

    public static ref UIntPtr AsPointer(ref BindGroupHandle handle)
    {
        return ref Unsafe.AsRef(handle._ptr);
    }

    public static BindGroupHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(BindGroupHandle handle)
    {
        return handle == Null;
    }

    public static BindGroupHandle UnsafeFromPointer(nuint pointer)
    {
        return new BindGroupHandle(pointer);
    }
}
