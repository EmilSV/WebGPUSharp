using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly partial struct BindGroupLayoutHandle :
     IDisposable, IWebGpuHandle<BindGroupLayoutHandle, BindGroupLayout>
{
    public static ref nuint AsPointer(ref BindGroupLayoutHandle handle)
    {
        return ref Unsafe.AsRef(handle._ptr);
    }

    public static BindGroupLayoutHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(BindGroupLayoutHandle handle)
    {
        return handle == Null;
    }

    public static void Reference(BindGroupLayoutHandle handle)
    {
        WebGPU_FFI.BindGroupLayoutReference(handle);
    }

    public static void Release(BindGroupLayoutHandle handle)
    {
        WebGPU_FFI.BindGroupLayoutRelease(handle);
    }

    public static BindGroupLayoutHandle UnsafeFromPointer(nuint pointer)
    {
        return new BindGroupLayoutHandle(pointer);
    }

    public readonly void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.BindGroupLayoutRelease(this);
        }
    }

    public BindGroupLayout? ToSafeHandle(bool isOwnedHandle)
    {
        return BindGroupLayout.FromHandle(this, isOwnedHandle);
    }
}
